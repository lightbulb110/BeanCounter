using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BeanCounter.BusinessLogic
{
    public class DatabaseProperties
    {
        public DatabaseProperties()
        {
        }

        public static bool PasswordIsCorrect(string password)
        {
            bool flag = true;
            string str = ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString();
            if (!string.IsNullOrEmpty(password))
            {
                str = string.Concat(str, ";Database Password = '", password, "'");
            }
            using (SqlConnection sqlConnection = new SqlConnection(str))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch
                {
                    flag = false;
                }
            }
            return flag;
        }

        public static bool PasswordProtected()
        {
            bool flag = true;
            string str = ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString();
            using (SqlConnection sqlConnection = new SqlConnection(str))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch
                {
                    flag = false;
                }
            }
            return flag;
        }

        public static void SetPassword(string currentPassword, string newPassword, string confirmPassword)
        {
        }
    }
}