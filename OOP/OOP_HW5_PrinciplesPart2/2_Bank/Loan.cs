using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Bank
{
    class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        { }

        public override decimal CalculateInterest(decimal months)
        {
            if (this.Customer is Company)
            {
                return base.CalculateInterest(months - 2);
            }
            else{
                return base.CalculateInterest(months - 3);
            }
        }
    }
}
