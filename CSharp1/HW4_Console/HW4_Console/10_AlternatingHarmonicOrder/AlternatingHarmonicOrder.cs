using System;

    class AlternatingHarmonicOrder
    {
        static void Main()
        {
            decimal result = 1M;
            decimal oldResult = 1M;
            decimal iter = 2;
            decimal sumDifference;

            do
            {
                oldResult = result;
                if (iter % 2 == 0)
                {
                    result += ((decimal)1 / iter);
                }
                else
                {
                    result -= ((decimal)1 / iter);
                }
                iter++;
                sumDifference = (decimal)Math.Abs(result - oldResult);
            } while (sumDifference >= 0.001M);
            Console.WriteLine(result);
        }
    }
