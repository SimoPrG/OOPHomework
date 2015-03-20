/*Problem 2. IEnumerable extensions

    Implement a set of extension methods for IEnumerable<T> that implement the following group functions:
    sum, product, min, max, average.
*/

namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var collection = new HashSet<double> { 4.124, -2.2134, 5.423 };

            Console.WriteLine(collection.SumOfEnumerable());
            Console.WriteLine(collection.ProductOfEnumerable());
            Console.WriteLine(collection.MinOfEnumerable());
            Console.WriteLine(collection.MaxOfEnumerable());
            Console.WriteLine(collection.AverageOfEnumerable());
        }
    }
}
