using System;

class CheckNeighbours
{
    static bool CheckIfBigger(int[] array, int index)
    {
        if (index == 0 || index == array.Length - 1)
        {
            return false;
        }
        return ((array[index - 1] < array[index]) && (array[index + 1] < array[index]));
    }

    static void Main()
    {
        int[] array = { 3, 4, 2, 9, 8, 4, 6 };
        Console.WriteLine(CheckIfBigger(array, 0));
        Console.WriteLine(CheckIfBigger(array, 3));
        Console.WriteLine(CheckIfBigger(array, 6));
    }
}

