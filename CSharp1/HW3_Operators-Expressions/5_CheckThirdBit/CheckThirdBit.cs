using System;

    class CheckThirdBit
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int mask = 1;
            mask = mask << 3;
            int result = number & mask;
            if (result > 0)
            {
                Console.WriteLine("Third bit is {0}", 1);
            }
            else
            {
                Console.WriteLine("Third bit is {0}", 0);
            }
        }
    }

