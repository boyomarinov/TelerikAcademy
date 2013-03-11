using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_TimerEvents
{
    public delegate void TimeElapsedEventHandler(object sender, TimeElapsedEventArgs args);

    public class TimeElapsedEventArgs : EventArgs
    {
        public TimeElapsedEventArgs(int seconds)
        {
            this.Seconds = seconds;
        }

        public int Seconds { get; set; }
    }
}
