/*Problem 5. Generic class

    Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
    Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
    Implement methods for adding element, accessing element by index, removing element by index, inserting element at given
    position, clearing the list, finding element by its value and ToString().
    Check all input parameters to avoid accessing elements at invalid positions.
*/
/*Problem 6. Auto-grow

    Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
*/
/*Problem 7. Min and Max

    Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the GenericList<T>.
    You may need to add a generic constraints for the type T.
*/

namespace Generic
{
    using System;

    public class GenericMain
    {
        public static void Main()
        {
            double? a = 23;
            double? b = 1.2134;
            double? c = -234.24;

            List<double?> myList = new List<double?>(0);
            myList.Add(a);
            myList.Insert(1, b);
            myList.Add(c);
            Console.WriteLine(myList.ToString());

            Console.WriteLine("The index of {0} is {1}", c, myList.Find(c));

            myList.RemoveAt(0);
            Console.WriteLine(myList.ToString());

            myList.Clear();
            Console.WriteLine(myList.ToString());

            myList.Add(c);
            myList.Add(a);
            Console.WriteLine(myList.Min());
            Console.WriteLine(myList.Max());
        }
    }
}
