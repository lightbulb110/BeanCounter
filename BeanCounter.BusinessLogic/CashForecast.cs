using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BeanCounter.BusinessLogic
{
    public class CashForecast
    {
        public decimal C1;

        public decimal C2;

        public decimal C3;

        public decimal C4;

        public decimal C5;

        public decimal C6;

        public decimal C7;

        public decimal C8;

        public decimal C9;

        public decimal C10;

        public decimal C11;

        public decimal C12;

        public decimal C13;

        public decimal Total;

        public decimal Average;

        public IncomeForecast _IncomeForecast;

        public SpendingForecast _SpendingForecast;

        public BalanceForecast _BalanceForecast;

        public GainForecast _GainForecast;

        public CashForecast()
        {
        }

        private static decimal AnnualAmounts(int month, int year, string type)
        {
            decimal num = new decimal(0);
            foreach (Category category in Category.StaticAmountCategories(type, "Annually"))
            {
                if (category.SpecificDate.Day == 1 && category.SpecificDate.AddMonths(-1).Month == month)
                {
                    num += category.StaticAmount;
                }
                if (category.SpecificDate.Day > 1 && category.SpecificDate.Month == month)
                {
                    num += category.StaticAmount;
                }
                if (category.SpecificDate >= DateTime.Today)
                {
                    continue;
                }
                Category.UpdateSpecificDate(category.SpecificDate.AddYears(1), category.CategoryID);
            }
            return num;
        }

        private static decimal AnytimeAmounts(int month, int year, string type, Options options)
        {
            string[] str = new string[] { "select sum(c", Convert.ToString(month), ") as transactionAmounts from Category where Type = '", type, "' and Frequency = 'Anytime' and ExcludeFromBudget = No" };
            decimal overages = CashForecast.GetMonthlyAmounts(month, string.Concat(str));
            if (options.AddOverages)
            {
                overages = overages + ((overages * options.Overages) / new decimal(100));
            }
            if (month == Convert.ToInt32(DateTime.Today.ToString("MM")))
            {
                DateTime dateTime = new DateTime(year, month, 1);
                DateTime dateTime1 = dateTime.AddMonths(1);
                decimal day = dateTime1.AddDays(-1).Day;
                decimal num = (day - DateTime.Today.Day) / day;
                if (overages != new decimal(0))
                {
                    overages *= num;
                }
            }
            return Math.Round(overages, 0);
        }

        public static decimal BudgetAmount(int month, int year, string type, Options options)
        {
            decimal num = new decimal(0);
            num += CashForecast.AnnualAmounts(month, CashForecast.FindYear(year, month), type);
            num += CashForecast.StaticBudgetAmounts(month, CashForecast.FindYear(year, month), type, "Weekly");
            num += CashForecast.StaticBudgetAmounts(month, CashForecast.FindYear(year, month), type, "Bi-Weekly");
            num += CashForecast.AnytimeAmounts(month, CashForecast.FindYear(year, month), type, options);
            num += CashForecast.OneTimeBudgetAmount(month, CashForecast.FindYear(year, month), type);
            num += CashForecast.MonthlyCmdText(month, CashForecast.FindYear(year, month), type);
            return Math.Round(num, 0);
        }

        public static CashForecast BuildCashForecast(Options options)
        {
            CashForecast cashForecast = new CashForecast();
            decimal balance;
            balance = !options.OverrideBalance ? CashForecast.CheckingBalance() : options.Balance;
            cashForecast._IncomeForecast = new IncomeForecast();
            cashForecast._SpendingForecast = new SpendingForecast(options);
            cashForecast._GainForecast = new GainForecast(cashForecast);
            cashForecast._BalanceForecast = new BalanceForecast(balance, cashForecast);
            CashForecast.InsertForecast(cashForecast._BalanceForecast, "BalanceForecast", options);
            return cashForecast;
        }

        public static decimal CheckingBalance()
        {
            decimal balance = 0;
            string sql = "SELECT SUM(OnlineBalance) as balance from [BankAccounts] WHERE AccountType = 'CHECKING'";
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read() && sqlDataReader["balance"].ToString() != null && CashForecast.IsNumber(sqlDataReader["balance"].ToString()))
                        {
                            balance = Convert.ToDecimal(sqlDataReader["balance"].ToString());
                        }
                    }
                }
            }
            return balance;
        }

        public static int FindYear(int year, int month)
        {
            if (Convert.ToInt32(DateTime.Today.ToString("MM")) > month)
            {
                year++;
            }
            return year;
        }

        private static void InsertForecast(CashForecast cashForecast, string forecastType, Options options)
        {
            string sql = string.Concat("insert into ", forecastType, "(C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, DateCalculated");
            if (forecastType != "BalanceForecast")
            {
                sql = string.Concat(sql, ", Average");
            }
            if (options.AddOverages)
            {
                sql = string.Concat(sql, ", AddOverages, Overages");
            }
            sql = string.Concat(sql, ") values(", cashForecast.C1, ", ", cashForecast.C2, ", ", cashForecast.C3, ", ", cashForecast.C4, ", ", cashForecast.C5, ", ", cashForecast.C6, ", ", cashForecast.C7, ", ", cashForecast.C8, ", ", cashForecast.C9, ", ", cashForecast.C10, ", ", cashForecast.C11, ", ", cashForecast.C12, ", '", DateTime.Today, "'");
            if (forecastType != "BalanceForecast")
            {
                sql = string.Concat(sql, ", ", cashForecast.Average);
            }
            if (options.AddOverages)
            {
                sql = string.Concat(sql, ",", Convert.ToString(options.AddOverages), ",", Convert.ToString(options.Overages));
            }
            sql = string.Concat(sql, ")");
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        private static bool IsNumber(string text)
        {
            double num;
            text = text.Trim();
            return double.TryParse(text, out num);
        }

        private static decimal GetMonthlyAmounts(int month, string cmdText)
        {
            decimal transactionAmounts = new decimal(0);
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read() && sqlDataReader["transactionAmounts"].ToString() != null && CashForecast.IsNumber(sqlDataReader["transactionAmounts"].ToString()))
                        {
                            transactionAmounts = Convert.ToDecimal(sqlDataReader["transactionAmounts"].ToString());
                        }
                    }
                }
            }
            return transactionAmounts;
        }

        private static decimal MonthlyCmdText(int month, int year, string type)
        {
            string[] str = new string[] { "select sum(c", Convert.ToString(month), ") as transactionAmounts from Category where Type = '", type, "' and Frequency = 'Monthly' and DayOfMonth > 1 and ExcludeFromBudget = No" };
            string str1 = string.Concat(str);
            if (month == DateTime.Today.Month)
            {
                DateTime today = DateTime.Today;
                str1 = string.Concat(str1, " and DayOfMonth > ", today.Day);
            }
            decimal num = CashForecast.GetMonthlyAmounts(month, str1);
            if (month == 12)
            {
                month = 1;
            }
            else if (month < 12)
            {
                month++;
            }
            string[] strArrays = new string[] { "select sum(c", Convert.ToString(month), ") as transactionAmounts from Category where Type = '", type, "' and Frequency = 'Monthly' and DayOfMonth = 1 and ExcludeFromBudget = No" };
            str1 = string.Concat(strArrays);
            num += CashForecast.GetMonthlyAmounts(month, str1);
            return num;
        }

        private static decimal OneTimeBudgetAmount(int month, int year, string type)
        {
            decimal num = new decimal(0);
            foreach (Category category in Category.StaticAmountCategories(type, "One Time"))
            {
                if (category.SpecificDate.Day == 1 && category.SpecificDate.AddMonths(-1).Month == month && category.SpecificDate.Year <= DateTime.Today.Year)
                {
                    num += category.StaticAmount;
                }
                if (category.SpecificDate.Day > 1 && category.SpecificDate.Month == month && category.SpecificDate.Year <= DateTime.Today.Year)
                {
                    num += category.StaticAmount;
                }
                if (category.SpecificDate >= DateTime.Today)
                {
                    continue;
                }
                Category.UpdateSpecificDate(category.SpecificDate.AddYears(1), category.CategoryID);
            }
            return num;
        }

        private static decimal StaticBudgetAmounts(int month, int year, string type, string frequency)
        {
            decimal num = new decimal(0);
            int num1 = 0;
            if (frequency == "Weekly")
            {
                num1 = 7;
            }
            else if (frequency == "Bi-Weekly")
            {
                num1 = 14;
            }
            List<Category> categories = Category.StaticAmountCategories(type, frequency);
            DateTime dateTime = new DateTime();
            if (categories.Count > 0)
            {
                foreach (Category category in categories)
                {
                    dateTime = Category.NextOccuranceLookup(category.CategoryID);
                    if (dateTime < DateTime.Today)
                    {
                        DateTime dateTime1 = dateTime;
                        while (dateTime1 < DateTime.Today)
                        {
                            string str = frequency;
                            string str1 = str;
                            if (str == null)
                            {
                                continue;
                            }
                            if (str1 == "Bi-Weekly")
                            {
                                dateTime1 = dateTime1.AddDays(14);
                            }
                            else if (str1 == "Weekly")
                            {
                                dateTime1 = dateTime1.AddDays(7);
                            }
                        }
                        Category.UpdateNextOccurance(category.CategoryID, dateTime1);
                    }
                    int num2 = 0;
                    if (dateTime == new DateTime())
                    {
                        continue;
                    }
                    DateTime dateTime2 = dateTime;
                    while (dateTime2 <= new DateTime(year, month, 1))
                    {
                        dateTime2 = dateTime2.AddDays((double)num1);
                    }
                    while (dateTime2 <= (new DateTime(year, month, 2)).AddMonths(1).AddDays(-2))
                    {
                        num2++;
                        DateTime endDate = category.EndDate;
                        DateTime dateTime3 = new DateTime();
                        if (endDate != dateTime3 && category.EndDate <= dateTime2)
                        {
                            num2--;
                        }
                        dateTime2 = dateTime2.AddDays((double)num1);
                    }
                    if (month < 12 && dateTime2 == new DateTime(year, month + 1, 1))
                    {
                        num2++;
                    }
                    num = num + (num2 * category.StaticAmount);
                }
            }
            return num;
        }
    }
}