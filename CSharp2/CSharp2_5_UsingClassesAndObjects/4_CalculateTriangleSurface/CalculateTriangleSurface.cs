using System;

class CalculateTriangleSurface
{
    //triangle area is equal to 1/2 of altitude multiplied by hypotenuse
    static double CalcAreaWithAltitude(double side, double altitude)
    {
        double res = (side * altitude) / 2;
        return res;
    }

    //Heron's formula: S = sqrt(s(s-a)(s-b)(s-c))
    //where s is half the perimeter of the triangle
    static double CalcAreaWithSides(double a, double b, double c)
    {
        double halfP = (a + b + c) / 2;
        double res = Math.Sqrt(halfP * (halfP - a) * (halfP - b) * (halfP - c));
        return res;
    }

    //triangle area is equal to the multiplication of two 
    //of its sides and and angle locked between them
    static double CalcAreaWithSidesAndAngle(double a, double b, double angle)
    {
        double res = (a * b * Math.Sin((angle/180) * Math.PI)) / 2;
        return res;
    }
    static void Main()
    {
        //Pythagorean triplet
        double a = 5;
        double b = 12;
        double c = 13;

        Console.WriteLine("Area with Altitude: {0}", CalcAreaWithAltitude(b, a));
        Console.WriteLine("Area with Sides: {0}", CalcAreaWithSides(a, b, c));
        Console.WriteLine("Area with Sides and Angle: {0}", CalcAreaWithSidesAndAngle(a, b, 90));
    }
}
