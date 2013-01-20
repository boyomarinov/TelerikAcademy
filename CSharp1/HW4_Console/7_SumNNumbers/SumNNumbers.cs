using System;

class SumNNumbers
{
    static void Main()
    {
        Console.Write("Number of integers: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Input numbers (n1 n2 n3 ...): ");
        string[] res = Console.ReadLine().Split();
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            int temp = int.Parse(res[i]);
            sum += temp;
        }
        Console.WriteLine("Sum: {0}", sum);
    }
}

