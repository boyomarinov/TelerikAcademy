using System;

class StringContainNumber
{
    static int CountCloseEncounters(string text, string target)
    {
        //make the search case-insensitive
        text = text.ToLower();
        target = target.ToLower();

        int count = 0;
        int index = text.IndexOf(target, 0);
        while (index != -1)
        {
            count++;
            index = text.IndexOf(target, index + 1);
        }
        return count;
    }
    static void Main()
    {
        string text = "We are living in an yellow submarine. We don't have anything else." +
                        "Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string target = "in";
        Console.WriteLine(CountCloseEncounters(text, target));
    }
}
