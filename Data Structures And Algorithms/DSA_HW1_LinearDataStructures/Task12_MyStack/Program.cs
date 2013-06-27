using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_MyStack
{
    public static class Program
    {
        public static void Main()
        {
            MyStack<int> testStack = new MyStack<int>();

            //test Push
            testStack.Push(2);
            testStack.Push(3);
            testStack.Push(4);
            testStack.Push(5);
            testStack.Print();

            //test auto-resize
            testStack.Push(6);
            testStack.Print();

            //test Pop
            Console.WriteLine(testStack.Pop());
            Console.WriteLine(testStack.Pop());
            Console.WriteLine(testStack.Pop());
            testStack.Print();

            //test Peek
            Console.WriteLine(testStack.Peek());
            testStack.Pop();
            Console.WriteLine(testStack.Peek());
        }
    }
}
