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

        public void WithdrawMoney(decimal money)
        {
            if (money < Balance)
            {
                Balance = Balance - money;
                Console.WriteLine("You have successfully withdrawn {0:F2}.", money.ToString());
            }
            else
            {
                throw new ArgumentException("You don't have that amount of money, try again.");
            }
        }

        public override void DepositMoney(decimal money)
        {
            base.DepositMoney(money);
        }
        
    }
}
