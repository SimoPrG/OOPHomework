/*Problem 2. IEnumerable extensions

    Implement a set of extension methods for IEnumerable<T> that implement the following group functions:
    sum, product, min, max, average.
*/

namespace IEnumerableExtensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static T SumOfEnumerable<T>(this IEnumerable<T> collection)
        {
            dynamic sum = 0;
            foreach (T item in collection)
            {
                sum += item;
            }

            return sum;
        }

        public static T AverageOfEnumerable<T>(this IEnumerable<T> collection)
        {
            dynamic sum = 0;
            int count = 0;
            foreach (T item in collection)
            {
                sum += item;
                count++;
            }

            return sum / count;
        }

        public static T ProductOfEnumerable<T>(this IEnumerable<T> collection)
        {
            T product = (dynamic)1;
            foreach (T item in collection)
            {
                product *= (dynamic)item;
            }

            return product;
        }

        public static T MinOfEnumerable<T>(this IEnumerable<T> collection)
        {
            return collection.Min();
        }

        public static T MaxOfEnumerable<T>(this IEnumerable<T> collection)
        {
            return collection.Max();
        }
    }
}
