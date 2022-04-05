using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanCounter.BusinessLogic
{
    public class Options
    {
        public bool OverrideBalance;

        public decimal Balance;

        public bool AddOverages;

        public int Overages;

        public Options(bool overrideBalance, decimal balance, bool addOverages, int overages)
        {
            this.OverrideBalance = overrideBalance;
            this.Balance = balance;
            this.AddOverages = addOverages;
            this.Overages = overages;
        }

        public Options()
        {
        }
    }
}
