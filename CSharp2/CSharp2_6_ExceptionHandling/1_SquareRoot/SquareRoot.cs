using System;

class SquareRoot
{
    static void Main()
    {
        int num;
        try
        {
            num = int.Parse(Console.ReadLine());
            if (num < 0)
            {
                throw new FormatException();
            }
            Console.WriteLine("Sqrt: {0}", Math.Sqrt(num));
        }
        catch (OverflowException)
        {
            Console.Error.WriteLine("Number is smaller than int.MinValue or bigger than int.MaxValue.");
        }
        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("Argument is null, enter a value.");
        }
        catch (FormatException)
        {
            Console.Error.WriteLine("Argument is not in correct form. Enter valid number");
        }
    }
}
