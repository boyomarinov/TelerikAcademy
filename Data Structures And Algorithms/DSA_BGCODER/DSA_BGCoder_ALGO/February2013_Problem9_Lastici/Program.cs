using System;
using System.Collections.Generic;
using System.Linq;

namespace February2013_Problem9_Lastici
{
    public static class Program
    {

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif


            int testCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                int result = 0;

                int edges = 0;
                int dimension = int.Parse(Console.ReadLine());
                bool[,] matrix = new bool[dimension,dimension];
                for (int row = 0; row < dimension; row++)
                {
                    string line = Console.ReadLine();
                    bool foreverAlone = true;
                    for (int col = 0; col < dimension; col++)
                    {
                        matrix[row, col] = (line[col] == '1') ? true : false;
                        if (matrix[row, col] == true)
                        {
                            foreverAlone = false;
                            edges++;
                        }
                    }

                    if (foreverAlone)
                    {
                        result = -1;
                    }
                }

                if (result == -1)
                {
                    Console.WriteLine(result);
                    continue;
                }

                if (edges/2 < dimension - 1)
                {
                    Console.WriteLine("-1");
                    continue;
                }

                bool[] visited = new bool[dimension];
                Action<int> dfs = null;
                dfs = (start) =>
                    {
                        for (int j = 0; j < dimension; j++)
                        {
                            if (matrix[start, j] == true && !visited[j])
                            {
                                visited[j] = true;
                                dfs(j);
                            }
                        }
                    };

                int connectedComponentsCount = 0;
                for (int j = 0; j < dimension; j++)
                {
                    if (!visited[j])
                    {
                        connectedComponentsCount++;
                        visited[j] = true;
                        dfs(j);
                    }
                }

                Console.WriteLine(connectedComponentsCount - 1);
            }
        }
    }
}
