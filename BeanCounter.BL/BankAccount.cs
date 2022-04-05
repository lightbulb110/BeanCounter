using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanCounter.BL
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankFID { get; set; }
        public string AccountType { get; set; }
        public decimal OnlineBalance { get; set; }
        public decimal CreditLimit { get; set; }
        public string AccountName { get; set; }
        public string WebAddress { get; set; }
        public string RemoveFromBusiness { get; set; }
        public string RemoveFromBankMemo { get; set; }
        public bool ReverseFields { get; set; }
        public int BankAccountID { get; set; }

        public static void UpdateBalance(BankAccount bankAccount)
        {


        }
    }
}
