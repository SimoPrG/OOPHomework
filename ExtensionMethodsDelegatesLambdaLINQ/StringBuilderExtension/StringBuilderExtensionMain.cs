/*Problem 1. StringBuilder.Substring

    Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder
    and has the same functionality as Substring in the class String.
*/

namespace StringBuilderExtension
{
    using System.Text;

    class StringBuilderExtensionMain
    {
        static void Main()
        {
            StringBuilder a = new StringBuilder("SABIRAM");
            System.Console.WriteLine(a.Substring(2, 4));
        }
    }
}
