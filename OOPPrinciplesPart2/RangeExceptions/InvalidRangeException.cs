//Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range.
//It should hold error message and a range definition [start … end].

namespace RangeExceptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string message, T startOfRange, T endOfRange)
            : this(message, startOfRange, endOfRange, null)
        {
        }

        public InvalidRangeException(string message, T startOfRange, T endOfRange, Exception innerException)
            : base(message, innerException)
        {
            this.StartOfRange = startOfRange;
            this.EndOfRange = endOfRange;
        }

        public T StartOfRange { get; private set; }

        public T EndOfRange { get; private set; }
    }
}
