using System;

class AirplanceDrinks
{
    static long CountTime(int[] teaGuys, int seats)
    {
        //4 seconds for a serve, all passengers will be served
        long result = seats * 4;

        //have array of who is having what
        bool[] havingTea = new bool[seats];

        for (int j = 0; j < teaGuys.Length; j++)
        {
            havingTea[teaGuys[j] - 1] = true;
        }

        int teaLimit = 0;
        int coffeeLimit = 0;
        int countTeaServingTime = 0;
        int countCoffeeServingTime = 0;
        for (int row = seats - 1; row >= 0; row--)
        {
            if (havingTea[row] == true)
            {
                teaLimit++;
                //countTeaServingTime = ((countTeaServingTime > row + 1) ? countTeaServingTime : row + 1);
                countTeaServingTime = Math.Max(countTeaServingTime, row + 1);
            }
            else
            {
                coffeeLimit++;
                //countCoffeeServingTime = ((countCoffeeServingTime > row + 1) ? countCoffeeServingTime : row + 1);
                countCoffeeServingTime = Math.Max(countCoffeeServingTime, row + 1);
            }
            //if refill is needed
            if (teaLimit == 0)
            {
                result += countTeaServingTime * 2;
                result += 47;
                countTeaServingTime = 0;
                teaLimit = 7;
            }
            if (coffeeLimit == 0)
            {
                result += countCoffeeServingTime * 2;
                result += 47;
                countCoffeeServingTime = 0;
                coffeeLimit = 7;
            }
        }
        //check for leftovers 
        if (teaLimit > 0)
        {
            result += countTeaServingTime * 2;
            result += 47;
        }
        if (coffeeLimit > 0)
        {
            result += countCoffeeServingTime * 2;
            result += 47;
        }
       
        return result;
    }
    static void Main()
    {
        int seats = int.Parse(Console.ReadLine());
        int TeaGuysNum = int.Parse(Console.ReadLine());
        int[] teaGuys = new int[TeaGuysNum];
        for (int i = 0; i < TeaGuysNum; i++)
        {
            teaGuys[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(CountTime(teaGuys, seats));
    }
}
