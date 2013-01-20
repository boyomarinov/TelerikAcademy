using System;

class GetBiggestNeighbour
{
    static bool CheckIfBigger(int[] array, int index)
    {
        if (index == 0 || index == array.Length - 1)
        {
            return false;
        }
        return ((array[index - 1] < array[index]) && (array[index + 1] < array[index]));
    }
    static int CheckArray(int[] array)
    {
        int index = -1;
        for (int i = 1; i < array.Length-1; i++)
        {
            if (CheckIfBigger(array, i) == true)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    static void Main()
    {
        int[] array = { 3, 4, 2, 9, 8, 4, 6 };
        int ind = CheckArray(array);
        Console.WriteLine(ind);
    }
}

