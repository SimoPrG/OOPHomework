namespace StudentsAndWorkers
{
    public class Student : Human
    {
        private double grade;

        public Student(string firstName, string lastName, double grade) : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public double Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "\tGrade:\t" + this.Grade;
        }
    }
}
