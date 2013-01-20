using System;

class ShipDamage
{
    static int SingleCatapultDamage(int c1, int c2, int h, int left, int right, int up, int down)
    {
        //calculate shot trajectory
        int result = 0;
        int shotx = c1;
        int shoty = 2 * h - c2; //h + Math.Abs(h - c2); 
        //25% damage
        if ((shotx == left && shoty == up) ||
            (shotx == right && shoty == up) ||
            (shotx == left && shoty == down) ||
            (shotx == right && shoty == down))
        {
            result += 25;
        }
        //50% damage
        else if(((shotx == left || shotx == right) && (shoty < up && shoty > down)) ||
                ((shoty == down || shoty == up) && (shotx > left && shotx < right)))
        {
            result += 50;
        }
        //100% damage
        else if ((shotx > left && shotx < right) && (shoty > down && shoty < up))
        {
            result += 100;
        }
        return result;
    }
    static void Main()
    {
        //initialize variables
        int shipx1, shipx2, shipy1, shipy2;
        int catx1, catx2, catx3, caty1, caty2, caty3;
        int horizon;
        int result = 0;
        //read user input
        shipx1 = int.Parse(Console.ReadLine());
        shipy1 = int.Parse(Console.ReadLine());
        shipx2 = int.Parse(Console.ReadLine());
        shipy2 = int.Parse(Console.ReadLine());
        horizon = int.Parse(Console.ReadLine());
        catx1 = int.Parse(Console.ReadLine());
        caty1 = int.Parse(Console.ReadLine());
        catx2 = int.Parse(Console.ReadLine());
        caty2 = int.Parse(Console.ReadLine());
        catx3 = int.Parse(Console.ReadLine());
        caty3 = int.Parse(Console.ReadLine());
        //make ship borders
        int left = (shipx1 < shipx2) ? shipx1 : shipx2;
        int right = (shipx1 > shipx2) ? shipx1 : shipx2;
        int up = (shipy1 > shipy2) ? shipy1 : shipy2;
        int down = (shipy1 < shipy2) ? shipy1 : shipy2;
        //sum damage from all catapults
        result += SingleCatapultDamage(catx1, caty1, horizon, left, right, up, down);
        result += SingleCatapultDamage(catx2, caty2, horizon, left, right, up, down);
        result += SingleCatapultDamage(catx3, caty3, horizon, left, right, up, down);
        Console.WriteLine("{0}%", result);
    }
}

