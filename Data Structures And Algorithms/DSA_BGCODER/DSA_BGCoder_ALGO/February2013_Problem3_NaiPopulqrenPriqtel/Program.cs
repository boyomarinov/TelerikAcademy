using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace February2013_Problem3_NaiPopulqrenPriqtel
{
    public static class Program
    {
        private static char[,] AdjMatrix;

        private static int GetSecondConnectionsCount(int start)
        {
            int colsCount = AdjMatrix.GetLength(1);
            bool[] visitedFriends = new bool[AdjMatrix.GetLength(0)];
            int result = 0;

            visitedFriends[start] = true;

            for (int col = 0; col < colsCount; col++)
            {
                if (AdjMatrix[start, col] == 'Y')
                {
                    if (!visitedFriends[col])
                    {
                        result++;
                        visitedFriends[col] = true;
                    }

                    for (int i = 0; i < colsCount; i++)
                    {
                        if (AdjMatrix[col, i] == 'Y' && !visitedFriends[i])
                        {
                            result++;
                            visitedFriends[i] = true;
                        }
                    }
                }
            }

            return result;
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../test.003.in.txt"));
#endif

            int dimension = int.Parse(Console.ReadLine());
            AdjMatrix = new char[dimension, dimension];

            for (int row = 0; row < dimension; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < dimension; col++)
                {
                    AdjMatrix[row, col] = line[col];
                }
            }

            int mostSocial = 0;
            for (int i = 0; i < dimension; i++)
            {
                int currentSocial = GetSecondConnectionsCount(i);

                if (currentSocial > mostSocial)
                {
                    mostSocial = currentSocial;
                }
            }

            Console.WriteLine(mostSocial);
        }
    }
}
