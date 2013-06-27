using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13_LinkedQueue
{
    public class QueueItem<T>
    {
        private T data;
        private QueueItem<T> next;

        public QueueItem() 
        {
        }

        public QueueItem(T data)
        {
            this.Data = data;
        }

        public T Data
        {
            get 
            { 
                return data; 
            }

            set 
            { 
                data = value; 
            }
        }

        public QueueItem<T> Next
        {
            get 
            { 
                return next; 
            }

            set 
            { 
                next = value;
            }
        }
    }
}
