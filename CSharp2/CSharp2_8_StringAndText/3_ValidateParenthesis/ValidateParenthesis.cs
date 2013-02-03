using System;
using System.Collections;

class ValidateParenthesis
{
    static bool Validate(string expression)
    {
        Stack brackets = new Stack();
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                brackets.Push("(");
            }
            else if (expression[i] == ')')
            {
                try
                {
                    brackets.Pop();
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
            }
        }
        if (brackets.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static void Main()
    {
        Console.WriteLine(Validate("((a+b)/5-d)"));
        Console.WriteLine(Validate(")(a+b))"));
    }
}
