using System;

    class CheckPrime
    {
        static bool IsPrime(int num)
        {
            if (num == 1)
            {
                return true;
            }
            if (num % 2 == 0)
            {
                return false;
            }
            for (int i = 3; i < Math.Sqrt(num); i+=2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Is it prime? {0}", IsPrime(number) ? true : false);
        }
    }

