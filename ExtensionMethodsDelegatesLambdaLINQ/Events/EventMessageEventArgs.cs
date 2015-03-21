namespace Events
{
    using System;

    public class EventMessageEventArgs : EventArgs
    {
        private string message;

        public EventMessageEventArgs(string s)
        {
            this.Message = s;
        }

        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }
    }
}