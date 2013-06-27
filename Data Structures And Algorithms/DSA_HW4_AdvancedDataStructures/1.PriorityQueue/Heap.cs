using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.PriorityQueue
{
    public class Heap<T>
        where T : IComparable<T>
    {
        private List<T> array;

        public Heap()
        {
            this.array = new List<T>();
        }

        public int Count
        {
            get
            {
                return this.array.Count;
            }
        }

        public void Push(T item)
        {
            array.Add(item);
            ShiftUp();
        }

        public T Pop()
        {
            if (this.array.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop from empty array!");
            }

            T poppedValue = this.array[0];
            Swap(0, this.array.Count - 1);
            this.array.RemoveAt(this.array.Count - 1);

            ShiftDown();

            return poppedValue;
        }

        public T Peek()
        {
            if (this.array.Count == 0)
            {
                throw new InvalidOperationException("Cannot peek from empty array!");
            }

            return this.array[0];
        }

        public void Print()
        {
            foreach (var item in this.array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        private void ShiftUp()
        {
            int currentIndex = array.Count - 1;
            int parentIndex = (currentIndex - 1) / 2;
            while (parentIndex >= 0 && this.array[currentIndex].CompareTo(this.array[parentIndex]) > 0)
            {
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = (currentIndex - 1) / 2;
            }
        }

        private void ShiftDown()
        {
            int currentIndex = 0;

            if (this.array.Count >= 3)
            {
                int leftChild = 2 * currentIndex + 1;
                int rightChild = leftChild + 1;
                int biggerChild = this.array[leftChild].CompareTo(this.array[rightChild]) >= 0 ? leftChild : rightChild;

                while (rightChild < this.array.Count() &&
                       this.array[currentIndex].CompareTo(this.array[biggerChild]) < 0)
                {
                    Swap(currentIndex, biggerChild);
                    currentIndex = biggerChild;
                    leftChild = 2 * currentIndex + 1;
                    rightChild = leftChild + 1;

                    if (leftChild >= this.array.Count - 1)
                    {
                        break;
                    }

                    biggerChild = this.array[leftChild].CompareTo(this.array[rightChild]) >= 0 ? leftChild : rightChild;
                }
            }
            else
            {
                if (this.array.Count == 2)
                {
                    if (this.array[0].CompareTo(this.array[1]) < 0)
                    {
                        Swap(0, 1);
                    }
                }
            }
        }

        private void Swap(int one, int another)
        {
            T oldFirstValue = this.array[one];
            this.array[one] = this.array[another];
            this.array[another] = oldFirstValue;
        }


    }
}
