using System;
using System.Collections.Generic;

namespace _2_Bank
{
    class TestClass
    {
        static void Main(string[] args)
        {
            //Loan l = new Loan(new Individual("Joro"), 25.5m, 0.05m);
            //Loan l2 = new Loan(new Company("HP"), 2000000m, 0.23m);
            //l.CalculateInterest(10);
            //l2.CalculateInterest(20);
            //Mortgage m = new Mortgage(new Individual("Pencho"), 1000m, 0.1m);
            //for (int i = 0; i < 20; i++)
            //{
            //    Console.WriteLine("{0:F2}", m.CalculateInterest(i));
            //}
            Bank randomBank = new Bank();

            Deposit d = new Deposit(new Individual("Pesho"), 1000m, 8m);
            Loan l = new Loan(new Company("SevenNights"), 10000m, 0.04m);
            Mortgage m = new Mortgage(new Individual("Mariika"), 20000m, 0.3m);
            randomBank.AddAccount(d);
            randomBank.AddAccount(l);
            randomBank.AddAccount(m);

            randomBank.PrintAccountsInterest(20);

        }
    }
}
