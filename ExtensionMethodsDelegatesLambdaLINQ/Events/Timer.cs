namespace Events
{
    using System;
    using System.Threading;

    public class Timer
    {
        private const int InMilliseconds = 1000; // One second is 1000 miliseconds
        private int seconds;
        private int secondsElapsed = 0;

        public Timer(int seconds)
        {
            this.Seconds = seconds;
        }

        public event EventHandler<EventMessageEventArgs> TimeElapsedEvent;

        public int Seconds
        {
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
                this.OnTimeElapsedEvent(new EventMessageEventArgs(string.Format("{0} seconds elapsed", this.secondsElapsed)));
                this.secondsElapsed += this.seconds;
                Thread.Sleep(this.seconds * InMilliseconds);
            }
        }

        // Wrap event invocations inside a protected virtual method 
        // to allow derived classes to override the event invocation behavior 
        protected virtual void OnTimeElapsedEvent(EventMessageEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of 
            // a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            EventHandler<EventMessageEventArgs> handler = this.TimeElapsedEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Message += string.Format(" at {0}", DateTime.Now.ToString());

                // Use the () operator to raise the event.
                handler(this, e);
            }
        }
    }
}
