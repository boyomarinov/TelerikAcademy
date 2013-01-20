using System;

    class DivideFactorials
    {
        static ulong DivideFact(int k, int n)
        {
            ulong result = 1;
            for (int i = k + 1; i <= n; i++)
            {
                result *= (ulong)i;
                Console.Write("{0} ", i);
                if (i != n)
                {
                    Console.Write("* ");
                }
            }
            Console.Write("= ");
            return result;
        }
        static void Main()
        {
            Console.WriteLine("Input K and N (1 < K < N): ");
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(DivideFact(k, n));
        }
    }

