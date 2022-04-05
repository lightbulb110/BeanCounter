using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BeanCounter.BusinessLogic
{
    public class Category
    {
        public string CategoryName;

        public string Type;

        public string Frequency;

        public int DayOfMonth = 1;

        public int CategoryID;

        public DateTime SpecificDate;

        public DateTime NextOccurance;

        public DateTime EndDate;

        public decimal StaticAmount;

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

        public bool ExcludeFromBudget;

        public Category()
        {
        }

        private static Category AddMonthlyAmounts(Category category, SqlDataReader myDataReader)
        {
            if (!string.IsNullOrEmpty(myDataReader["c1"].ToString()))
            {
                category.C1 = Convert.ToDecimal(myDataReader["c1"].ToString());
            }
            if (!string.IsNullOrEmpty(myDataReader["c2"].ToString()))
            {
                category.C2 = Convert.ToDecimal(myDataReader["c2"].ToString());
            }
            if (!string.IsNullOrEmpty(myDataReader["c3"].ToString()))
            {
                category.C3 = Convert.ToDecimal(myDataReader["c3"].ToString());
            }
            if (!string.IsNullOrEmpty(myDataReader["c4"].ToString()))
            {
                category.C4 = Convert.ToDecimal(myDataReader["c4"].ToString());
            }
            if (!string.IsNullOrEmpty(myDataReader["c5"].ToString()))
            {
                category.C5 = Convert.ToDecimal(myDataReader["c5"].ToString());
            }
            if (!string.IsNullOrEmpty(myDataReader["c6"].ToString()))
            {
                category.C6 = Convert.ToDecimal(myDataReader["c6"].ToString());
            }
            if (!string.IsNullOrEmpty(myDataReader["c7"].ToString()))
            {
                category.C7 = Convert.ToDecimal(myDataReader["c7"].ToString());
            }
            if (!string.IsNullOrEmpty(myDataReader["c8"].ToString()))
            {
                category.C8 = Convert.ToDecimal(myDataReader["c8"].ToString());
            }
            if (!string.IsNullOrEmpty(myDataReader["c9"].ToString()))
            {
                category.C9 = Convert.ToDecimal(myDataReader["c9"].ToString());
            }
            if (!string.IsNullOrEmpty(myDataReader["c10"].ToString()))
            {
                category.C10 = Convert.ToDecimal(myDataReader["c10"].ToString());
            }
            if (!string.IsNullOrEmpty(myDataReader["c11"].ToString()))
            {
                category.C11 = Convert.ToDecimal(myDataReader["c11"].ToString());
            }
            if (!string.IsNullOrEmpty(myDataReader["c12"].ToString()))
            {
                category.C12 = Convert.ToDecimal(myDataReader["c12"].ToString());
            }
            return category;
        }

        private static string AddMonthlyColumns(Category category)
        {
            string str = string.Concat("", ", c1");
            str = string.Concat(str, ", c2");
            str = string.Concat(str, ", c3");
            str = string.Concat(str, ", c4");
            str = string.Concat(str, ", c5");
            str = string.Concat(str, ", c6");
            str = string.Concat(str, ", c7");
            str = string.Concat(str, ", c8");
            str = string.Concat(str, ", c9");
            str = string.Concat(str, ", c10");
            return string.Concat(string.Concat(str, ", c11"), ", c12");
        }

        private static string AddMonthlyValues(Category category)
        {
            string str = "";
            str = string.Concat(str, ", ", Convert.ToString(category.C1));
            str = string.Concat(str, ", ", Convert.ToString(category.C2));
            str = string.Concat(str, ", ", Convert.ToString(category.C3));
            str = string.Concat(str, ", ", Convert.ToString(category.C4));
            str = string.Concat(str, ", ", Convert.ToString(category.C5));
            str = string.Concat(str, ", ", Convert.ToString(category.C6));
            str = string.Concat(str, ", ", Convert.ToString(category.C7));
            str = string.Concat(str, ", ", Convert.ToString(category.C8));
            str = string.Concat(str, ", ", Convert.ToString(category.C9));
            str = string.Concat(str, ", ", Convert.ToString(category.C10));
            str = string.Concat(str, ", ", Convert.ToString(category.C11));
            str = string.Concat(str, ", ", Convert.ToString(category.C12));
            return str;
        }

        private static string AddMonthsUpdate(Category category)
        {
            string str = "";
            str = string.Concat(str, ", c1 = ", Convert.ToString(category.C1));
            str = string.Concat(str, ", c2 = ", Convert.ToString(category.C2));
            str = string.Concat(str, ", c3 = ", Convert.ToString(category.C3));
            str = string.Concat(str, ", c4 = ", Convert.ToString(category.C4));
            str = string.Concat(str, ", c5 = ", Convert.ToString(category.C5));
            str = string.Concat(str, ", c6 = ", Convert.ToString(category.C6));
            str = string.Concat(str, ", c7 = ", Convert.ToString(category.C7));
            str = string.Concat(str, ", c8 = ", Convert.ToString(category.C8));
            str = string.Concat(str, ", c9 = ", Convert.ToString(category.C9));
            str = string.Concat(str, ", c10 = ", Convert.ToString(category.C10));
            str = string.Concat(str, ", c11 = ", Convert.ToString(category.C11));
            str = string.Concat(str, ", c12 = ", Convert.ToString(category.C12));
            return str;
        }

        public static List<Category> Categories(string type, string frequency, bool upcoming)
        {
            List<Category> categories;
            List<Category> categories1 = new List<Category>();
            string[] strArrays = new string[] { "select * from Category where Type = '", type, "' and Frequency = '", frequency, "'" };
            string str = string.Concat(strArrays);
            string str1 = frequency;
            string str2 = str1;
            if (str1 != null)
            {
                if (str2 == "Annually" || str2 == "One Time")
                {
                    str = string.Concat(str, " order by ExcludeFromBudget desc, SpecificDate, CategoryName, CategoryID");
                    goto Label0;
                }
                else
                {
                    if (str2 != "Monthly")
                    {
                        goto Label2;
                    }
                    if (!upcoming)
                    {
                        str = string.Concat(str, " order by ExcludeFromBudget desc, CategoryName, CategoryID");
                        goto Label0;
                    }
                    else
                    {
                        str = string.Concat(str, " order by ExcludeFromBudget desc, DayOfMonth");
                        goto Label0;
                    }
                }
            }
        Label2:
            str = string.Concat(str, " order by ExcludeFromBudget desc, CategoryName, CategoryID");
        Label0:
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            Category category = new Category()
                            {
                                CategoryName = sqlDataReader["CategoryName"].ToString(),
                                CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"].ToString())
                            };
                            string str4 = frequency;
                            string str5 = str4;
                            if (str4 != null)
                            {
                                if (str5 == "Annually" || str5 == "One Time")
                                {
                                    if (!string.IsNullOrEmpty(sqlDataReader["SpecificDate"].ToString()))
                                    {
                                        category.SpecificDate = Convert.ToDateTime(sqlDataReader["SpecificDate"].ToString());
                                    }
                                    if (!string.IsNullOrEmpty(sqlDataReader["StaticAmount"].ToString()))
                                    {
                                        category.StaticAmount = Convert.ToDecimal(sqlDataReader["StaticAmount"].ToString());
                                    }
                                }
                                else if (str5 == "Anytime")
                                {
                                    category = Category.AddMonthlyAmounts(category, sqlDataReader);
                                }
                                else if (str5 == "Bi-Weekly" || str5 == "Weekly")
                                {
                                    if (!string.IsNullOrEmpty(sqlDataReader["StaticAmount"].ToString()))
                                    {
                                        category.StaticAmount = Convert.ToDecimal(sqlDataReader["StaticAmount"].ToString());
                                    }
                                    if (!string.IsNullOrEmpty(sqlDataReader["NextOccurance"].ToString()) && Category.IsDate(sqlDataReader["NextOccurance"].ToString()))
                                    {
                                        category.NextOccurance = Convert.ToDateTime(sqlDataReader["NextOccurance"].ToString());
                                    }
                                    if (!string.IsNullOrEmpty(sqlDataReader["EndDate"].ToString()) && Category.IsDate(sqlDataReader["EndDate"].ToString()))
                                    {
                                        category.EndDate = Convert.ToDateTime(sqlDataReader["EndDate"].ToString());
                                    }
                                    if (category.NextOccurance < DateTime.Today)
                                    {
                                        while (category.NextOccurance < DateTime.Today)
                                        {
                                            string str6 = frequency;
                                            string str7 = str6;
                                            if (str6 == null)
                                            {
                                                continue;
                                            }
                                            if (str7 == "Bi-Weekly")
                                            {
                                                category.NextOccurance = category.NextOccurance.AddDays(14);
                                            }
                                            else if (str7 == "Weekly")
                                            {
                                                category.NextOccurance = category.NextOccurance.AddDays(7);
                                            }
                                        }
                                        Category.UpdateNextOccurance(category.CategoryID, category.NextOccurance);
                                    }
                                }
                                else if (str5 == "Monthly")
                                {
                                    if (!string.IsNullOrEmpty(sqlDataReader["DayOfMonth"].ToString()))
                                    {
                                        category.DayOfMonth = Convert.ToInt32(sqlDataReader["DayOfMonth"].ToString());
                                    }
                                    category = Category.AddMonthlyAmounts(category, sqlDataReader);
                                }
                            }
                            category.ExcludeFromBudget = Convert.ToBoolean(sqlDataReader["ExcludeFromBudget"].ToString());
                            categories1.Add(category);
                        }
                    }
                }
                categories = categories1;
            }
            return categories;
        }

        public static List<Category> Categories(string categoryName)
        {
            List<Category> categories;
            string str = string.Concat("select * from Category where CategoryName = '", categoryName, "' order by CategoryName, CategoryID");
            List<Category> categories1 = new List<Category>();
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            Category category = new Category();
                            if (sqlDataReader["c1"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c1"].ToString()))
                            {
                                category.C1 = Convert.ToDecimal(sqlDataReader["c1"].ToString());
                            }
                            if (sqlDataReader["c2"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c2"].ToString()))
                            {
                                category.C2 = Convert.ToDecimal(sqlDataReader["c2"].ToString());
                            }
                            if (sqlDataReader["c3"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c3"].ToString()))
                            {
                                category.C3 = Convert.ToDecimal(sqlDataReader["c3"].ToString());
                            }
                            if (sqlDataReader["c4"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c4"].ToString()))
                            {
                                category.C4 = Convert.ToDecimal(sqlDataReader["c4"].ToString());
                            }
                            if (sqlDataReader["c5"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c5"].ToString()))
                            {
                                category.C5 = Convert.ToDecimal(sqlDataReader["c5"].ToString());
                            }
                            if (sqlDataReader["c6"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c6"].ToString()))
                            {
                                category.C6 = Convert.ToDecimal(sqlDataReader["c6"].ToString());
                            }
                            if (sqlDataReader["c7"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c7"].ToString()))
                            {
                                category.C7 = Convert.ToDecimal(sqlDataReader["c7"].ToString());
                            }
                            if (sqlDataReader["c8"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c8"].ToString()))
                            {
                                category.C8 = Convert.ToDecimal(sqlDataReader["c8"].ToString());
                            }
                            if (sqlDataReader["c9"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c9"].ToString()))
                            {
                                category.C9 = Convert.ToDecimal(sqlDataReader["c9"].ToString());
                            }
                            if (sqlDataReader["c10"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c10"].ToString()))
                            {
                                category.C10 = Convert.ToDecimal(sqlDataReader["c10"].ToString());
                            }
                            if (sqlDataReader["c11"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c11"].ToString()))
                            {
                                category.C11 = Convert.ToDecimal(sqlDataReader["c11"].ToString());
                            }
                            if (sqlDataReader["c12"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c12"].ToString()))
                            {
                                category.C12 = Convert.ToDecimal(sqlDataReader["c12"].ToString());
                            }
                            categories1.Add(category);
                        }
                    }
                }
                categories = categories1;
            }
            return categories;
        }

        public static bool CategoryExists(int categoryID)
        {
            bool flag = false;
            string str = string.Concat("select CategoryID from Category where CategoryID = ", Convert.ToString(categoryID));
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }

        public static IEnumerable<string> CategoryNames()
        {
            IEnumerable<string> strs;
            List<string> strs1 = new List<string>();
            string str = "select distinct CategoryName from Category order by CategoryName";
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            strs1.Add(sqlDataReader["CategoryName"].ToString());
                        }
                    }
                }
                strs = strs1;
            }
            return strs;
        }

        public static void DeleteCategory(int categoryID)
        {
            string str = string.Concat("delete from Category where CategoryID = ", Convert.ToInt32(categoryID));
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public static Category FindCategory(int categoryID)
        {
            Category category;
            string str = string.Concat("select * from Category where CategoryID = ", categoryID);
            Category num = new Category();
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            if (sqlDataReader["c1"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c1"].ToString()))
                            {
                                num.C1 = Convert.ToDecimal(sqlDataReader["c1"].ToString());
                            }
                            if (sqlDataReader["c2"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c2"].ToString()))
                            {
                                num.C2 = Convert.ToDecimal(sqlDataReader["c2"].ToString());
                            }
                            if (sqlDataReader["c3"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c3"].ToString()))
                            {
                                num.C3 = Convert.ToDecimal(sqlDataReader["c3"].ToString());
                            }
                            if (sqlDataReader["c4"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c4"].ToString()))
                            {
                                num.C4 = Convert.ToDecimal(sqlDataReader["c4"].ToString());
                            }
                            if (sqlDataReader["c5"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c5"].ToString()))
                            {
                                num.C5 = Convert.ToDecimal(sqlDataReader["c5"].ToString());
                            }
                            if (sqlDataReader["c6"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c6"].ToString()))
                            {
                                num.C6 = Convert.ToDecimal(sqlDataReader["c6"].ToString());
                            }
                            if (sqlDataReader["c7"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c7"].ToString()))
                            {
                                num.C7 = Convert.ToDecimal(sqlDataReader["c7"].ToString());
                            }
                            if (sqlDataReader["c8"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c8"].ToString()))
                            {
                                num.C8 = Convert.ToDecimal(sqlDataReader["c8"].ToString());
                            }
                            if (sqlDataReader["c9"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c9"].ToString()))
                            {
                                num.C9 = Convert.ToDecimal(sqlDataReader["c9"].ToString());
                            }
                            if (sqlDataReader["c10"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c10"].ToString()))
                            {
                                num.C10 = Convert.ToDecimal(sqlDataReader["c10"].ToString());
                            }
                            if (sqlDataReader["c11"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c11"].ToString()))
                            {
                                num.C11 = Convert.ToDecimal(sqlDataReader["c11"].ToString());
                            }
                            if (sqlDataReader["c12"].ToString() != null && !string.IsNullOrEmpty(sqlDataReader["c12"].ToString()))
                            {
                                num.C12 = Convert.ToDecimal(sqlDataReader["c12"].ToString());
                            }
                        }
                    }
                }
                category = num;
            }
            return category;
        }

        private static string GetCategoryName(int categoryID)
        {
            string categoryName = string.Empty;
            string sql = string.Concat("select CategoryName from Category where CategoryID = ", Convert.ToString(categoryID));
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
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

        public static int InsertCategory(Category category)
        {
            int num = 0;
            string str = "";
            if (category.CategoryName != null)
            {
                str = "insert into Category (ExcludeFromBudget, CategoryName";
                string frequency = category.Frequency;
                string str1 = frequency;
                if (frequency != null)
                {
                    if (str1 == "Annually" || str1 == "One Time")
                    {
                        str = string.Concat(str, ", StaticAmount");
                        str = string.Concat(str, ", SpecificDate");
                    }
                    else if (str1 == "Anytime")
                    {
                        str = string.Concat(str, Category.AddMonthlyColumns(category));
                    }
                    else if (str1 == "Bi-Weekly" || str1 == "Weekly")
                    {
                        str = string.Concat(str, ", StaticAmount, NextOccurance");
                        if (category.EndDate != new DateTime())
                        {
                            str = string.Concat(str, ", EndDate");
                        }
                    }
                    else if (str1 == "Monthly")
                    {
                        str = string.Concat(str, Category.AddMonthlyColumns(category));
                        str = string.Concat(str, ", DayOfMonth");
                    }
                }
                str = string.Concat(str, ", Type, Frequency) values( '0', '", category.CategoryName, "'");
                string frequency1 = category.Frequency;
                string str2 = frequency1;
                if (frequency1 != null)
                {
                    if (str2 == "Annually" || str2 == "One Time")
                    {
                        str = string.Concat(str, ", ", category.StaticAmount);
                        object obj = str;
                        object[] specificDate = new object[] { obj, ", '", category.SpecificDate, "'" };
                        str = string.Concat(specificDate);
                    }
                    else if (str2 == "Anytime")
                    {
                        str = string.Concat(str, Category.AddMonthlyValues(category));
                    }
                    else if (str2 == "Bi-Weekly" || str2 == "Weekly")
                    {
                        object obj1 = str;
                        object[] staticAmount = new object[] { obj1, ", ", category.StaticAmount, ", '", category.NextOccurance, "'" };
                        str = string.Concat(staticAmount);
                        if (category.EndDate != new DateTime())
                        {
                            object obj2 = str;
                            object[] endDate = new object[] { obj2, ", '", category.EndDate, "'" };
                            str = string.Concat(endDate);
                        }
                    }
                    else if (str2 == "Monthly")
                    {
                        str = string.Concat(str, Category.AddMonthlyValues(category));
                        str = string.Concat(str, ", ", category.DayOfMonth);
                    }
                }
                string str3 = str;
                string[] type = new string[] { str3, ", '", category.Type, "', '", category.Frequency, "')" };
                str = string.Concat(type);
            }
            string str4 = ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString();
            using (SqlConnection sqlConnection = new SqlConnection(str4))
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

        public static bool IsUsed(string categoryName)
        {
            bool flag = false;
            string str = string.Concat("select * from SplitTransaction where CategoryName = '", categoryName, "'");
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }

        internal static DateTime NextOccuranceLookup(int categoryID)
        {
            string str = string.Concat("select NextOccurance from Category where CategoryID = ", categoryID, " order by NextOccurance desc");
            DateTime dateTime = new DateTime();
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read() && sqlDataReader["NextOccurance"].ToString() != null)
                        {
                            dateTime = Convert.ToDateTime(sqlDataReader["NextOccurance"].ToString());
                        }
                    }
                }
            }
            return dateTime;
        }

        internal static List<Category> StaticAmountCategories(string type, string frequency)
        {
            string[] strArrays = new string[] { "select CategoryID, CategoryName, StaticAmount, SpecificDate, NextOccurance, EndDate from Category where Type = '", type, "'  and Frequency = '", frequency, "' and ExcludeFromBudget = 0" };
            string str = string.Concat(strArrays);
            List<Category> categories = new List<Category>();
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            Category category = new Category()
                            {
                                CategoryName = sqlDataReader["CategoryName"].ToString(),
                                CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"].ToString())
                            };
                            if (sqlDataReader["StaticAmount"].ToString() != null && Category.IsNumber(sqlDataReader["StaticAmount"].ToString()))
                            {
                                category.StaticAmount = Convert.ToDecimal(sqlDataReader["StaticAmount"].ToString());
                            }
                            if (sqlDataReader["SpecificDate"].ToString() != null && Category.IsDate(sqlDataReader["SpecificDate"].ToString()))
                            {
                                category.SpecificDate = Convert.ToDateTime(sqlDataReader["SpecificDate"].ToString());
                            }
                            if (sqlDataReader["NextOccurance"].ToString() != null && Category.IsDate(sqlDataReader["NextOccurance"].ToString()))
                            {
                                category.NextOccurance = Convert.ToDateTime(sqlDataReader["NextOccurance"].ToString());
                            }
                            if (sqlDataReader["EndDate"].ToString() != null && Category.IsDate(sqlDataReader["EndDate"].ToString()))
                            {
                                category.EndDate = Convert.ToDateTime(sqlDataReader["EndDate"].ToString());
                            }
                            categories.Add(category);
                        }
                    }
                }
            }
            return categories;
        }

        public static void UpdateCategory(Category category)
        {
            string str = Category.GetCategoryName(category.CategoryID);
            Category.UpdateCategoryTable(category);
            if (str != category.CategoryName)
            {
                Category.UpdateOriginalTransactions(category, str);
                Category.UpdateSplitTransactions(category, str);
                Business.UpdateBusinesses(category, str);
            }
        }

        private static void UpdateCategoryTable(Category category)
        {
            string str = string.Concat("update Category set CategoryName = '", category.CategoryName, "'");
            string frequency = category.Frequency;
            string str1 = frequency;
            if (frequency != null)
            {
                if (str1 == "Annually" || str1 == "One Time")
                {
                    str = string.Concat(str, ", StaticAmount = ", category.StaticAmount);
                    if (category.SpecificDate != new DateTime(1, 1, 1))
                    {
                        object obj = str;
                        object[] specificDate = new object[] { obj, ", SpecificDate = '", category.SpecificDate, "'" };
                        str = string.Concat(specificDate);
                    }
                }
                else if (str1 == "Anytime")
                {
                    str = string.Concat(str, Category.AddMonthsUpdate(category));
                }
                else if (str1 == "Bi-Weekly" || str1 == "Weekly")
                {
                    str = string.Concat(str, ", StaticAmount = ", category.StaticAmount);
                    object obj1 = str;
                    object[] nextOccurance = new object[] { obj1, ", NextOccurance = '", category.NextOccurance, "'" };
                    str = string.Concat(nextOccurance);
                    if (category.NextOccurance != new DateTime())
                    {
                        if (category.EndDate != new DateTime())
                        {
                            object obj2 = str;
                            object[] endDate = new object[] { obj2, ", EndDate = '", category.EndDate, "'" };
                            str = string.Concat(endDate);
                        }
                    }
                }
                else if (str1 == "Monthly")
                {
                    str = string.Concat(str, Category.AddMonthsUpdate(category));
                    str = string.Concat(str, ", DayOfMonth = ", category.DayOfMonth);
                }
            }
            str = string.Concat(str, ", ExcludeFromBudget = ", category.ExcludeFromBudget ? "1" : "0");
            str = string.Concat(str, " where CategoryID = ", Convert.ToString(category.CategoryID));
            string str2 = ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString();
            using (SqlConnection sqlConnection = new SqlConnection(str2))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        internal static void UpdateNextOccurance(int categoryID, DateTime nextOccuranceUpdate)
        {
            string str = string.Concat("update Category set NextOccurance = '", nextOccuranceUpdate, "'");
            str = string.Concat(str, " where CategoryID = ", Convert.ToString(categoryID));
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        private static void UpdateOriginalTransactions(Category category, string oldCategoryName)
        {
            string[] categoryName = new string[] { "update OriginalTransaction set CategoryName = '", category.CategoryName, "' where CategoryName = '", oldCategoryName, "'" };
            string str = string.Concat(categoryName);
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateSpecificDate(DateTime datePosted, int categoryID)
        {
            object[] objArray = new object[] { "update Category set SpecificDate = '", datePosted, "' where CategoryID = ", Convert.ToString(categoryID) };
            string str = string.Concat(objArray);
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(str, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        private static void UpdateSplitTransactions(Category category, string oldCategoryName)
        {
            string[] categoryName = new string[] { "update SplitTransaction set CategoryName = '", category.CategoryName, "' where CategoryName = '", oldCategoryName, "'" };
            string str = string.Concat(categoryName);
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