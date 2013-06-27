using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Tree
{
    public static class Program
    {
        public static void Main()
        {
#if DEBUG
            Console.SetIn(new StringReader(@"7
2 4
3 2
5 0
3 5
5 6
5 1"));
#endif

            int inputSize = int.Parse(Console.ReadLine());
            IList<TreeNode<int>> neighboursList = new TreeNode<int>[inputSize];
            for (int i = 0; i < neighboursList.Count; i++)
            {
                neighboursList[i] = new TreeNode<int>(i);
            }

            for (int i = 0; i < inputSize - 1; i++)
            {
                string[] inputValue = Console.ReadLine().Split(' ');
                //TreeNode<int> parent = new TreeNode<int>(int.Parse(inputValue[0]));
                //TreeNode<int> child = new TreeNode<int>(int.Parse(inputValue[1]));
                int parent = int.Parse(inputValue[0]);
                int child = int.Parse(inputValue[1]);
                //parent.AddChild(child);

                neighboursList[parent].AddChild(neighboursList[child]);
            }

            TreeNode<int> root = new TreeNode<int>(0);
            for (int i = 0; i < neighboursList.Count; i++)
            {
                if (neighboursList[i].HasParent == false)
                {
                    //root.Data = neighboursList[i].Data;
                    root = neighboursList[i];
                    break;
                }
            }

            Tree<int> testTree = new Tree<int>(root);
            Console.WriteLine();

            testTree.TraverseWithDFS();

            //Find all leaves
            List<TreeNode<int>> leaves = new List<TreeNode<int>>();
            testTree.FindAllLeaves(leaves);
            Console.Write("Leaves: ");
            foreach (var leaf in leaves)
            {
                Console.Write(leaf.Data + " ");
            }
            Console.WriteLine();

            //Find all middle nodes
            List<TreeNode<int>> middleNodes = new List<TreeNode<int>>();
            testTree.FindAllMiddleNodes(middleNodes);
            Console.Write("Middle nodes: ");
            foreach (var node in middleNodes)
            {
                Console.Write(node.Data + " ");
            }
            Console.WriteLine();

            //Find longest path
            int longestPath = testTree.FindLongestPath();
            Console.WriteLine(longestPath);

            //Find path with sum
            int targetSum = 14;
            List<List<TreeNode<int>>> paths = testTree.FindAllPathsWithSum(targetSum);
            Console.WriteLine("Paths with sum of {0}:", targetSum);
            foreach (var list in paths)
            {
                foreach (var item in list)
                {
                    Console.Write(item.Data + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
