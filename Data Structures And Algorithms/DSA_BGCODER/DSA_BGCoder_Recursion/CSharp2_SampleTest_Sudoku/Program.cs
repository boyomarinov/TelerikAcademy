using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coord = System.Tuple<int, int>;

namespace CSharp2_SampleTest_Sudoku
{
    public static class Program
    {
        private static int DIMENSION = 9;
        private static List<Coord> emptyPositions = new List<Coord>(); 

        public static bool IsValid(char[,] field, Coord position, int posValue)
        {
            //check current row
            for (int col = 0; col < DIMENSION; col++)
            {
                if (field[position.Item1, col] == posValue)
                {
                    return false;
                }
            }

            //check current col
            for (int row = 0; row < DIMENSION; row++)
            {
                if (field[row, position.Item2] == posValue)
                {
                    return false;
                }
            }

            //check current subarea
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (field[(position.Item1 / 3) * 3 + row, (position.Item2 / 3) * 3 + col] == posValue)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static List<Coord> GetEmptyPositions(char[,] field)
        {
            List<Coord> empty = new List<Coord>();
            for (int row = 0; row < DIMENSION; row++)
            {
                for (int col = 0; col < DIMENSION; col++)
                {
                    if (field[row, col] == '-')
                    {
                        empty.Add(new Coord(row, col));
                    }
                }
            }

            return empty;
        } 

        public static void PrintField(char[,] field)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    sb.Append(field[row, col]);
                }
                sb.AppendLine();
            }

            Console.Write(sb.ToString());
        }

        public static void SolveSudoku(char[,] field, int start)
        {
            if (start == emptyPositions.Count)
            {
                PrintField(field);
                Environment.Exit(0);
            }

            //Console.WriteLine();
            //PrintField(field);

            for (char i = '1'; i <= '9'; i++)
            {
                Coord currentEmptyPosition = emptyPositions[start];
                if (IsValid(field, currentEmptyPosition, i))
                {
                    field[currentEmptyPosition.Item1, currentEmptyPosition.Item2] = i;
                    SolveSudoku(field, start + 1);
                    field[currentEmptyPosition.Item1, currentEmptyPosition.Item2] = '-';
                }
            }
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            char[,] sudokuField = new char[DIMENSION, DIMENSION];

            for (int i = 0; i < DIMENSION; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < DIMENSION; j++)
                {
                    sudokuField[i, j] = line[j];
                }
            }

            emptyPositions = GetEmptyPositions(sudokuField);
            SolveSudoku(sudokuField, 0);
        }
    }
}
