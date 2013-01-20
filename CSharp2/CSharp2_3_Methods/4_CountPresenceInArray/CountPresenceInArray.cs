using System;

class CountPresenceInArray
{
    static int CountPresence(int[] array, int target)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
            {
                count++;
            }
        }
        return count;
    }
    static void Main()
    {
        int testNum = 3;
        int[] testArray = { 1, 2, 3, 3, 5, 3, 2, 1, 3, 2, 2 };
        Console.WriteLine(CountPresence(testArray, testNum)); 
    }
}
