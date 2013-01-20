using System;
//using System.Globalization;
//using System.Threading;

class MathExpression
{
    static decimal Evaluate(decimal n, decimal m, decimal p)
    {
        double mod = (double)Math.Truncate(m % 180);
        decimal result = ((n * n + 1 / (m * p) + 1337) / (n - (decimal)128.523123123 * p) + (decimal)Math.Sin(mod));
        return result;
    }
    static void Main()
    {
        //Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

        decimal n, m, p;
        //string stringN, stringM, stringP;
        n = decimal.Parse(Console.ReadLine());
        m = decimal.Parse(Console.ReadLine());
        p = decimal.Parse(Console.ReadLine());
        //n = decimal.Parse(stringN.Replace(".", ","));
        //m = decimal.Parse(stringM.Replace(".", ","));
        //p = decimal.Parse(stringP.Replace(".", ","));

        //string stringResult = (Evaluate(n, m, p)).ToString();
        //double doubleResult = double.Parse(stringResult);
        decimal doubleResult = Evaluate(n, m, p);

        Console.WriteLine("{0:F6}", doubleResult);
    }
}
