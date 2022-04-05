using System;

namespace BeanCounter.BusinessLogic
{
    public class CategoryTotal
    {
        public int Count;

        public decimal TransactionAmount;

        public CategoryTotal(int count, decimal transactionAmount)
        {
            this.Count = count;
            this.TransactionAmount = transactionAmount;
        }
    }
}