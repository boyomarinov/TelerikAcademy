using System;
using System.Collections.Generic;

namespace _2_Bank
{
    class Bank
    {
        private List<Account> accounts;

        public Bank()
        {
            this.accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            this.accounts.Add(account);
        }
        public void RemoveAccount(Account account)
        {
            this.accounts.Remove(account);
        }
        public void PrintAccountsInterest(decimal months)
        {
            foreach (var item in this.accounts)
            {
                Console.WriteLine(item.CalculateInterest(months));
            }
        }
    }
}
