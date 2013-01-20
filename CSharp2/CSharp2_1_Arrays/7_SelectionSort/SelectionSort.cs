using System;

class SelectionSort
{
    static void SelectionSortMethod(int[] arr, int size)
    {
        int minimal = 0;
        int temp = 0;
        for (int i = 0; i < size - 1; i++)
        {
            minimal = i;
            for (int j = i + 1; j < size; j++)
            {
                if (arr[j] < arr[minimal])
                {
                    minimal = j;
                }
            }
            temp = arr[minimal];
            arr[minimal] = arr[i];
            arr[i] = temp;
        }
    }

    static void Main()
    {
        int[] arr = { 9, 3, 4, 1, 8, 2, 6, 7, 10, 5 };
        SelectionSortMethod(arr, 10);
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}

