/*Problem 3. Range Exceptions

    Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range.
    It should hold error message and a range definition [start … end].
    Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime>
    by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].
*/

namespace RangeExceptions
{
    using System;
    using System.Collections.Generic;

    class InvalidRangeExceptionTest
    {
        static void Main()
        {
            const int lowInt = 1;
            const int highInt = 100;

            DateTime lowDate = new DateTime(1980, 1, 1);
            DateTime highDate = new DateTime(2013, 12, 31);

            TryCatch(lowInt, highInt, 42);

            TryCatch(lowDate, highDate, new DateTime(1989, 11, 9));
        }

        private static void TryCatch<T>(T low, T high, T variable)
        {
            try
            {
                if (Comparer<T>.Default.Compare(low, variable) <= 0 && Comparer<T>.Default.Compare(variable, high) <= 0)
                {
                    throw new InvalidRangeException<T>("The value is in the invalid range", low, high);
                }
            }
            catch (InvalidRangeException<T> ex)
            {
                Console.WriteLine("{0}: {1} - {2}", ex.Message, ex.StartOfRange, ex.EndOfRange);
            }
        }
    }
}
