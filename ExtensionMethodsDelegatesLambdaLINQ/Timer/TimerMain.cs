/*Problem 7. Timer

    Using delegates write a class Timer that can execute certain method at each t seconds.
*/

namespace Timer
{
    using System;

    public class TimerMain
    {
        public static void Main()
        {
            // I have extended this task a little bit. The constructor of the Timer class can take multiple arguments which are methods.
            // In this example the first method is predifined, the second is a lamda, and the third is anonymous method.
            Timer timer = new Timer(2, PrintSomething, () => Console.WriteLine("there!"), delegate() { Console.WriteLine("How are you?"); });
            timer.Start();
        }

        public static void PrintSomething()
        {
            Console.Write("Hello, ");
        }
    }
}
