using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BeanCounter.BusinessLogic
{
    public class Transaction
    {
        public string TransactionType { get; set; }

        public string TransactionID { get; set; }

        public string BusinessName { get; set; }

        public string BankMemo { get; set; }

        public string CheckNumber { get; set; }

        public string CategoryName { get; set; }

        public string UserMemo { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal TransactionAmount { get; set; }

        public int OriginalTransactionID { get; set; }

        public bool Verified { get; set; }

        //public Transaction()
        //{
        //}

        //public Transaction(bool verified, DateTime datePosted, DateTime dateUsed, string BusinessName, decimal transactionAmount, string categoryName, string bankMemo, int originalTransactionID, string userMemo, string checkNumber, string transactionType)
        //{
        //    this.Verified = verified;
        //    this.DatePosted = datePosted;
        //    this.DateUsed = dateUsed;
        //    this.BusinessName = BusinessName;
        //    this.TransactionAmount = transactionAmount;
        //    this.CategoryName = categoryName;
        //    this.BankMemo = bankMemo;
        //    this.OriginalTransactionID = originalTransactionID;
        //    this.UserMemo = userMemo;
        //    this.CheckNumber = checkNumber;
        //    this.TransactionType = transactionType;
        //}

        private static string AddDateRange(string dateRange)
        {
            string str = " and OriginalTransaction.DatePosted between '";
            DateRangeList dateRangeList = new DateRangeList(dateRange);
            str = string.Concat(str, Convert.ToString(dateRangeList.StartDate), "' and '");
            str = string.Concat(str, Convert.ToString(dateRangeList.EndDate), "'");
            return str;
        }

        public static List<string> Categories(string dateRange)
        {
            List<string> strs = new List<string>();
            string str = "select distinct CategoryName from OriginalTransaction where CategoryName <> 'YoYo' ";
            str = string.Concat(str, Transaction.AddDateRange(dateRange));
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            strs.Add(sqlDataReader["CategoryName"].ToString());
                        }
                    }
                }
            }
            return strs;
        }

        public static CategoryTotal CategoryTotal(string categoryName, string dateRange)
        {
            decimal num = new decimal(0);
            int num1 = 0;
            string str = string.Concat("select sum(SplitTransaction.TransactionAmount) as total, count(SplitTransaction.TransactionAmount) as transctionCount from SplitTransaction left join OriginalTransaction on SplitTransaction.OriginalTransactionID = OriginalTransaction.OriginalTransactionID where SplitTransaction.CategoryName = '", categoryName, "' ");
            str = string.Concat(str, Transaction.AddDateRange(dateRange));
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read() && !string.IsNullOrEmpty(sqlDataReader["total"].ToString()) && Transaction.IsNumber(sqlDataReader["total"].ToString()))
                        {
                            num = Convert.ToDecimal(sqlDataReader["total"].ToString());
                            num1 = Convert.ToInt32(sqlDataReader["transctionCount"].ToString());
                        }
                    }
                }
            }
            return new CategoryTotal(num1, num);
        }

        public static Transaction CheckBankTricks(Transaction transaction, BankAccount bankAccount)
        {
            switch (transaction.TransactionType.ToLower())
            {
                case "debit":
                case "credit":
                case "other":
                    ReverseFields(transaction, bankAccount);
                    FixBusinessName(transaction, bankAccount);
                    FixMemo(transaction, bankAccount);
                    break;
                case "check":
                    FixMemo(transaction, bankAccount);
                    //transaction.BankMemo
                    break;
            }
            transaction.BusinessName = transaction.BusinessName.ToUpper();
            return transaction;
        }

        private static void FixMemo(Transaction transaction, BankAccount bankAccount)
        {
            string removeFromBankMemo = bankAccount.RemoveFromBankMemo;
            if (removeFromBankMemo != null)
            {
                if (removeFromBankMemo == "[Everything]")
                {
                    if (transaction.BankMemo.StartsWith("INTERNET BANKING PAYMENT TO CRED"))
                    {
                        transaction.BankMemo = "CC Payment";
                    }
                    else if (transaction.BankMemo.StartsWith("ATM WITHDRAWAL"))
                    {
                        transaction.BankMemo = "ATM WITHDRAWAL";
                        transaction.CategoryName = "Miscellaneous: Cash";
                    }
                    else if (transaction.BankMemo.StartsWith("ATM FEE"))
                    {
                        transaction.BankMemo = "ATM FEE";
                        transaction.CategoryName = "Banking: Service Charge";
                    }
                    else if (transaction.BankMemo.StartsWith("REVERSED ATM FEE"))
                    {
                        transaction.BankMemo = "REVERSED ATM FEE";
                    }
                    else
                    {
                        transaction.BankMemo = string.Empty;
                    }
                }
                else if (removeFromBankMemo == "[Remove Business Name]")
                {
                    transaction.BankMemo = transaction.BankMemo.Replace(transaction.BusinessName, string.Empty).Trim();
                }
                else
                {
                    transaction.BankMemo = transaction.BankMemo.Replace(removeFromBankMemo, string.Empty).Trim();
                }
            }
        }

        private static void FixBusinessName(Transaction transaction, BankAccount bankAccount)
        {
            string removeFromBusiness = bankAccount.RemoveFromBusiness;
            if (removeFromBusiness != null)
            {
                //if (removeFromBusiness == "[Remove Business Name]")
                //{
                //    transaction.BusinessName = Transaction.RemovePartialBusinessName(transaction.BusinessName, transaction.BusinessName.Replace(bankAccount.RemoveFromBankMemo, "")).Trim();
                //}
                //else 
                if (removeFromBusiness == "[Everything]")
                {
                    transaction.BusinessName = string.Empty;
                }
                else
                {
                    transaction.BusinessName = transaction.BusinessName.Replace(removeFromBusiness, string.Empty).Trim();
                }
            }
        }

        private static void ReverseFields(Transaction transaction, BankAccount bankAccount)
        {
            string businessName = transaction.BusinessName;
            string bankMemo = transaction.BankMemo;
            if (bankAccount.ReverseFields && bankMemo != bankAccount.RemoveFromBusiness)
            {
                businessName = transaction.BankMemo;
                bankMemo = transaction.BusinessName;
            }
            transaction.BusinessName = businessName;
            transaction.BankMemo = bankMemo;
        }

        private static bool IsDate(string date)
        {
            DateTime dateTime;
            bool flag;
            try
            {
                DateTime.TryParse(date, out dateTime);
                flag = (!(dateTime != DateTime.MinValue) || !(dateTime != DateTime.MaxValue) ? false : true);
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        private static bool IsNumber(string text)
        {
            double num;
            text = text.Trim();
            return double.TryParse(text, out num);
        }

        public static void MarkVerified()
        {
            string str = "update OriginalTransaction set Verified = 1";
            str = string.Concat(str, " where CategoryName is not null");
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public static decimal MonthlyAverage(decimal transactionsTotal, string dateRange)
        {
            DateRangeList dateRangeList = new DateRangeList(dateRange);
            int days = dateRangeList.EndDate.Subtract(dateRangeList.StartDate).Days;
            decimal num = (transactionsTotal / days) * new decimal(365);
            return Math.Round(num / new decimal(12));
        }

        public static DateTime OldestTransaction()
        {
            DateTime dateTime;
            string str = "select top 1 DatePosted from OriginalTransaction order by OriginalTransactionID";
            DateTime dateTime1 = new DateTime();
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read() && !string.IsNullOrEmpty(sqlDataReader["DatePosted"].ToString()) && Transaction.IsDate(sqlDataReader["DatePosted"].ToString()))
                        {
                            dateTime1 = Convert.ToDateTime(sqlDataReader["DatePosted"].ToString());
                        }
                    }
                }
                dateTime = dateTime1;
            }
            return dateTime;
        }

        public static string RemovePartialBusinessName(string @string, string replace)
        {
            string str = "";
            int length = @string.Length;
            for (int i = 1; i < @string.Length; i++)
            {
                if (replace.Contains(@string.Substring(length - 1, i)))
                {
                    str = @string.Substring(length - 1, i);
                }
                length--;
            }
            if (str.Length <= 4)
            {
                return @string;
            }
            return @string.Replace(str, "");
        }

        public static IEnumerable<Transaction> Transactions(int BankAccountID, bool showOnlyUnverfied, string orderBy)
        {
            IEnumerable<Transaction> transactions;
            string str = string.Concat("SELECT Verified, DatePosted, Business, TransactionAmount, CategoryName, BankMemo, CheckNumber, TransactionType, OriginalTransactionID, UserMemo FROM OriginalTransaction WHERE (BankAccountId = ", Convert.ToString(BankAccountID), ")");
            if (showOnlyUnverfied)
            {
                str = string.Concat(str, " AND (Verified = 0)");
            }
            str = string.Concat(str, orderBy);
            List<Transaction> transactions1 = new List<Transaction>();
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            Transaction transaction = new Transaction()
                            {
                                Verified = Convert.ToBoolean(sqlDataReader["Verified"].ToString()),
                                DatePosted = Convert.ToDateTime(sqlDataReader["DatePosted"].ToString()),
                                BusinessName = sqlDataReader["Business"].ToString(),
                                TransactionAmount = Convert.ToDecimal(sqlDataReader["TransactionAmount"].ToString()),
                                CategoryName = sqlDataReader["CategoryName"].ToString(),
                                BankMemo = sqlDataReader["BankMemo"].ToString(),
                                OriginalTransactionID = Convert.ToInt32(sqlDataReader["OriginalTransactionID"].ToString()),
                                UserMemo = sqlDataReader["UserMemo"].ToString(),
                                CheckNumber = sqlDataReader["CheckNumber"].ToString(),
                                TransactionType = sqlDataReader["TransactionType"].ToString()
                            };
                            transactions1.Add(transaction);
                        }
                    }
                }
                transactions = transactions1;
            }
            return transactions;
        }

        public static List<Transaction> TransactionsByCategory(string categoryName, string dateRange)
        {
            List<Transaction> transactions;
            string str = string.Concat("select OriginalTransaction.DatePosted, OriginalTransaction.Business, SplitTransaction.TransactionAmount, OriginalTransaction.BankMemo, OriginalTransaction.CheckNumber, OriginalTransaction.TransactionType, OriginalTransaction.UserMemo FROM Originaltransaction left join SplitTransaction on SplitTransaction.OriginalTransactionID = OriginalTransaction.OriginalTransactionID WHERE SplitTransaction.CategoryName = '", categoryName, "'");
            str = string.Concat(str, Transaction.AddDateRange(dateRange));
            str = string.Concat(str, "order by OriginalTransaction.DatePosted desc");
            List<Transaction> transactions1 = new List<Transaction>();
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            Transaction transaction = new Transaction()
                            {
                                DatePosted = Convert.ToDateTime(sqlDataReader["DatePosted"].ToString()),
                                BusinessName = sqlDataReader["Business"].ToString(),
                                TransactionAmount = Convert.ToDecimal(sqlDataReader["TransactionAmount"].ToString()),
                                BankMemo = sqlDataReader["BankMemo"].ToString(),
                                UserMemo = sqlDataReader["UserMemo"].ToString(),
                                CheckNumber = sqlDataReader["CheckNumber"].ToString(),
                                TransactionType = sqlDataReader["TransactionType"].ToString()
                            };
                            transactions1.Add(transaction);
                        }
                    }
                }
                transactions = transactions1;
            }
            return transactions;
        }

        public static void UpdateTransaction(bool verified, string BusinessName, string userMemo, string originalTransactionID)
        {
            string str = "";
            object[] objArray = new object[] { "update OriginalTransaction set Verified = ", verified ? "1" : "0", ", Business = '", BusinessName.Replace("'", "''"), "', UserMemo = '", userMemo.Replace("'", "''"), "' where OriginalTransactionID = ", originalTransactionID };
            str = string.Concat(objArray);
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateTransactionCategory(string categoryName, int originalTransactionID)
        {
            if (!string.IsNullOrEmpty(categoryName))
            {
                categoryName = string.Concat("'", categoryName, "'");
            }
            else
            {
                categoryName = "null";
            }
            string str = string.Concat("update OriginalTransaction set CategoryName = ", categoryName, " where OriginalTransactionID = ", Convert.ToString(originalTransactionID));
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
            if (categoryName == "[Multiple Categories]")
            {
                return;
            }
            str = string.Concat("update SplitTransaction set CategoryName = ", categoryName, " where OriginalTransactionID = ", Convert.ToString(originalTransactionID));
            using (SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection1.Open();
                using (SqlCommand sqlCommand1 = new SqlCommand(str, sqlConnection1))
                {
                    sqlCommand1.ExecuteNonQuery();
                }
            }
        }
    }
}