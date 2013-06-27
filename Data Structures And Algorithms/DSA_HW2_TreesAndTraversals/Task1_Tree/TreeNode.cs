using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Tree
{
    public class TreeNode<T>
    {
        private T data;
        private List<TreeNode<T>> children;
        private bool hasParent;

        public T Data
        {
            get
            {
                return this.data;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Cannot set node to an empty value!");
                }

                this.data = value;
            }
        }

        public bool HasParent
        {
            get 
            {
                return this.hasParent; 
            }

            set 
            {
                this.hasParent = value; 
            }
        }

        public int ChildrensCount
        {
            get
            {
                return this.children.Count;
            }
        }

        public TreeNode(T data)
        {
            this.HasParent = false;
            this.Data = data;
            this.children = new List<TreeNode<T>>();
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert empty value!");
            }

            child.hasParent = true;
            this.children.Add(child);
        }

        public TreeNode<T> GetChildAtIndex(int index)
        {
            return this.children[index];
        }

        public override string ToString()
        {
            return String.Format("{0} -> children: {1}", this.Data, this.ChildrensCount); 
        }
    }
}
