using System;
using System.Collections.Generic;
using System.Threading;

namespace _8_TimerEvents
{
    class TestClass
    {
        //Message to display
        static void PrintMessage(object publisher, TimeElapsedEventArgs eventArgs)
        {
            Console.Clear();
            Console.WriteLine("{0} seconds", eventArgs.Seconds);
        }

        static void Main()
        {
            Timer testTimer = new Timer(1000, 20);

            //hook print method to the delegate
            testTimer.TimeElapsed += new TimeElapsedEventHandler(PrintMessage);

            Thread th = new Thread(new ThreadStart(testTimer.Start));
            th.Start();
        }
    }
}
