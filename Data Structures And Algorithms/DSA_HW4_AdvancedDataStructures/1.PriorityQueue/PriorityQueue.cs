using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.PriorityQueue
{
    public class PriorityQueue<T>
        where T : IComparable<T>
    {
        private Heap<T> queue;

        public PriorityQueue()
        {
            queue = new Heap<T>();
        }

        public int Count
        {
            get
            {
                return this.queue.Count;
            }
        }

        public void Enqueue(T item)
        {
            queue.Push(item);
        }

        public T Dequeue()
        {
            return queue.Pop();
        }

        public T Peek()
        {
            return queue.Peek();
        }

        public void Print()
        {
            queue.Print();
        }
    }
}
