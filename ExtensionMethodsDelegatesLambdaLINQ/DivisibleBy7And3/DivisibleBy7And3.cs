/*Problem 6. Divisible by 7 and 3

    Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
    Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
*/
    
using System;
using System.Linq;

delegate void SimpleDelegate(string param);

class DivisibleBy7And3
{
    static void Main()
    {
        var array = new[] {3, 2, 2, 7, 21, 42, 0, -21, -15, -3, - 7};

        var numbersDevisibleBy7And3 = array.Where(x => x % 21 == 0);
        foreach (var number in numbersDevisibleBy7And3)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();

        var numbersDevisibleBy7And3LINQ =
            from number in array
            where number % 21 == 0
            select number;
        foreach (var number in numbersDevisibleBy7And3LINQ)
        {
            Console.WriteLine(number);
        }
    }
}
