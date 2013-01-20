using System;

    class LexArrayCompare
    {
        static bool LexicographicArray(char[] a, char[] b)
        {
            bool flag;
            if (a.Length == b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    int firstValue = a[i] - 'a';
                    int secondValue = b[i] - 'a';
                    if (firstValue != secondValue)
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
            char[] arr1 = { 'a', 'b', 'c', 'd' };
            char[] arr2 = { 'a', 'b', 'c' };
            
            if (LexicographicArray(arr1, arr2) == true)
            {
                Console.WriteLine("Arrays are lexicographically equal.");
            }
            else
            {
                Console.WriteLine("Array are not lexicographically equal.");
            }
        }
    }
