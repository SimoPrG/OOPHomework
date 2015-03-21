namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    [Serializable]
    public class Student
    {
        private static string telRegex = @"^[+]{0,1}[\d ]+$"; // this regex matches all phone numbers which either have '+' or not at the beginning and contain only digits and spaces.
        private static string emailRegex = @"^([a-zA-Z0-9_\-][a-zA-Z0-9_\+\-\.]{0,49}[a-zA-Z0-9_\-])@(([a-zA-Z0-9][a-zA-Z0-9\-]{0,49}\.)+[a-zA-Z]{2,4})$";
        private string tel;
        private string email;

        private List<double> marks;

        public Student(
            string firstName, string lastName, int age, string fn, string tel, string email, List<double> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public string FN { get; private set; }

        public string Tel
        {
            get
            {
                return this.tel;
            }

            private set
            {
                if (!Regex.IsMatch(value, telRegex))
                {
                    throw new FormatException("The Tel format is invalid!");
                }

                this.tel = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            private set
            {
                if (!Regex.IsMatch(value, emailRegex))
                {
                    throw new FormatException("The Email format is invalid!");
                }

                this.email = value;
            }
        }

        public List<double> Marks
        {
            get
            {
                return this.marks.Clone();
            }

            private set
            {
                this.marks = value;
            }
        }

        public int GroupNumber { get; private set; }

        public override string ToString()
        {
            string marks = string.Join(", ", this.Marks);
            return string.Format(
                "{0} {1}; age: {2}; FN: {3}; tel. {4}; email: {5}; marks: {6}; group number: {7}",
                this.FirstName, this.LastName, this.Age, this.FN, this.Tel, this.Email, marks, this.GroupNumber);
        }
    }
}
