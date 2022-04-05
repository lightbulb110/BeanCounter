using System;

namespace BeanCounter.BusinessLogic
{
    public class IncomeForecast : CashForecast
    {
        public IncomeForecast()
        {
            DateTime today = DateTime.Today;
            int num = Convert.ToInt32(today.ToString("yyyy"));
            this.C1 = CashForecast.BudgetAmount(1, num, "Income", new Options());
            this.C2 = CashForecast.BudgetAmount(2, num, "Income", new Options());
            this.C3 = CashForecast.BudgetAmount(3, num, "Income", new Options());
            this.C4 = CashForecast.BudgetAmount(4, num, "Income", new Options());
            this.C5 = CashForecast.BudgetAmount(5, num, "Income", new Options());
            this.C6 = CashForecast.BudgetAmount(6, num, "Income", new Options());
            this.C7 = CashForecast.BudgetAmount(7, num, "Income", new Options());
            this.C8 = CashForecast.BudgetAmount(8, num, "Income", new Options());
            this.C9 = CashForecast.BudgetAmount(9, num, "Income", new Options());
            this.C10 = CashForecast.BudgetAmount(10, num, "Income", new Options());
            this.C11 = CashForecast.BudgetAmount(11, num, "Income", new Options());
            this.C12 = CashForecast.BudgetAmount(12, num, "Income", new Options());
            DateTime dateTime = DateTime.Today;
            this.C13 = CashForecast.BudgetAmount(dateTime.Month, num + 1, "Income", new Options());
            this.Total = (((((((((((this.C1 + this.C2) + this.C3) + this.C4) + this.C5) + this.C6) + this.C7) + this.C8) + this.C9) + this.C10) + this.C11) + this.C12) + this.C13;
            this.Total = this.SubtractPartialMonth(this.Total);
            this.Average = Math.Round(this.Total / new decimal(12));
        }

        private decimal SubtractPartialMonth(decimal total)
        {
            if (DateTime.Today.Month == 1)
            {
                total -= this.C1;
            }
            if (DateTime.Today.Month == 2)
            {
                total -= this.C2;
            }
            if (DateTime.Today.Month == 3)
            {
                total -= this.C3;
            }
            if (DateTime.Today.Month == 4)
            {
                total -= this.C4;
            }
            if (DateTime.Today.Month == 5)
            {
                total -= this.C5;
            }
            if (DateTime.Today.Month == 6)
            {
                total -= this.C6;
            }
            if (DateTime.Today.Month == 7)
            {
                total -= this.C7;
            }
            if (DateTime.Today.Month == 8)
            {
                total -= this.C8;
            }
            if (DateTime.Today.Month == 9)
            {
                total -= this.C9;
            }
            if (DateTime.Today.Month == 10)
            {
                total -= this.C10;
            }
            if (DateTime.Today.Month == 11)
            {
                total -= this.C11;
            }
            if (DateTime.Today.Month == 12)
            {
                total -= this.C12;
            }
            return total;
        }
    }
}