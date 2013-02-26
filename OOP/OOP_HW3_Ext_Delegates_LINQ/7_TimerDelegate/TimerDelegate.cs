using System;
using System.Collections.Generic;
using System.Threading;

public delegate void Function();

class Timer
{
    private int seconds;

    public Timer(int sec = 0)
    {
        this.seconds = sec;
    }

    public int Seconds
    {
        get { return this.seconds; }
        set { this.seconds = value; }
    }

    public void Start(Function f)
    {
        while (true)
        {
            f();
            Thread.Sleep(this.seconds * 1000);
        }
    }
}

class Tester
{
    static void Main()
    {
        new Timer(1).Start(new Function(() => Console.WriteLine("123"))  + (() => Console.WriteLine("456")));
    }
}
