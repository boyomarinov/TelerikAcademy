using System;
using System.Collections.Generic;
using System.Text;

namespace Task14_Labyrinth
{
    public static class Labyrinth
    {
        private static readonly IList<Coordinate> directions =
            new Coordinate[]
            {
                new Coordinate( 0,  1),
                new Coordinate( 1,  0),
                new Coordinate( 0, -1),
                new Coordinate(-1,  0),
            };

        private static Coordinate FindStartingPoint(string[,] labyrinth, string element)
        {
            Coordinate startPoint = new Coordinate();
            for (int rows = 0; rows < labyrinth.GetLength(0); rows++)
            {
                for (int cols = 0; cols < labyrinth.GetLength(1); cols++)
                {
                    if (labyrinth[rows, cols] == element)
                    {
                        startPoint.Row = rows;
                        startPoint.Col = cols;

                        return startPoint;
                    }
                }
            }

            throw new ArgumentException("There is no starting point defined in this labyrinth!");
        }

        private static Coordinate ChangeDirection(Coordinate current, Coordinate heading)
        {
            Coordinate newDirection = new Coordinate();
            newDirection.Row = current.Row + heading.Row;
            newDirection.Col = current.Col + heading.Col;

            return newDirection;
        }

        private static void MineFieldBFS(string[,] labyrinth, string element)
        {
            Queue<Coordinate> mainQueue = new Queue<Coordinate>();
            Coordinate startPoint = FindStartingPoint(labyrinth, element);
            mainQueue.Enqueue(startPoint);
            int rangeValue = 0;

            while (mainQueue.Count > 0)
            {
                Queue<Coordinate> currentSurroundings = new Queue<Coordinate>();
                rangeValue++;

                //check surroundings of current location
                while (mainQueue.Count > 0)
                {
                    Coordinate current = mainQueue.Dequeue();

                    foreach (var direction in directions)
                    {
                        Coordinate newDirection = ChangeDirection(current, direction);
                        bool isInLabyrinth =
                            0 <= newDirection.Row && newDirection.Row < labyrinth.GetLength(0) &&
                            0 <= newDirection.Col && newDirection.Col < labyrinth.GetLength(1);

                        if (!isInLabyrinth || labyrinth[newDirection.Row, newDirection.Col] != "0") 
                        {
                            continue;
                        }
                        
                        labyrinth[newDirection.Row, newDirection.Col] = rangeValue.ToString();
                        currentSurroundings.Enqueue(newDirection);
                    }
                }

                mainQueue = currentSurroundings;
            }

            PrintLabyrinth(labyrinth);
        }

        private static void PrintLabyrinth(string[,] labyrinth)
        {
            StringBuilder sb = new StringBuilder();

            for (int rows = 0; rows < labyrinth.GetLength(0); rows++)
            {
                for (int cols = 0; cols < labyrinth.GetLength(1); cols++)
                {
                    if (labyrinth[rows, cols] == "0")
                    {
                        sb.Append("u ");
                    }
                    else
                    {
                        sb.Append(labyrinth[rows, cols] + " ");
                    }
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }

        public static void Main()
        {
            string[,] labyrinth = 
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" },
            };

            MineFieldBFS(labyrinth, "*");
        }
    }
}
