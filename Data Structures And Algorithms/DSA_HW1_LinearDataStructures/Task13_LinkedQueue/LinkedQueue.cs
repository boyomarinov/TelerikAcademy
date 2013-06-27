using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13_LinkedQueue
{
    class LinkedQueue<T>
    {
        private QueueItem<T> front;
        private QueueItem<T> rear;
        private int count;

        public void Enqueue(T data)
        {
            QueueItem<T> newItem = new QueueItem<T>(data);
            rear.Next = newItem;
            rear = newItem;
        }

        public T Dequeue()
        {
            if (this.front == null)
            {
                throw new InvalidOperationException("Cannot dequeue element from empty queue!");
            }

            QueueItem<T> newFront = front.Next;
            T dequeuedValue = front.Data;
            front = newFront;

            return dequeuedValue;
        }

        public T Peek()
        {
            if (this.front == null)
            {
                throw new InvalidOperationException("Cannot peek element from empty queue!");
            }

            T peekValue = this.front.Data;

            return peekValue;
        }

        public int Count
        {
            get 
            { 
                return count; 
            }

            set 
            { 
                count = value; 
            }
        }

    }
}
