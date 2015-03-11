/*Problem 8. Calls

    Create a class Call to hold a call performed through a GSM.
    It should contain date, time, dialled phone number and duration (in seconds).
*/

namespace MobilePhoneDevice
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public class Call
    {
        private DateTime dateAndTime;
        private string dialledNumber;
        private TimeSpan duration;
        private string regex = @"^[+]{0,1}[\d ]+$"; // this regex matches all phone numbers which either have '+' or not at the beginning and contain only digits and spaces.

        public Call(string dateAndTime, string dialledNumber, double duration)
        {
            this.DateAndTime = dateAndTime;
            this.DialledNumber = dialledNumber;
            this.Duration = duration;
        }

        public string DateAndTime
        {
            get
            {
                return this.dateAndTime.ToString("dd.MM.yyyy HH:mm:ss");
            }
            private set
            {
                this.dateAndTime = DateTime.ParseExact(value, "d.M.yyyy H:m:s", CultureInfo.InvariantCulture);
            }
        }

        public string DialledNumber
        {
            get
            {
                return this.dialledNumber;
            }
            private set
            {
                if (!Regex.IsMatch(value, regex))
                    throw new FormatException("The DialledNumber format is invalid!");
                this.dialledNumber = value;
            }
        }

        public double Duration
        {
            get
            {
                return this.duration.TotalSeconds;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("The Duration cannot be negative!");
                this.duration = TimeSpan.FromSeconds(value);
            }
        }

        public override string ToString()
        {
            return string.Format("[DateAndTime: {0}; DialledNumber: {1}; Duration: {2} s]", DateAndTime, DialledNumber, Duration);
        }
    }
}
