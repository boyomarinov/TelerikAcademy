using System;

class MergeSort
{
    //static void MergeArrays(int[] a, int sizeA, int[] b, int sizeB, int[] result)
    //{
    //    int i = 0;
    //    int j = 0;
    //    while (i + j < sizeA + sizeB)
    //    {
    //        if (i == sizeA)
    //        {
    //            result[i + j] = b[j++];
    //        }
    //        else if (j == sizeB)
    //        {
    //            result[i + j] = a[i++];
    //        }
    //        else
    //        {
    //            result[i + j] = (a[i] < b[j]) ? a[i++] : b[j++];
    //        }
    //    }
    //}
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
        int[] arr = { 2, 1, 9, 4, 6, 7, 3, 5, 8, 10 };
        MergeSortAlg(arr, 0, 9);
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}

