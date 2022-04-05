using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BeanCounter.BusinessLogic
{
    public class SplitTransaction : Transaction
    {
        public int SplitTransactionID;

        public SplitTransaction()
        {
        }

        public SplitTransaction(decimal transactionAmount, string categoryName, string userMemo, int splitTransactionID)
        {
            this.TransactionAmount = transactionAmount;
            this.CategoryName = categoryName;
            this.UserMemo = userMemo;
            this.SplitTransactionID = splitTransactionID;
        }

        public static int InsertTransaction(string categoryName, string userMemo, decimal transactionAmount, int originalTransactionID)
        {
            int num = 0;
            string str = "insert into SplitTransaction(CategoryName, UserMemo, TransactionAmount, OriginalTransactionID) values(";
            str = (!string.IsNullOrEmpty(categoryName) ? string.Concat(str, "'", categoryName, "'") : string.Concat(str, "null"));
            object obj = str;
            object[] objArray = new object[] { obj, ", '", userMemo, "', ", Convert.ToString(transactionAmount), ", ", originalTransactionID, ")" };
            str = string.Concat(objArray);
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                using (SqlCommand sqlCommand1 = new SqlCommand("SELECT @@Identity", sqlConnection))
                {
                    num = Convert.ToInt32(sqlCommand1.ExecuteScalar().ToString());
                }
            }
            return num;
        }

        public static List<SplitTransaction> SplitTransactions(int originalTransactionID)
        {
            List<SplitTransaction> splitTransactions;
            string str = string.Concat("SELECT TransactionAmount, CategoryName, UserMemo, SplitTransactionID FROM SplitTransaction WHERE (OriginalTransactionID = ", Convert.ToString(originalTransactionID), ")");
            List<SplitTransaction> splitTransactions1 = new List<SplitTransaction>();
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            SplitTransaction splitTransaction = new SplitTransaction(Convert.ToDecimal(sqlDataReader["TransactionAmount"].ToString()), sqlDataReader["CategoryName"].ToString(), sqlDataReader["UserMemo"].ToString(), Convert.ToInt32(sqlDataReader["SplitTransactionID"].ToString()));
                            splitTransactions1.Add(splitTransaction);
                        }
                    }
                }
                splitTransactions = splitTransactions1;
            }
            return splitTransactions;
        }

        public static void UpdateSplitTransaction(string categoryName, string userMemo, decimal transactionAmount, int splitTransactionID)
        {
            string str = string.Concat("update SplitTransaction set TransactionAmount = ", Convert.ToString(transactionAmount));
            str = (!string.IsNullOrEmpty(categoryName) ? string.Concat(str, ", Categoryname = '", categoryName, "'") : string.Concat(str, ", CategoryName = null"));
            if (!string.IsNullOrEmpty(userMemo))
            {
                str = string.Concat(str, ", UserMemo = '", userMemo, "'");
            }
            str = string.Concat(str, " where SplitTransactionID = ", Convert.ToString(splitTransactionID));
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}