using System;
using System.Collections.Generic;

class OddBinarySearch
{
    static void Merge(int[] arr, int left, int middle, int middle1, int right)
    {
        int originalStartPosition = left;
        int size = right - left + 1;
        int[] temp = new int[size];
        int i = 0;

        while (left <= middle && middle1 <= right)
        {
            if (arr[left] <= arr[middle1])
                temp[i++] = arr[left++];
            else
                temp[i++] = arr[middle1++];
        }

        if (left > middle)
        {
            for (int j = middle1; j <= right; j++)
            {
                temp[i++] = arr[middle1++];
            }
        }
        else
        {
            for (int j = left; j <= middle; j++)
            {
                temp[i++] = arr[left++];
            }
        }

        Array.Copy(temp, 0, arr, originalStartPosition, size);
    }
    static void MergeSortAlg(int[] arr, int left, int right)
    {
        int middle;
        if (right > left)
        {
            middle = (right + left) / 2;
            MergeSortAlg(arr, left, middle);
            MergeSortAlg(arr, middle + 1, right);
            Merge(arr, left, middle, middle + 1, right);
        }
    }


    static void Main()
    {
        int valueToSearch = 5;
        int[] input = {3, 2, 5, 6, 1, 3};
        //Console.Write("N: ");
        //int n = int.Parse(Console.ReadLine());
        //string[] temp = new string[n];
        //int[] input = new int[n];
        //temp = Console.ReadLine().Split();
        //for (int i = 0; i < n; i++)
        //{
        //    input[i] = int.Parse(temp[i]);
        //}

        //sort numbers
        MergeSortAlg(input, 0, input.Length-1);

        //find index of value in the array
        int index = Array.BinarySearch(input, valueToSearch);
        //if value is found print exact index
        if (input[index] == valueToSearch)
        {
            Console.WriteLine(index);
        }
        //Array.BinSearch returns minus index of next closest element in array
        //if value is not found get minus index and substract index to get previous closest element
        else
        {
            Console.WriteLine(-index - 1);
        }
    }
}

