using System;

class NumericProgram
{
    //counts the number of chosen tasks
    static int counter = 0;

    static int GetLength(int num)
    {
        int len = 0;
        while (num > 0)
        {
            num /= 10;
            len++;
        }
        return len;
    }
    static int ReversedNumber(int num)
    {
        if (num < 10)
        {
            return num;
        }

        int result = 0;
        int digitsCount = GetLength(num);
        int degree = digitsCount - 1;

        for (int i = 1; i <= digitsCount; i++)
        {
            result += (int)((num % 10) * Math.Pow((double)10, (double)degree));
            degree--;
            num /= 10;
        }
        return result;
    }
    static double AverageOfSequence(int[] seq)
    {
        int sum = 0;
        for (int i = 0; i < seq.Length; i++)
        {
            sum += seq[i];
        }
        return (double)sum / seq.Length;
    }
    static int ChooseOption()
    {
        int num = 0;
        string input = "";
        bool parsedSuccessfully = false;
        if (counter == 0)
        {
            Console.WriteLine("*****************************************************");
            Console.WriteLine("This is a simple program, that can solve three tasks:");
            Console.WriteLine("*****************************************************");
        }
        counter++;
        Console.WriteLine();
        Console.WriteLine("(1) Reverse the digits of a number");
        Console.WriteLine("(2) Calculate average of integer sequence");
        Console.WriteLine("(3) Solves the linear equation: a*x + b = 0");
        Console.WriteLine("(4) Terminates program!");
        Console.WriteLine();
        Console.Write("Please choose your task by the appropriate number: ");
        input = Console.ReadLine();
        parsedSuccessfully = Int32.TryParse(input, out num);
        if (parsedSuccessfully)
        {
            switch (num)
            {
                case 1:
                    Console.WriteLine("You chose to reverse a number.");
                    Console.Write("Please input your number: ");
                    input = Console.ReadLine();
                    parsedSuccessfully = Int32.TryParse(input, out num);
                    if (parsedSuccessfully)
                    {
                        Console.WriteLine("The reversed number is: {0}", ReversedNumber(num));
                    }
                    else
                    {
                        Console.WriteLine("You entered invalid input.");
                    }
                    break;
                case 2:
                    Console.WriteLine("You choose to calculate average of integer sequence.");
                    Console.Write("Please enter your sequence: ");
                    Console.WriteLine();
                    string[] strInput = Console.ReadLine().Split();
                    int[] sequence = new int[strInput.Length];
                    for (int i = 0; i < strInput.Length; i++)
                    {
                        sequence[i] = int.Parse(strInput[i]);
                    }
                    Console.WriteLine("The average of integer sequence is: {0}", AverageOfSequence(sequence));
                    Console.WriteLine();
                    break;
                case 3:
                    int a, b;
                    Console.WriteLine("You chose to solve a linear equation. [A*x + B = 0]");
                    Console.Write("Please input A (non negative): ");
                    a = int.Parse(Console.ReadLine());
                    while (a <= 0)
                    {
                        Console.WriteLine("You entered invalid number for A. Try again: ");
                        a = int.Parse(Console.ReadLine());
                    }
                    Console.Write("Please input B: ");
                    b = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Answer: x = {0}", -b / a);
                    Console.WriteLine();
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("You entered invalid number.");
                    Console.WriteLine();
                    break;
            }
        }
        return num;
    }
    static void Main()
    {
        int num = 0;
        while (num != 4)
        {
            num = ChooseOption();
        }
    }
}
