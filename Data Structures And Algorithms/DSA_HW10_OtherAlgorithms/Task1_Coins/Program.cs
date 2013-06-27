using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task1_Coins
{
    public static class Program
    {
        private static int[] coins = new int[] { 5, 2, 1 };
        private static OrderedBag<int> usedCoins = new OrderedBag<int>((a, b) => -a.CompareTo(b));
        private static int originalNum = 33;

        private static string CalculateCoins(int num)
        {
            foreach (int coin in coins)
            {
                if (num >= coin)
                {
                    usedCoins.Add(coin);
                    return CalculateCoins(num - coin);
                }
            }

            return string.Format("N = {0} => {1}", originalNum, string.Join(" + ", usedCoins
                .DistinctItems()
                .Select(x => new {Coin = x, Count = usedCoins.NumberOfCopies(x)})
                .Select(x => string.Format("{0} {1} x {2}", 
                    x.Count, (x.Count == 1 ? "coin" : "coins"), x.Coin))));
        }

        public static void Main()
        {
            //int target = int.Parse(Console.ReadLine());
            int target = 33;
            Console.WriteLine(CalculateCoins(target));
        }
    }
}
