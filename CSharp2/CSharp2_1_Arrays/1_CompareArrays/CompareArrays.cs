using System;

    class CompareArrays
    {
        static bool compareArrays(int[] a, int[] b, int countA, int countB)
        {
            bool flag;
            if (countA == countB)
            {
                for (int i = 0; i < countA; i++)
                {
                    if (a[i] != b[i])
                    {
                        flag = false;
                        break;
                    }
                }
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        static void Main()
        {
            int[] arr1 = new int[100];
            int[] arr2 = new int[100];
            int count1 = 0;
            int count2 = 0;

            Console.Write("Array 1: ");
            string[] firstArrayString = Console.ReadLine().Split();
            for (int i = 0; i < firstArrayString.Length; i++)
            {
                arr1[i] = int.Parse(firstArrayString[i]);
                count1++;
            }

            Console.Write("Array 2: ");
            string[] secondArrayString = Console.ReadLine().Split();
            for (int i = 0; i < secondArrayString.Length; i++)
            {
                arr2[i] = int.Parse(secondArrayString[i]);
                count2++;
            }
            //Console.WriteLine();

            if(compareArrays(arr1, arr2, count1, count2) == true)
            {
                Console.WriteLine("Arrays are equal");
            }
            else
            { 
                Console.WriteLine("Arrays are different");
            }
        }
    }
