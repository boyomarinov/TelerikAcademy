using System;

class ArrayMode
{
    static int[] FindMode(int[] arr, int size)
    {
        int[] helper = new int[size];
        int[] res = new int[2];
        for (int i = 0; i < size; i++)
        {
            ++helper[arr[i]];
        }
        res[0] = 0;
        for (int i = 0; i < size; i++)
        {
            if (helper[i] > res[0])
            {
                res[0] = i;
                res[1] = helper[i];
            }
        }
        return res;
    }

    static void Main()
    {
        int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        int[] mode = FindMode(arr, 13);
        Console.WriteLine("{0} ({1} times)", mode[0], mode[1]);
    }
}

