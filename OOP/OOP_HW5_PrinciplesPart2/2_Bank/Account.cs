using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Bank
{
    abstract class Account
    {
        private Customer customer;
        private decimal balance;
        private decimal interest;

        public Account(Customer customer, decimal balance, decimal interest)
        {
            this.customer = customer;
            this.balance = balance;
            this.interest = interest;
        }

        #region Properties
        public Customer Customer
        {
            get { return this.customer; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public decimal Interest
        {
            get { return this.interest; }
            set { this.interest = value; }
        }
        #endregion

        public virtual decimal CalculateInterest(decimal months)
        {
            if (months < 0)
            {
                return 0;
            }
            return months * this.Interest;
        }
    }
}
