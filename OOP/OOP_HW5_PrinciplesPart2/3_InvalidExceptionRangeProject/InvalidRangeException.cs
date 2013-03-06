using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidExceptionRangeProject
{
    public class InvalidRangeException<T> : ApplicationException
    {
        public string OutOfRangeMessage { get; set; }
        public T Start { get; set; }
        public T End { get; set; }

        public InvalidRangeException(T start, T end)
            :this(null, start, end)
        { }

        public InvalidRangeException(string message, T start, T end)
        {
            this.OutOfRangeMessage = message;
            this.Start = start;
            this.End = end;
        }
    }
}
