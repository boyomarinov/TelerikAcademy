using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

class Program
{
    static StringBuilder grandeOutput = new StringBuilder();

    static int ParseForParams(string pars)
    {
        string[] parameters = pars.Split(',');
        if (parameters.Length == 1)
        {
            return int.Parse(parameters[0]);
        }
        else
        {
            return (int.Parse(parameters[1]) - int.Parse(parameters[0]) + 1);
        }
    }
    static void ParseExpression(string[] statements)
    {
        for (int i = 0; i < statements.Length; i++)
        {
            int currentIndex = 0;
            long coefficient = 1;
            //CHECK? currentIndex >= 0 && currentIndex < statements[i].Length &&
            while (statements[i][currentIndex] == 'F')
            {
                int openBracket = statements[i].IndexOf('(', currentIndex) + 1;
                int closeBracket = statements[i].IndexOf(')', openBracket);
                string par = statements[i].Substring(openBracket, closeBracket - openBracket);
                coefficient *= ParseForParams(par);
                if (coefficient == 0)
                {
                    break;
                }
                int nextIndex = statements[i].IndexOf('F', currentIndex + 1);
                if (nextIndex == -1)
                {
                    currentIndex = statements[i].IndexOf('P', currentIndex);
                    break;
                }
                else
                {
                    currentIndex = nextIndex;
                }
            }
            if (statements[i][currentIndex] == 'P')
            {
                int openBracket = statements[i].IndexOf('(', currentIndex) + 1;
                int closeBracket = statements[i].IndexOf(')', openBracket);
                string toPrint = statements[i].Substring(openBracket, closeBracket - openBracket);
                for (int times = 0; times < coefficient; times++)
                {
                    grandeOutput.Append(toPrint);
                }
                //Console.Write(toPrint);
            }
            if (statements[i][currentIndex] == 'E')
            {
                //Console.WriteLine(grandeOutput.ToString());
                break;
            }
        }
    }

    static void Main()
    {
//        DateTime start = DateTime.Now;

//#if DEBUG
//        Console.SetIn(new System.IO.StreamReader("../../test.010.in.txt"));
//#endif

        StringBuilder input = new StringBuilder();
        string row = string.Empty;
        while ((row = Console.ReadLine()) != null)
        {
            input.Append(row);
        }
        string expression = input.ToString();

        //        string expression = @"PRINT(Black and yellow, );
        //FOR(0,1)PRINT(black and yellow, );   PRINT(black and yellow...);
        //EXIT;";
        //string expression = @"Print()
        //;";

        

        string[] statements = Regex.Split(expression, @"\)\s*;\s*");
        for (int i = 0; i < statements.Length; i++)
        {
            statements[i] = statements[i] + ")";
            statements[i] = statements[i].Trim();
            //Console.WriteLine(statements[i]);
        }


        
        ParseExpression(statements);
        //StreamWriter writer = new StreamWriter("../../output.txt");
        //using (writer)
        //{
        //    writer.WriteLine(grandeOutput.ToString());
        //}
        //TimeSpan clock = DateTime.Now - start;

        //Console.WriteLine(grandeOutput.ToString());
        Console.WriteLine(clock);

    }
}
