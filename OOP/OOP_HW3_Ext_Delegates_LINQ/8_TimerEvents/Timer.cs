using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8_TimerEvents
{
    public class Timer
    {
        public event TimeElapsedEventHandler TimeElapsed;

        public Timer(int interval, int seconds)
        {
            this.Interval = interval;
            this.Seconds = seconds;
        }

        public int Interval { get; set; }
        public int Seconds { get; set; }

        public void Start()
        {
            while (this.Seconds > 0)
            {
                Thread.Sleep(this.Interval);
                this.Seconds = this.Seconds - 1;

                TimeElapsedEventArgs ev = new TimeElapsedEventArgs(this.Seconds);
                TimeElapsed(this, ev);
            }
        }

    }
}
