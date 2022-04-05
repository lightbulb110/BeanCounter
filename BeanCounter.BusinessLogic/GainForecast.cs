using System;

namespace BeanCounter.BusinessLogic
{
    public class GainForecast : CashForecast
    {
        public GainForecast(CashForecast cashForecast)
        {
            this.C1 = cashForecast._IncomeForecast.C1 - cashForecast._SpendingForecast.C1;
            this.C2 = cashForecast._IncomeForecast.C2 - cashForecast._SpendingForecast.C2;
            this.C3 = cashForecast._IncomeForecast.C3 - cashForecast._SpendingForecast.C3;
            this.C4 = cashForecast._IncomeForecast.C4 - cashForecast._SpendingForecast.C4;
            this.C5 = cashForecast._IncomeForecast.C5 - cashForecast._SpendingForecast.C5;
            this.C6 = cashForecast._IncomeForecast.C6 - cashForecast._SpendingForecast.C6;
            this.C7 = cashForecast._IncomeForecast.C7 - cashForecast._SpendingForecast.C7;
            this.C8 = cashForecast._IncomeForecast.C8 - cashForecast._SpendingForecast.C8;
            this.C9 = cashForecast._IncomeForecast.C9 - cashForecast._SpendingForecast.C9;
            this.C10 = cashForecast._IncomeForecast.C10 - cashForecast._SpendingForecast.C10;
            this.C11 = cashForecast._IncomeForecast.C11 - cashForecast._SpendingForecast.C11;
            this.C12 = cashForecast._IncomeForecast.C12 - cashForecast._SpendingForecast.C12;
            this.C13 = cashForecast._IncomeForecast.C13 - cashForecast._SpendingForecast.C13;
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