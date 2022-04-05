using System;

namespace BeanCounter.BusinessLogic
{
    public class BalanceForecast : CashForecast
    {
        public BalanceForecast(decimal currentBalance, CashForecast cashForecast)
        {
            for (int i = DateTime.Today.Month + 1; i < 13; i++)
            {
                currentBalance = this.CalculateBalance(currentBalance, i, cashForecast);
                this.UpdateBalance(currentBalance, i);
            }
            for (int j = 1; j < DateTime.Today.Month + 1; j++)
            {
                currentBalance = this.CalculateBalance(currentBalance, j, cashForecast);
                this.UpdateBalance(currentBalance, j);
            }
        }

        private decimal CalculateBalance(decimal currentBalance, int month, CashForecast cashForecast)
        {
            GainForecast gainForecast = cashForecast._GainForecast;
            switch (month)
            {
                case 1:
                    currentBalance += gainForecast.C12;
                    break;
                case 2:
                    currentBalance += gainForecast.C1;
                    break;
                case 3:
                    currentBalance += gainForecast.C2;
                    break;
                case 4:
                    currentBalance += gainForecast.C3;
                    break;
                case 5:
                    currentBalance += gainForecast.C4;
                    break;
                case 6:
                    currentBalance += gainForecast.C5;
                    break;
                case 7:
                    currentBalance += gainForecast.C6;
                    break;
                case 8:
                    currentBalance += gainForecast.C7;
                    break;
                case 9:
                    currentBalance += gainForecast.C8;
                    break;
                case 10:
                    currentBalance += gainForecast.C9;
                    break;
                case 11:
                    currentBalance += gainForecast.C10;
                    break;
                case 12:
                    currentBalance += gainForecast.C11;
                    break;
            }
            return Math.Round(currentBalance, 0);
        }

        private void UpdateBalance(decimal currentBalance, int month)
        {
            switch (month)
            {
                case 1:
                    this.C1 = currentBalance;
                    return;
                case 2:
                    this.C2 = currentBalance;
                    return;
                case 3:
                    this.C3 = currentBalance;
                    return;
                case 4:
                    this.C4 = currentBalance;
                    return;
                case 5:
                    this.C5 = currentBalance;
                    return;
                case 6:
                    this.C6 = currentBalance;
                    return;
                case 7:
                    this.C7 = currentBalance;
                    return;
                case 8:
                    this.C8 = currentBalance;
                    return;
                case 9:
                    this.C9 = currentBalance;
                    return;
                case 10:
                    this.C10 = currentBalance;
                    return;
                case 11:
                    this.C11 = currentBalance;
                    return;
                case 12:
                    this.C12 = currentBalance;
                    return;
                default:
                    return;
            }
        }
    }
}