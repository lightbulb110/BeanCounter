using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BeanCounter.BusinessLogic
{
    public class Business
    {
        public string BusinessName { get; set; }

        public string CategoryName { get; set; }

        public bool AutoCategorize { get; set; }

        public bool IsLocalBusiness { get; set; }

        public int BusinessID { get; set; }

        internal static string GetTrickyCategory(Transaction transaction)
        {
            string categoryName = string.Empty;

            string str = "SELECT CategoryName from SpecialCategories WHERE Amount = " + transaction.TransactionAmount.ToString() +
                " AND Business = '" + transaction.BusinessName.Replace("'", "''") + "'";
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            categoryName = sqlDataReader["CategoryName"].ToString();
                        }
                    }
                }
            }
            return categoryName;
        }


        public static void DeleteBusiness(int BusinessID)
        {
            string str = string.Concat("delete from Businesses where BusinessID = ", Convert.ToString(BusinessID));
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public static int InsertBusiness(string BusinessName, string categoryName, bool autoCategorize, bool localBusiness)
        {
            if (!string.IsNullOrEmpty(categoryName))
            {
                categoryName = string.Concat("'", categoryName, "'");
            }
            else
            {
                categoryName = "null";
            }
            string str = "insert into Businesses(BusinessName, CategoryName, AutoCategorize, LocalBusiness) values(";
            str = string.Concat(str, "'", BusinessName.Replace("'", "''"), "', ", categoryName, ", ", autoCategorize ? "1" : "0", ", ", localBusiness ? "1" : "0", ")");
            int businessId = 0;
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                using (SqlCommand sqlCommand1 = new SqlCommand("SELECT @@Identity", sqlConnection))
                {
                    businessId = Convert.ToInt32(sqlCommand1.ExecuteScalar().ToString());
                }
            }
            return businessId;
        }

        public static string LocalBusiness(string Business, bool autoCategorizeOnly)
        {
            string categoryName = "";
            string sql = string.Concat("SELECT CategoryName, BusinessName FROM Businesses WHERE LocalBusiness = 1 and BusinessName = '", Business.Replace("'", "''"), "'");
            if (autoCategorizeOnly)
            {
                sql = string.Concat(sql, " and AutoCategorize = 1");
            }
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            categoryName = sqlDataReader["CategoryName"].ToString();
                        }
                    }
                }
            }
            return categoryName;
        }

        public static List<Business> Businesses(string businessType)
        {
            List<Business> Businesses = new List<Business>();
            string sql = "select * from Businesses";
            //string str1 = BusinessType;
            //string str2 = str1;
            if (businessType != null)
            {
                if (businessType == "Local Businesses *")
                {
                    sql = string.Concat(sql, " where LocalBusiness = 1");
                }
                else if (businessType == "National Businesses *")
                {
                    sql = string.Concat(sql, " where LocalBusiness = 0");
                }
            }
            sql = string.Concat(sql, " order by BusinessName");
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            Business Business = new Business()
                            {
                                BusinessName = sqlDataReader["BusinessName"].ToString(),
                                CategoryName = sqlDataReader["CategoryName"].ToString(),
                                AutoCategorize = Convert.ToBoolean(sqlDataReader["AutoCategorize"].ToString()),
                                IsLocalBusiness = Convert.ToBoolean(sqlDataReader["LocalBusiness"].ToString()),
                                BusinessID = Convert.ToInt32(sqlDataReader["BusinessID"].ToString())
                            };
                            Businesses.Add(Business);
                        }
                    }
                }
            }
            return Businesses;
        }

        public static string GetCategoryName(string BusinessName, List<Business> Businesses)
        {
            string categoryName = "";
            foreach (Business Business in Businesses)
            {
                if (!BusinessName.Contains(Business.BusinessName))
                {
                    continue;
                }
                categoryName = Business.CategoryName;
            }
            return categoryName;
        }

        public static List<Business> NationalBusinesses()
        {
            List<Business> Businesses = new List<Business>();
            string str = "SELECT BusinessName, CategoryName FROM Businesses where LocalBusiness = 0 and AutoCategorize = 1 order by BusinessName";
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            Business business = new Business()
                            {
                                BusinessName = sqlDataReader["BusinessName"].ToString(),
                                CategoryName = sqlDataReader["CategoryName"].ToString()
                            };
                            Businesses.Add(business);
                        }
                    }
                }
            }
            return Businesses;
        }

        public static void UpdateBusiness(int BusinessID, string BusinessName, string categoryName, bool autoCategorize, bool localBusiness)
        {
            string sql = string.Concat("update Businesses set BusinessName = '", BusinessName.Replace("'", "''"), "', AutoCategorize = ", autoCategorize ? "1" : "0", ", LocalBusiness = ", localBusiness ? "1" : "0" );
            sql = (!string.IsNullOrEmpty(categoryName) ? string.Concat(sql, ", CategoryName = '", categoryName, "'") : string.Concat(sql, ", CategoryName = null"));
            sql = string.Concat(sql, " where BusinessID = ", Convert.ToString(BusinessID));
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
            if (autoCategorize)
            {
                sql = string.Concat("update OriginalTransaction set CategoryName = '", categoryName, "' where Business = '", BusinessName, "'" );
                using (SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
                {
                    sqlConnection1.Open();
                    using (SqlCommand sqlCommand1 = new SqlCommand(sql, sqlConnection1))
                    {
                        sqlCommand1.ExecuteNonQuery();
                    }
                }
                Business.UpdateTransactionCategories(BusinessName, categoryName);
            }
        }

        internal static void UpdateBusinesses(Category category, string oldCategoryName)
        {
            string sql = string.Concat("update Businesses set CategoryName = '", category.CategoryName, "' where CategoryName = '", oldCategoryName, "'");
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        internal static void UpdateTransactionCategories(string BusinessName, string categoryName)
        {
            string sql = string.Concat("update OriginalTransaction set categoryname = '", categoryName, "' where OriginalTransactionID in (select OriginalTransactionID from OriginalTransaction where Business = '", BusinessName, "')");
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