/*Problem 7. Timer

    Using delegates write a class Timer that can execute certain method at each t seconds.
*/

namespace Timer
{
    using System;
    using System.Threading;

    public class Timer
    {
        private const int InMilliseconds = 1000; // One second is 1000 miliseconds
        private int seconds;

        public Timer(params TimerDlg[] methods) : this(1, methods)
        {
        }

        public Timer(int seconds, params TimerDlg[] methods)
        {
            this.Seconds = seconds;
            foreach (var method in methods)
            {
                this.Methods += method;
            }
        }

        public delegate void TimerDlg();

        private TimerDlg Methods { get; set; }

        public int Seconds
        {
            get
            {
                return this.seconds;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("The time interval cannot be less than 1.");
                }

                this.seconds = value;
            }
        }

        public void Start()
        {
            while (true)
            {
                this.Methods();
                Thread.Sleep(this.Seconds * InMilliseconds);
            }
        }
    }
}
