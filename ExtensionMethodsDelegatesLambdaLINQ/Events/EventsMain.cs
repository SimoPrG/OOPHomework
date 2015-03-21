/*Problem 8.* Events

    Read in MSDN about the keyword event in C# and how to publish events.
    Re-implement the above using .NET events and following the best practices.
*/

namespace Events
{
    using System;

    public class EventsMain
    {
        public static void Main()
        {
            Timer timer = new Timer(2);
            timer.TimeElapsedEvent += ExecuteThisMethod;
            timer.Start();
        }

        private static void ExecuteThisMethod(object sender, EventMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
