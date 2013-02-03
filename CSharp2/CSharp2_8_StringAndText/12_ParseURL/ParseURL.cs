using System;

class ParseURL
{
    static string ExtractProtocol(string url)
    {
        int index = url.IndexOf(':');
        return url.Substring(0, index);
    }
    static string ExtractServer(string url)
    {
        int start = url.IndexOf('/') + 2;
        int end = url.IndexOf('/', start);
        return url.Substring(start, end-start);
    }
    static string ExtractResource(string url)
    {
        int start = 0;
        for (int i = 0; i < 3; i++)
        {
            start = url.IndexOf('/', start+1);
        }
        return url.Substring(start);
    }
    static void Main()
    {
        string url = "http://telerikacademy.com/Courses/Courses/Details/20";
        Console.WriteLine(ExtractProtocol(url));
        Console.WriteLine(ExtractServer(url));
        Console.WriteLine(ExtractResource(url));
    }
}
