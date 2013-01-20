using System;

class SpellCardsDeck
{
    static void Main()
    {
        for (int i = 1; i < 14; i++)
        {
            for (int j = 1; j < 5; j++)
            {
                switch (i)
                {
                    case 1: Console.Write("Ace of "); break;
                    case 2: Console.Write("Deuce of "); break;
                    case 3: Console.Write("Three of "); break;
                    case 4: Console.Write("Four of "); break;
                    case 5: Console.Write("Five of "); break;
                    case 6: Console.Write("Six of "); break;
                    case 7: Console.Write("Seven of "); break;
                    case 8: Console.Write("Eight of "); break;
                    case 9: Console.Write("Nine of "); break;
                    case 10: Console.Write("Ten of "); break;
                    case 11: Console.Write("Jack of "); break;
                    case 12: Console.Write("Queen of "); break;
                    case 13: Console.Write("King of "); break;
                    default: Console.WriteLine("Some error.."); break;
                }
                switch (j)
                {
                    case 1: Console.WriteLine("Clubs"); break;
                    case 2: Console.WriteLine("Diamonds"); break;
                    case 3: Console.WriteLine("Hearts"); break;
                    case 4: Console.WriteLine("Spades"); break;
                }
            }
        }
    }
}

