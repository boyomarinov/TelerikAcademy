using System;
using System.Collections.Generic;
using System.Linq;

class MissCat
{
    static void Main()
    {
        //initialize values
        int n;
        int temp;
        int[] catArray = new int[10];

        //read input
        n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            temp = int.Parse(Console.ReadLine());
            temp = temp - 1;
            catArray[temp]++;
        }
        
        //calculate result
        int max = -1;
        byte indexOfMax = 0;
        for (byte i = 0; i < 10; i++)
        {
            if (catArray[i] > max)
            {
                max = catArray[i];
                indexOfMax = i;
            }
        }
        indexOfMax++;
        Console.WriteLine(indexOfMax);
    }
}

