namespace CountSubstringClient
{
    using System;
    using CountSubstringService;

    public static class Program
    {
        public static void Main()
        {
            var countClient = new CountSubstringClient();
            countClient.CountOccurrencesAsync("ab", "abcabbaab")
                       .ContinueWith(x => Console.WriteLine("Occurrences count " + x.Result))
                       .ContinueWith(x => Environment.Exit(0));
            Console.ReadLine();
        }
    }
}
