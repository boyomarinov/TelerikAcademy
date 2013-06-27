using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_LinkedList
{
    public static class Program
    {
        public static void Main()
        {
            MyLinkedList<int> testLList = new MyLinkedList<int>();
            testLList.InsertElementAtBack(3);
            testLList.InsertElementAtFront(2);
            testLList.InsertElementAtIndex(10, 1);
            testLList.PrintLList();

            testLList.RemoveElementAtIndex(1);
            testLList.PrintLList();
        }
    }
}
