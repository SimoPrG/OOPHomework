namespace StudentsAndWorkers
{
    using System;

    public class Worker : Human
    {
        private const int WorkDays = 5;

        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The WeekSalary cannot be negative.");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The WorkHoursPerDay cannot be negative.");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            if (this.WeekSalary == 0 || this.WorkHoursPerDay == 0)
            {
                return 0m;
            }

            return this.WeekSalary / (decimal)(this.WorkHoursPerDay * WorkDays);
        }

        public override string ToString()
        {
            return base.ToString() + "\tmoney per hour: " + this.MoneyPerHour();
        }
    }
}
