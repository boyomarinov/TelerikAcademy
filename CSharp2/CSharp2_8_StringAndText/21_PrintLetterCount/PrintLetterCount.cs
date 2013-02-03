using System;

class PrintLetterCount
{
    static void CountLetters(string str)
    {
        char[] letters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                         'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                         'u', 'w', 'w', 'x', 'y', 'z'};
        int[] letterCount = new int[26];
        str = str.ToLower();
        for (int i = 0; i < str.Length; i++)
        {
            int index = str[i] - 'a';
            if (index >= 0 && index <= 26)
            {
                letterCount[index]++;
            }
        }
        for (int i = 0; i < letterCount.Length; i++)
        {
            if (letterCount[i] > 0)
            {
                Console.WriteLine("{0} -> {1} times", letters[i], letterCount[i]);
            }
        }
        Console.WriteLine();
    }
    static void Main()
    {
        string test = "abcdefg";
        string test2 = "acaeg654ij";
        CountLetters(test);
        CountLetters(test2);
    }
}
