using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1_Tree
{
    public class Tree<T>
    {
        private TreeNode<T> root;

        private TreeNode<T> Root
        {
            get
            {
                return root;
            }
        }

        public Tree(TreeNode<T> root)
        {
            this.root = root;
        }

        public Tree(TreeNode<T> root, List<TreeNode<T>> children)
        {
            this.root = root;
            for (int i = 0; i < children.Count; i++)
            {
                children[i].AddChild(this.root);
            }
        }

        public void TraverseWithDFS()
        {
            this.TraverseWithDFS(this.Root, -1);
        }

        public List<TreeNode<T>> GetAllNodes()
        {
            List<TreeNode<T>> nodes = new List<TreeNode<T>>();
            this.GetAllTreeNodes(this.Root, nodes);

            return nodes;
        }

        public void FindAllLeaves(List<TreeNode<T>> leaves)
        {
            FindAllLeaves(this.Root, leaves);
        }

        public void FindAllMiddleNodes(List<TreeNode<T>> middle)
        {
            FindlAllMiddleNodes(this.Root, middle);
        }

        public int FindLongestPath()
        {
            return FindLongestPath(this.Root);
        }

        private void TraverseWithDFS(TreeNode<T> start, int level)
        {
            if (start == null)
            {
                return;
            }

            level++;
            Console.WriteLine(new string(' ', level * 4) + start.Data);

            for (int i = 0; i < start.ChildrensCount; i++)
            {
                TraverseWithDFS(start.GetChildAtIndex(i), level);
            }
        }

        private void GetAllTreeNodes(TreeNode<T> start, List<TreeNode<T>> nodes)
        {

            if (start == null)
            {
                return;
            }

            nodes.Add(start);

            for (int i = 0; i < start.ChildrensCount; i++)
            {
                GetAllTreeNodes(start.GetChildAtIndex(i), nodes);
            }
        }

        private void FindAllLeaves(TreeNode<T> start, List<TreeNode<T>> leaves)
        {
            if (start == null)
            {
                return;
            }

            if (start.ChildrensCount == 0)
            {
                leaves.Add(start);
            }

            for (int i = 0; i < start.ChildrensCount; i++)
            {
                FindAllLeaves(start.GetChildAtIndex(i), leaves);
            }
        }

        private void FindlAllMiddleNodes(TreeNode<T> start, List<TreeNode<T>> middle)
        {
            if (start == null)
            {
                return;
            }

            if (start.ChildrensCount > 0 && start != this.Root)
            {
                middle.Add(start);
            }

            for (int i = 0; i < start.ChildrensCount; i++)
            {
                FindlAllMiddleNodes(start.GetChildAtIndex(i), middle);
            }
        }

        private int FindLongestPath(TreeNode<T> start)
        {
            if (start == null)
            {
                return -1;
            }

            int currentLongestPath = 0;

            for (int i = 0; i < start.ChildrensCount; i++)
            {
                currentLongestPath = Math.Max(currentLongestPath, FindLongestPath(start.GetChildAtIndex(i)));
            }

            return currentLongestPath + 1;
        }

        public List<List<TreeNode<T>>> FindAllPathsWithSum(T sum)
        {
            List<List<TreeNode<T>>> paths = new List<List<TreeNode<T>>>();

            List<TreeNode<T>> treeNodes = GetAllNodes();

            foreach (var node in treeNodes)
            {
                Queue<List<TreeNode<T>>> mainQueue = new Queue<List<TreeNode<T>>>();
                List<TreeNode<T>> path = new List<TreeNode<T>>() { node };
                mainQueue.Enqueue(path);

                while (mainQueue.Count > 0)
                {
                    List<TreeNode<T>> currentPath = mainQueue.Dequeue();
                    dynamic currentSum = Sum(currentPath);

                    if (currentSum == sum)
                    {
                        paths.Add(currentPath);
                    }

                    if (currentSum > sum)
                    {
                        continue;
                    }

                    TreeNode<T> last = currentPath.Last();

                    for (int i = 0; i < last.ChildrensCount; i++)
                    {
                        mainQueue.Enqueue(new List<TreeNode<T>>(currentPath) { last.GetChildAtIndex(i) });
                    }
                }

            }

            return paths;
        }

        private dynamic Sum(List<TreeNode<T>> list)
        {
            dynamic sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i].Data;
            }

            return sum;
        }

        private void GetAllSubtreeData(TreeNode<T> root, List<T> data)
        {
            data.Add(root.Data);
            for (int i = 0; i < root.ChildrensCount; i++)
            {
                TreeNode<T> currentNode = root.GetChildAtIndex(i);
                GetAllSubtreeData(currentNode, data);
            }
        }
    }
}
