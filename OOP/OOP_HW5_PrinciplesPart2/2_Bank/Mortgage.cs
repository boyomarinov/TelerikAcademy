using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Bank
{
    class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        { }

        public override decimal CalculateInterest(decimal months)
        {
            if (this.Customer is Company)
            {
                return base.CalculateInterest(Math.Min(months, 12) / 2 + Math.Max(months - 12, 0));
            }
            else
            {
                return base.CalculateInterest(months - 6);
            }
        }
    }
}
