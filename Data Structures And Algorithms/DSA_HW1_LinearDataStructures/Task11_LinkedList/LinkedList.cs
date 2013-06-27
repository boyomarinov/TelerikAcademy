using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_LinkedList
{
    class MyLinkedList<T>
    {
        private ListItem<T> firstElement;
        private int count;

        public MyLinkedList(ListItem<T> first = null)
        {
            this.FirstElement = first;

            if (first == null)
            {
                this.Count = 0;
            }
            else
            {
                this.Count = 1;
            }
        }

        public ListItem<T> FirstElement
        {
            get
            {
                return this.firstElement;
            }

            set
            {
                this.firstElement = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Count cannot be negative!");
                }

                this.count = value;
            }
        }

        public void InsertElementAtFront(T data)
        {
            ListItem<T> toInsert = new ListItem<T>(data);
            if (IsEmpty())
            {
                this.FirstElement = toInsert;
            }
            else
            {
                toInsert.NextItem = firstElement;
                firstElement = toInsert;
            }

            this.Count++;
        }

        public void InsertElementAtIndex(T data, int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Index is not in within the range of this LList!");
            }

            ListItem<T> current = this.FirstElement;
            //get to position <index> in the LList
            while (index > 0)
            {
                current = current.NextItem;
                index--;
            }

            ListItem<T> toInsert = new ListItem<T>(data);
            toInsert.NextItem = current.NextItem;
            current.NextItem = toInsert;
            this.Count++;
        }

        public void InsertElementAtBack(T data)
        {
            ListItem<T> toInsert = new ListItem<T>(data);
            if (IsEmpty())
            {
                this.FirstElement = toInsert;
            }
            else
            {
                //go to the last element of the LList
                ListItem<T> current = this.FirstElement;
                while (current.NextItem != null)
                {
                    current = current.NextItem;
                }
                current.NextItem = toInsert;
                current = toInsert;
            }

            this.Count++;
        }

        private bool IsEmpty()
        {
            return (this.FirstElement == null);
        }

        public bool RemoveElementFromFront()
        {
            if (IsEmpty())
            {
                return false;
            }
            else
            {
                if (this.FirstElement.NextItem == null)
                {
                    this.FirstElement = null;
                }
                else
                {
                    this.FirstElement = this.FirstElement.NextItem;
                }
                this.Count--;

                return true;
            }
        }

        public bool RemoveElementAtIndex(int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Index is not in within the range of this LList!");
            }

            if (IsEmpty())
            {
                return false;
            }

            ListItem<T> current = this.FirstElement;
            //get the element before the targeted index
            while (index > 1)
            {
                current = current.NextItem;
                index--;
            }

            ListItem<T> toRemove = current.NextItem;
            current.NextItem = toRemove.NextItem;

            return true;
        }

        public bool RemoveElementFromBack()
        {
            if (IsEmpty())
            {
                return false;
            }
            else
            {
                if (this.FirstElement.NextItem == null)
                {
                    this.FirstElement = null;
                }
                else
                {
                    //get last and next to last item
                    ListItem<T> current = this.FirstElement;
                    ListItem<T> last = current.NextItem;
                    while (last.NextItem != null)
                    {
                        current = current.NextItem;
                        last = last.NextItem;
                    }

                    last = null;
                    current.NextItem = null;
                }

                this.Count--;

                return true;
            }
        }

        public void PrintLList()
        {
            StringBuilder sb = new StringBuilder();
            ListItem<T> current = this.FirstElement;
            while (current.NextItem != null)
            {
                sb.Append(current.Data + " ");
                current = current.NextItem;
            }
            sb.Append(current.Data);

            Console.WriteLine(sb.ToString());
        }
    }
}
