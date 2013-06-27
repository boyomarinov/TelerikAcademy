using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.PriorityQueue
{
    public static class Program
    {
        public static void Main()
        {
            //Heap test

            //Heap<int> testHeap = new Heap<int>();
            //testHeap.Push(3);
            //testHeap.Push(4);
            //testHeap.Push(5);
            //testHeap.Push(1);
            //testHeap.Push(6);

            //while (testHeap.Count > 0)
            //{
            //    testHeap.Pop();
            //    testHeap.Print();
            //}

            //Queue test
            PriorityQueue<int> queue = new PriorityQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(1);
            queue.Enqueue(6);

            queue.Print();

            while (queue.Count > 0)
            {
                queue.Dequeue();
                queue.Print();
            }
        }
    }
}
