using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10_ShortesSequence
{
    public class Node
    {
        private int data;
        private Node previous;

        public Node(int data)
        {
            this.Data = data;
        }

        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        public Node Previous
        {
            get { return previous; }
            set { previous = value; }
        }
    }
}
