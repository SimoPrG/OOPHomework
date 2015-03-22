/*Problem 17. Longest string

    Write a program to return the string with maximum length from an array of strings.
    Use LINQ.
*/
using System.Collections.Generic;
using System.Linq;

public class LongestStringFinder
{
    public static void Main()
    {
        string[] greetings = { "Hi!", "Hello!", "May God's peace be upon you!" };

        System.Console.WriteLine(FindLongestString(greetings));
    }

    private static string FindLongestString(IEnumerable<string> strings)
    {
        var orderedByDescendingStrings =
            from str in strings
            orderby str.Length descending
            select str;
        return orderedByDescendingStrings.First();
    }
}