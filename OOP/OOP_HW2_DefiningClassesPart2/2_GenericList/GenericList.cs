using System;
using System.Text;

namespace _2_GenericList
{
    class GenericList<T>
        where T : IComparable<T>
    {
        private T[] data;
        private int count;
        private int capacity;

        #region Constructors
        public GenericList()
        {
            this.capacity = 1;
            this.count = 0;
            data = new T[this.capacity];
        }

        public GenericList(int capacity)
        {
            this.capacity = capacity;
            this.count = 0;
            data = new T[this.capacity];
        }
        #endregion

        public int Count
        {
            get { return this.count; }
        }

        //Indexer
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < this.count)
                {
                    return data[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < this.count; i++)
            {
                output.AppendLine(i + ": " + this.data[i]);
            }

            return output.ToString();
        }

        #region Methods

        //Insert element at specific index
        public void InsertElementAt(int index, T elem)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (null == elem)
            {
                throw new ArgumentNullException();
            }

            //account for the added element
            this.count++;

            //if capacity is reached, expand array with double the current capacity
            if (this.count >= this.capacity)
            {
                this.capacity *= 2;
            }

            //Construct new array with element added
            T[] newData = new T[this.capacity];
            Array.Copy(this.data, newData, index);
            newData[index] = elem;
            Array.Copy(this.data, index, newData, index + 1, this.count - index - 1);

            this.data = newData;
        }

        //Delete element at specific index
        public T RemoveElementAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException();
            }

            //save removed element
            T removed = this.data[index];

            //construct new array with element removed
            T[] newData = new T[this.capacity];
            Array.Copy(this.data, newData, index);
            Array.Copy(this.data, index + 1, newData, index, this.count - index - 2);
            this.data = newData;
            this.count--;

            return removed;
        }

        public void AddElement(T elem)
        {
            InsertElementAt(this.count, elem);
        }

        public void ClearList()
        {
            this.data = new T[this.capacity];
            this.count = 0;
        }

        //Find smallest element in generic collection
        public T Min()
        {
            //assume first element is min and check if there is smaller one
            T min = this.data[0];
            for (int i = 1; i < this.count; i++)
            {
                if (this.data[i].CompareTo(min) < 0)
                {
                    min = this.data[i];
                }
            }

            return min;
        }

        //Find biggest element in generic collection
        public T Max()
        {
            T max = this.data[0];
            for (int i = 1; i < this.count; i++)
            {
                if (this.data[i].CompareTo(max) > 0)
                {
                    max = this.data[i];
                }
            }

            return max;
        }

        #endregion

        
    }
    class Test
    {
        static void Main()
        { }
    }
}
