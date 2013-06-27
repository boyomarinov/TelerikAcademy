using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Task13_LinkedQueue
{
    class TestQueue
    {
        static void Main()
        {
            Queue<int> testQueue = new Queue<int>();
            testQueue.Enqueue(2);
            testQueue.Enqueue(3);
            testQueue.Enqueue(4);
            testQueue.Enqueue(5);

            Console.WriteLine(testQueue.Dequeue());
            Console.WriteLine(testQueue.Dequeue());
            Console.WriteLine(testQueue.Dequeue());
        }
    }
}
