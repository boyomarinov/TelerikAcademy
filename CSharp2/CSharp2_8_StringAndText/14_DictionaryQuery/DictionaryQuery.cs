using System;

class DictionaryQuery
{
    static string QueryResult(string[] dictionary, string word)
    {
        string result = string.Empty;
        for (int i = 0; i < dictionary.Length; i++)
        {
            int len = dictionary[i].IndexOf('–');
            if(len == -1)
            {
                continue;
            }
            string key = dictionary[i].Substring(0, len - 1);
            if (key == word)
            {
                result = dictionary[i].Substring(len + 2);
            }
        }
        return result;
    }
    static void Main()
    {
        string[] dictionary = 
            {".NET – platform for applications from Microsoft",
            "CLR – managed execution environment for .NET",
            "namespace – hierarchical organization of classes"};
        string search = "namespace";
        Console.WriteLine(QueryResult(dictionary, search));
    }
}
