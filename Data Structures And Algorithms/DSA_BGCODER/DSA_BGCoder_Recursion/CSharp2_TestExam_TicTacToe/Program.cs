using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coord = System.Tuple<int, int>;

namespace CSharp2_TestExam_TicTacToe
{
    public static class Program
    {
        private static List<Coord> emptyPositions = new List<Coord>();
        private static int xWon = 0;
        private static int oWon = 0;
        private static int draws = 0;

        public static bool IsWinningSituation(char[,] field, bool playerTurn)
        {
            char player = (playerTurn) ? 'X' : 'O';

            //check cols
            for (int col = 0; col < 3; col++)
            {
                if (field[0, col] == player &&
                    field[1, col] == player &&
                    field[2, col] == player)
                {
                    return true;
                }
            }

            //check cols
            for (int row = 0; row < 3; row++)
            {
                if (field[row, 0] == player &&
                    field[row, 1] == player &&
                    field[row, 2] == player)
                {
                    return true;
                }
            }

            //check diagonals
            if (field[0, 0] == player &&
                field[1, 1] == player &&
                field[2, 2] == player)
            {
                return true;
            }

            if (field[2, 0] == player &&
                field[1, 1] == player &&
                field[0, 2] == player)
            {
                return true;
            }

            return false;
        }

        public static List<Coord> GetEmptyPositions(char[,] field)
        {
            List<Coord> empty = new List<Coord>();
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (field[row, col] == '-')
                    {
                        empty.Add(new Coord(row, col));
                    }
                }
            }

            return empty;
        }

        public static bool Turn(char[,] field)
        {
            return (emptyPositions.Count % 2 != 0);
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

        //turn == true -> player X
        //turn == false -> player O
        public static void SolveTicTacToe(char[,] field, int start, bool turn)
        {
            //PrintField(field);
            //Console.WriteLine();

            if (IsWinningSituation(field, true))
            {
                xWon++;
                return;
            }

            if (IsWinningSituation(field, false))
            {
                oWon++;
                return;
            }

            if (start == emptyPositions.Count)
            {
                draws++;
                return;
            }

            

            for (int i = 0; i < emptyPositions.Count; i++)
            {
                if (field[emptyPositions[i].Item1, emptyPositions[i].Item2] == '-')
                {
                    char player = (turn) ? 'X' : 'O';

                    field[emptyPositions[i].Item1, emptyPositions[i].Item2] = player;
                    SolveTicTacToe(field, start + 1, !turn);
                    field[emptyPositions[i].Item1, emptyPositions[i].Item2] = '-';
                }
            }
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input2.txt"));
#endif

            char[,] field = new char[3, 3];
            for (int row = 0; row < 3; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < 3; col++)
                {
                    field[row, col] = line[col];
                }
            }

            emptyPositions = GetEmptyPositions(field);
            SolveTicTacToe(field, 0, Turn(field));

            Console.WriteLine(xWon);
            Console.WriteLine(draws);
            Console.WriteLine(oWon);
        }
    }
}
