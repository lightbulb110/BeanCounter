using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BeanCounter.BusinessLogic
{
    public class ImportUtilities
    {

        public static string GetCategoryName(Transaction transaction, List<Business> Businesses)
        {
            var categoryName = string.Empty;
            if (transaction.BusinessName != "?")
            {
                categoryName = Business.GetCategoryName(transaction.BusinessName, Businesses);
                if (categoryName == string.Empty)
                {
                    categoryName = Business.GetTrickyCategory(transaction);
                }
                if (categoryName == string.Empty)
                {
                    categoryName = Business.LocalBusiness(transaction.BusinessName, true);
                }
                if (categoryName != string.Empty)
                {
                    categoryName = ImportUtilities.GetSpecialCategoryName(categoryName, transaction.TransactionAmount);
                }
            }
            return categoryName;
        }

        private static string GetSpecialCategoryName(string categoryName, decimal transactionAmount)
        {
            if (!string.IsNullOrEmpty(categoryName) && categoryName.ToLower().StartsWith("auto: fuel") && transactionAmount > new decimal(-10))
            {
                categoryName = "Food: Groceries";
            }
            return categoryName;
        }

        public static int InsertIntoOringalTransaction(BankAccount bankAccount, Transaction transaction, string categoryName)
        {
            int originalTransactionId;
            string sql = "INSERT INTO OriginalTransaction(";
            sql = string.Concat(sql, "Verified, TransactionID, DatePosted, TransactionAmount, Business, BankMemo, BankAccountId, TransactionType");
            if (!string.IsNullOrEmpty(transaction.CheckNumber))
            {
                sql = string.Concat(sql, ", CheckNumber");
            }
            if (categoryName != "")
            {
                sql = string.Concat(sql, ", CategoryName");
            }
            if (transaction.TransactionDate != DateTime.MinValue)
            {
                sql = string.Concat(sql, ", TransactionDate");
            }
            sql = string.Concat(sql, ") Values(");
            sql = string.Concat(sql, "0");
            sql = string.Concat(sql, ", '", transaction.TransactionID, "'");
            sql = string.Concat(sql, ", '", Convert.ToString(transaction.DatePosted), "'");
            sql = string.Concat(sql, ", ", Convert.ToString(transaction.TransactionAmount));
            sql = string.Concat(sql, ", '", transaction.BusinessName.Replace("'", "''"), "'");
            sql = string.Concat(sql, ", '", transaction.BankMemo.Replace("'", "''"), "'");
            sql = string.Concat(sql, ", ", Convert.ToString(bankAccount.BankAccountID));
            sql = string.Concat(sql, ", '", transaction.TransactionType, "'");
            if (!string.IsNullOrEmpty(transaction.CheckNumber))
            {
                sql = string.Concat(sql, ", '", transaction.CheckNumber, "'");
            }
            if (categoryName != "")
            {
                sql = string.Concat(sql, ", '", categoryName, "'");
            }
            if (transaction.TransactionDate != DateTime.MinValue)
            {
                sql = string.Concat(sql, ", '", Convert.ToString(transaction.TransactionDate), "'");
            }
            sql = string.Concat(sql, ")");
            string str1 = " SELECT @@Identity";
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                using (SqlCommand sqlCommand1 = new SqlCommand(str1, sqlConnection))
                {
                    originalTransactionId = Convert.ToInt32(sqlCommand1.ExecuteScalar().ToString());
                }
            }
            return originalTransactionId;
        }

        public static void InsertIntoSplitTransction(string categoryName, int transactionID, Transaction transaction)
        {
            string str = "INSERT INTO SplitTransaction(";
            str = string.Concat(str, "OriginalTransactionID, TransactionAmount");
            if (!string.IsNullOrEmpty(categoryName))
            {
                str = string.Concat(str, ", CategoryName");
            }
            str = string.Concat(str, ") Values(", transactionID);
            str = string.Concat(str, ", ", Convert.ToString(transaction.TransactionAmount));
            if (!string.IsNullOrEmpty(categoryName))
            {
                str = string.Concat(str, ", '", categoryName, "'");
            }
            str = string.Concat(str, ")");
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery().ToString();
                }
            }
        }

        public static bool DoesTransactionExists(Transaction transaction, int bankAccountID)
        {
            bool transactionExists = false;
            string sql = string.Concat("select * from OriginalTransaction where TransactionID = '", transaction.TransactionID, "' and BankAccountId = ", Convert.ToString(bankAccountID), " and TransactionAmount = ", Convert.ToString(transaction.TransactionAmount));
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            // This transaction already exists in the database
                            transactionExists = true;
                        }
                        else
                        {
                            // This transaction does not exist in the database
                            transactionExists = false;
                        }
                    }
                }
            }
            return transactionExists;
        }

        public static void LogBalanceHistory(OpenFinancialExchange data)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                using (var command = new SqlCommand("[dbo].[spLogAccountBalance]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BankAccountId", data.BankAccount.BankAccountID);
                    command.Parameters.AddWithValue("@Balance", data.BankAccount.Balance);
                    command.Parameters.AddWithValue("@BalanceDate", data.BankAccount.BalanceDate);
                    command.Parameters.AddWithValue("@TimeZone", data.BankAccount.TimeZone);
                    try
                    {
                        //_logger.LogInformation("Attempting to run spLogAccountBalance");
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        var temp = ex.Message.ToString();
                        //_logger.LogError(ex.Message);
                    }
                    finally
                    {
                        if (connection != null)
                        {
                            connection?.Close();
                        }
                    }
                }
            }

        }

        public static void UpdateBalance(OpenFinancialExchange data)
        {
            string sql = string.Concat("UPDATE [BankAccounts] SET OnlineBalance = ", Convert.ToString(data.BankAccount.Balance), " WHERE (BankFID = '", Convert.ToString(data.BankAccount.BankFID), "')");
            if (!string.IsNullOrEmpty(data.BankAccount.AccountNumber))
            {
                sql = string.Concat(sql, " AND (AccountNumber = '", Convert.ToString(data.BankAccount.AccountNumber), "')");
            }
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }


    }
}