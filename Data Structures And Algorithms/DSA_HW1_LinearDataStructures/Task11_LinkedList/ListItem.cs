using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_LinkedList
{
    public class ListItem<T>
    {
        private T data;
        private ListItem<T> nextItem;

        public ListItem(T data)
        {
            this.data = data;
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public ListItem<T> NextItem
        {
            get { return nextItem; }
            set { nextItem = value; }
        }
    }
}
