using System;
using System.Text;

namespace Task12_MyStack
{
    class MyStack<T>
    {
        private T[] array;
        private int top;

        public MyStack()
        {
            this.array = new T[4];
            this.Top = 0;
        }

        public MyStack(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Stack size can be only positive number!");
            }

            this.array = new T[size];
            this.Top = 0;
        }

        public int Top
        {
            get 
            { 
                return top; 
            }

            set 
            { 
                top = value; 
            }
        }

        public void Push(T data)
        {
            if (top == this.array.Length)
            {
                IncreaseStackSize();
            }

            this.array[this.Top++] = data;
        }

        public T Pop()
        {
            if (this.Top == 0)
            {
                throw new InvalidOperationException("Cannot pop element from empty stack!");
            }

            this.Top--;
            T returnValue = this.array[this.Top];

            dynamic defaultValue = 0;
            this.array[this.Top] = defaultValue;

            return returnValue;
        }

        public T Peek()
        {
            if (this.Top == 0)
            {
                throw new InvalidOperationException("Cannot peek element from empty stack!");
            }

            return this.array[top - 1];
        }
        public void Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.array.Length; i++)
            {
                sb.Append(this.array[i] + " ");
            }

            Console.WriteLine(sb.ToString());
        }

        private void IncreaseStackSize()
        {
            T[] resizedArray = new T[2 * this.array.Length + 1];
            Array.Copy(this.array, resizedArray, this.array.Length);

            this.array = resizedArray;
        }
    }
}
