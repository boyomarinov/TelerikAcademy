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
            Mortgage m = new Mortgage(new Individual("Pencho"), 100m, 0.1m);
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("{0:F2}", m.CalculateInterest(i));
            }
        }
    }
}
