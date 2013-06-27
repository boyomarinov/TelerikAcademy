using System;
using System.Collections.Generic;

namespace Task2_ReverseWithStack
{
    public static class ReverseWithStack
    {
        public static void Main()
        {
            Stack<int> input = new Stack<int>();
            Console.Write("N: ");
            int numbersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersCount; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                input.Push(inputNumber);
            }

            int stackSize = input.Count;
            for (int i = 0; i < stackSize; i++)
            {
                int nextPoppedElem = input.Pop();
                Console.Write(nextPoppedElem + " ");
            }
            Console.WriteLine();
        }
    }
}
