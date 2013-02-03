using System;
using System.Collections.Generic;
using System.Text;

class Indices
{

    static void ConstructSequence(int[] arr, bool[] visited)
    {
        //init
        int size = arr.Length;
        //StringBuilder result = new StringBuilder();
        List<int> output = new List<int>();
        //index is the current index, reading from array
        //int index = 0;
        int currentElem = 0;
        int start = -1;
        int end = start;
        int previous = 0;
        int previousOfPrevious = 0;
        bool flag = false;
        //int nextElem = 0;
        while (currentElem >= 0 && currentElem < size)
        {
            if (visited[currentElem])
            {
                flag = true;
                start = output.IndexOf(currentElem);
               // end = previousOfPrevious;
                break;
            }
            //result.Append(currentElem + " ");
            output.Add(currentElem);
            visited[currentElem] = true;
            previousOfPrevious = previous;
            previous = currentElem;


            currentElem = arr[currentElem];
        }
        //Console.WriteLine(start);
        //Console.WriteLine(end);
        if (flag)
        {
            var str = new StringBuilder();
            for (int i = 0; i < start - 1; i++)
            {
                str.Append(output[i] + " ");
            }
            if (start > 0) { str.Append(output[start - 1]); }
            str.Append("("); 
           
            for (int i = start; i < output.Count - 1; i++)
            {
                str.Append(output[i] + " ");
            }
            str.Append(output[output.Count - 1] + ")");

            Console.WriteLine(str.ToString());
        }
        else
        {
            for (int i = 0; i < output.Count; i++)
            {
                Console.Write(output[i]);
                if (i < output.Count - 1)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
        //return result.ToString();
    }
    static void Main()
    {
#if DEBUG
        // Console.SetIn(new System.IO.StreamReader("../../tests/test.008.in.txt"));
#endif
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        string[] input = new string[n];
        input = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(input[i]);
        }
        //int n = 6;
        bool[] visited = new bool[n];
        //int[] arr = { 1, 2, 3, 5, 7, 1 };

        ConstructSequence(arr, visited);
    }
}
