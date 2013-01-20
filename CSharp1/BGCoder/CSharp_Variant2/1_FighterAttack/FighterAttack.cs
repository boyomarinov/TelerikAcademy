using System;

class FighterAttack
{
    static int FighterDamage(int fighterX, int fighterY, int distance,
        int left, int right, int up, int down)
    {
        int result = 0;
        int impactX = fighterX + distance;
        int impactY = fighterY;
        //check 100% damage
        if (impactX >= left && impactX <= right && impactY >= down && impactY <= up)
        {
            result += 100;
        }
        //check 75% damage
        if (impactX+1 >= left && impactX+1 <= right && impactY >= down && impactY <= up)
        {
            result += 75;
        }
        //check 50% damage
        //up
        if (impactX >= left && impactX <= right && impactY+1 >= down && impactY+1 <= up)
        {
            result += 50;
        }
        if (impactX >= left && impactX <= right && impactY-1 >= down && impactY-1 <= up)
        {
            result += 50;
        }
        
        return result;
    }
    static void Main()
    {
        int px1, py1, px2, py2, fx, fy, d;
        px1 = int.Parse(Console.ReadLine());
        py1 = int.Parse(Console.ReadLine());
        px2 = int.Parse(Console.ReadLine());
        py2 = int.Parse(Console.ReadLine());
        fx = int.Parse(Console.ReadLine());
        fy = int.Parse(Console.ReadLine());
        d = int.Parse(Console.ReadLine());
        int left = (px1 < px2) ? px1 : px2;
        int right = (px1 < px2) ? px2 : px1;
        int up = (py1 < py2) ? py2 : py1;
        int down = (py1 < py2) ? py1 : py2;

        int result = FighterDamage(fx, fy, d, left, right, up, down);
        Console.WriteLine("{0}%", result);
    }
}

