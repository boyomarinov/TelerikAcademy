using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_KnapsackProblem
{
    public static class Program
    {
        private static int[,] DP = new int[512, 512];
        private static int[,] selected = new int[512, 512];


        private static int Knapsack(int index, int size, int[] weights, int[] values)
        {
            int takeItem = 0;
            int leaveItem = 0;

            //DP
            if (DP[index, size] != 0)
            {
                return DP[index, size];
            }

            //bottom
            if (index == 0)
            {
                if (weights[0] <= size)
                {
                    selected[index, size] = 1;
                    DP[index, size] = 0;
                    return 0;
                }
                else
                {
                    selected[index, size] = -1;
                    DP[index, size] = 0;
                    return 0;
                }
            }

            if (weights[index] <= size)
            {
                takeItem = values[index] + Knapsack(index - 1, size - weights[index], weights, values);
            }

            leaveItem = Knapsack(index - 1, size, weights, values);
            DP[index, size] = Math.Max(takeItem, leaveItem);

            if (takeItem > leaveItem)
            {
                selected[index, size] = 1;
            }
            else
            {
                selected[index, size] = -1;
            }

            return DP[index, size];
        }

        private static void PrintSelected(int currentItem, int knapsackSize, string[] names, int[] weights, int[] values)
        {
            while (currentItem >= 0)
            {
                if (selected[currentItem,knapsackSize] == 1)
                {
                    Console.WriteLine(names[currentItem] + ": " + values[currentItem]);
                    knapsackSize -= weights[currentItem--];
                }
                else
                {
                    currentItem--;
                }
            }

            Console.WriteLine();
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static void Main()
        {
            string[] names = new string[]{"beer", "vodka", "cheese", "nuts", "ham", "whiskey"};
            int[] weights = new int[]{3, 8, 4, 1, 2, 8};
            int[] values = new int[]{2, 12, 5, 4, 3, 13};
            const int knapsackSize = 10;

            Console.WriteLine("Targets: ");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("{0} weights:{1} costs:{2}", names[i], weights[i], values[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Bag size: {0}", knapsackSize);
            Console.WriteLine();

            int max = Knapsack(weights.Length - 1, knapsackSize, weights, values);
            Console.WriteLine("Max: " + max);

            PrintSelected(weights.Length - 1, knapsackSize, names, weights, values);
        }
    }
}
