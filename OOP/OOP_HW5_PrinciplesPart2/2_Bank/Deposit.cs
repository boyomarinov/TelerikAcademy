using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Bank
{
    class Deposit : Account
    {
        public Deposit(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        { }

        public override decimal CalculateInterest(decimal months)
        {
            if (Balance > 0 && Balance < 1000)
            {
                return 0;
            }
            return base.CalculateInterest(months);
        }
    }
}
