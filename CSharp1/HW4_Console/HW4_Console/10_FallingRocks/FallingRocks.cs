using System;
using System.Collections.Generic;
using System.Threading;

class FallingRocks
{
    static char[] rockTypes = { '*', '/', '!', '?', '@', '#', '$', '%', '&', '+' };
    static ConsoleColor[] colors = 
    {
        ConsoleColor.Blue,
        ConsoleColor.Green,
        ConsoleColor.Red,
        ConsoleColor.Magenta,
        ConsoleColor.Yellow,
        ConsoleColor.Cyan,
        ConsoleColor.Gray
    };

    static Random randomGenerator = new Random();
    static int playerPosition = 22;
    static int playerScore = 0;
    const int playerSize = 5;
    static List<Rock> rockArray = new List<Rock>();
    static byte rockGeneratingSpeed = 0;
    static byte rockFallingSpeed = 0;

    public class Rock
    {
        public int x;
        public int y;
        public byte type;
        public byte color;
        public byte size;

        public Rock()
        {
            this.x = 1;
            this.y = 1;
            this.type = 0;
            this.color = 0;
            this.size = 1;
        }
        public void DrawRock()
        {
            if (x > 0 && x + size <= Console.WindowWidth)
            {
                Console.SetCursorPosition(x, y);
                randomGenerator.Next(0, 7);
                Console.ForegroundColor = colors[color];
                for (int i = 0; i < size; i++)
                {
                    Console.Write(rockTypes[type]);
                }
                Console.ResetColor();
            }
        }
        public void FallDown()
        {
            if (y < Console.WindowHeight - 1)
            {
                y++;
            }
        }
    }

    static Rock GenerateRandomRock()
    {
        Rock newRock = new Rock();
        int randomType = randomGenerator.Next(1, 10);
        int randomSize = randomGenerator.Next(1, 8);
        int randomColor = randomGenerator.Next(1, 7);
        newRock.type = (byte)randomType;
        newRock.size = (byte)randomSize;
        newRock.color = (byte)randomColor;
        newRock.x = randomGenerator.Next(0, Console.WindowWidth - 1);
        return newRock;
    }

    static void DrawAllRocks()
    {
        rockArray.RemoveAll(delegate (Rock rock)
        {
            return (rock.y == Console.WindowHeight - 2);
        });
        foreach (Rock rock in rockArray)
        {
            rock.DrawRock();
        }
    }

    static void DrawPlayer()
    {
        Console.SetCursorPosition(playerPosition, Console.WindowHeight - 2);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("((O))");
    }
    static void MovePlayerLeft()
    {
        if (playerPosition > 0)
        {
            playerPosition--;
        }
    }
    static void MovePlayerRight()
    {
        if (playerPosition + playerSize < Console.WindowWidth - 1)
        {
            playerPosition++;
        }
    }

    static void SetConsoleWindow()
    {
        Console.Title = "Game | Falling Rocks";
        Console.WindowHeight = 30;
        Console.WindowWidth = 50;
        Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
    }

    static void StartNewGame()
    {
        playerScore = 0;
        Console.Clear();
        rockArray.Clear();
        DrawPlayer();
        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressed = Console.ReadKey();
                if (pressed.Key == ConsoleKey.LeftArrow)
                {
                    MovePlayerLeft();
                }
                if (pressed.Key == ConsoleKey.RightArrow)
                {
                    MovePlayerRight();
                }
            }
            Console.Clear();
            DrawPlayer();
            DrawAllRocks();
            if (rockGeneratingSpeed % 7 == 0)
            {
                Rock toAdd = GenerateRandomRock();
                rockArray.Add(toAdd);
                playerScore += 10;
            }
            foreach (Rock rock in rockArray)
            {
                if (rock.y >= Console.WindowHeight - 3 &&
                    (rock.x + rock.size - 1 >= playerPosition &&
                    rock.x <= playerPosition + playerSize + 1))
                {
                    GameOver();
                    return;
                }
                else
                {
                    rock.FallDown();
                }
            }
            rockGeneratingSpeed++;
            rockFallingSpeed++;
            Thread.Sleep(60);
        }
    }

    static void GameOver()
    {
        Console.Clear();
        rockArray.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 6);
        Console.WriteLine("Game Over!");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 4);
        Console.WriteLine("Your score is: {0}", playerScore);

        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 2);
        Console.Write("Wanna play again? (y/n)  ");
        ConsoleKeyInfo pressed = Console.ReadKey();
        if (pressed.Key == ConsoleKey.Y)
        {
            StartNewGame();
        }
        else
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);
        }
    }



    static void Main()
    {
        SetConsoleWindow();
        StartNewGame();
    }
}
