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
            this.Customer = customer;
            this.Balance = balance;
            this.Interest = interest;
        }

        #region Properties
        public Customer Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
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

        public virtual void DepositMoney(decimal money)
        {
            if (money >= 0)
            {
                Balance = Balance + money;
                Console.WriteLine("You have successfully deposited {0:F2}.", money.ToString());
            }
            else
            {
                throw new ArgumentOutOfRangeException("You cannot deposit negative amount of money");
            }
        }

        
    }
}
