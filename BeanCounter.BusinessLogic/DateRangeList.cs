using System;

namespace BeanCounter.BusinessLogic
{
    public class DateRangeList
    {
        public DateTime StartDate = new DateTime();

        public DateTime EndDate;

        public DateRangeList(string dateRange)
        {
            string str = dateRange;
            string str1 = str;
            if (str != null)
            {
                if (str1 == "Month to date")
                {
                    int year = DateTime.Today.Year;
                    DateTime today = DateTime.Today;
                    this.StartDate = new DateTime(year, today.Month, 1);
                    DateTime dateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    DateTime dateTime1 = dateTime.AddMonths(1);
                    this.EndDate = dateTime1.AddDays(-1);
                    return;
                }
                if (str1 == "Last month")
                {
                    int num = DateTime.Today.AddMonths(-1).Year;
                    DateTime dateTime2 = DateTime.Today.AddMonths(-1);
                    this.StartDate = new DateTime(num, dateTime2.Month, 1);
                    int year1 = DateTime.Today.AddMonths(-1).Year;
                    DateTime dateTime3 = DateTime.Today.AddMonths(-1);
                    DateTime dateTime4 = new DateTime(year1, dateTime3.Month, 1);
                    DateTime dateTime5 = dateTime4.AddMonths(1);
                    this.EndDate = dateTime5.AddDays(-1);
                    return;
                }
                if (str1 == "Last 3 months")
                {
                    this.StartDate = DateTime.Today.AddMonths(-3);
                    this.EndDate = DateTime.Today;
                    return;
                }
                if (str1 == "Last 6 months")
                {
                    this.StartDate = DateTime.Today.AddMonths(-6);
                    this.EndDate = DateTime.Today;
                    return;
                }
                if (str1 != "Year to date")
                {
                    return;
                }
                DateTime today1 = DateTime.Today;
                this.StartDate = new DateTime(today1.Year, 1, 1);
                this.EndDate = DateTime.Today;
            }
        }
    }
}