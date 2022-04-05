using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BeanCounter.BusinessLogic
{
    public class BankAccount
    {
        public int BankAccountID { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankFID { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public DateTime BalanceDate { get; set; }
        public string TimeZone { get; set; }
        public decimal CreditLimit { get; set; }
        public string AccountName { get; set; }
        public string WebAddress { get; set; }
        public string RemoveFromBusiness { get; set; }
        public string RemoveFromBankMemo { get; set; }
        public bool ReverseFields { get; set; }

        public static decimal GetAccountBalance(string accountType)
        {
            accountType = accountType.ToUpper();
            decimal accountBalance = 0;
            string sql = "SELECT SUM(OnlineBalance) as cBalance from [BankAccounts] WHERE ";
            if (accountType == "CREDIT")
            {
                sql = string.Concat(sql, "(AccountType = 'CREDIT' or AccountType = 'CREDITLINE')");
            }
            else if (accountType == "CASH")
            {
                sql = string.Concat(sql, "(AccountType = 'CHECKING' or AccountType = 'SAVINGS')");
            }
            sql = string.Concat(sql, " and (ExcludeFromBalances <> 1) and (InActive <> 1)");
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read() && !string.IsNullOrEmpty(sqlDataReader["cBalance"].ToString()))
                        {
                            accountBalance = Convert.ToDecimal(sqlDataReader["cBalance"].ToString());
                        }
                    }
                }
            }
            return accountBalance;
        }

        public static List<BankAccount> GetBankAccounts(string accountType)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();
            string sql = "SELECT AccountName, OnlineBalance, BankAccountId, WebAddress FROM [BankAccounts] WHERE ";
            if (accountType.ToUpper() == "CREDIT")
            {
                sql = string.Concat(sql, "(AccountType = 'CREDIT' or AccountType = 'CREDITLINE')");
            }
            else if (accountType.ToUpper() == "CASH")
            {
                sql = string.Concat(sql, "(AccountType = 'CHECKING' or AccountType = 'SAVINGS') ");
            }
            sql = string.Concat(sql, "  and (inactive <> 1)");
            sql = string.Concat(sql, "ORDER BY BankAccountId");
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            bankAccounts.Add(new BankAccount()
                            {
                                AccountName = sqlDataReader["AccountName"].ToString(),
                                Balance = Convert.ToDecimal(sqlDataReader["OnlineBalance"].ToString()),
                                BankAccountID = Convert.ToInt32(sqlDataReader["BankAccountId"].ToString()),
                                WebAddress = sqlDataReader["WebAddress"].ToString()
                            });
                        }
                    }
                }
                //bankAccounts = bankAccounts1;
            }
            return bankAccounts;
        }

        public static BankAccount GetBankAccount(OpenFinancialExchange data)
        {
            BankAccount bankAccount = data.BankAccount;
            string str = string.Concat("SELECT BankAccountId, AccountName, WebAddress, RemoveFromBusiness, RemoveFromBankMemo, ReverseFields from [BankAccounts] WHERE BankFID = '", data.BankAccount.BankFID, "'");
            if (!string.IsNullOrEmpty(data.BankAccount.AccountNumber))
            {
                str = string.Concat(str, " AND AccountNumber = '", data.BankAccount.AccountNumber, "'");
            }
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            bankAccount.BankAccountID = Convert.ToInt32(sqlDataReader["BankAccountId"].ToString());
                            bankAccount.AccountName = sqlDataReader["AccountName"].ToString();
                            bankAccount.WebAddress = sqlDataReader["WebAddress"].ToString();
                            bankAccount.RemoveFromBusiness = sqlDataReader["RemoveFromBusiness"].ToString();
                            bankAccount.RemoveFromBankMemo = sqlDataReader["RemoveFromBankMemo"].ToString();
                            bankAccount.ReverseFields = Convert.ToBoolean(sqlDataReader["ReverseFields"].ToString());
                        }
                    }
                }
            }
            return bankAccount;
        }

        public static int CreateBankAccount(BankAccount bankAccount)
        {
            int bankAccountId = 0;
            string sql = "INSERT INTO [BankAccounts]  (AccountName, WebAddress, AccountNumber, BankName, BankFID, AccountType, RemoveFromBusiness, RemoveFromBankMemo, ReverseFields, OnlineBalance, ExcludeFromBalances, Inactive)";
            if (bankAccount.CreditLimit != new decimal(0))
            {
                sql = string.Concat(sql, ", CreditLimit");
            }
            sql = string.Concat(sql, "VALUES ('", bankAccount.AccountName, "', '", bankAccount.WebAddress, "', '", bankAccount.AccountNumber, "', '", bankAccount.BankName, "', '", bankAccount.BankFID, "', '", bankAccount.AccountType, "', '", bankAccount.RemoveFromBusiness, "', '", bankAccount.RemoveFromBankMemo, "', ", bankAccount.ReverseFields ? 1 : 0, ", ", bankAccount.Balance, ", ", 0, ", ", 0);
            if (bankAccount.CreditLimit != new decimal(0))
            {
                sql = string.Concat(sql, ", ", bankAccount.CreditLimit);
            }
            sql = string.Concat(sql, ")");
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                using (SqlCommand sqlCommand = new SqlCommand("SELECT @@Identity", sqlConnection))
                {
                    bankAccountId = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
                }
            }
            return bankAccountId;
        }
    }
}