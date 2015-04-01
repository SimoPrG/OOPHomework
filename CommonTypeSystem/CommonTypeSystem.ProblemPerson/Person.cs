/*Problem 4. Person class

    Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. Override ToString()
    to display the information of a person and if age is not specified – to say so.
    Write a program to test this functionality.
*/

namespace CommonTypeSystem.ProblemPerson
{
    using System;

    public class Person
    {
        private string name;

        public Person(string name)
            : this(name, null)
        {
        }

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int? Age { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The Name cannot be null or white space.");
                }

                this.name = value;
            }
        }

        public override string ToString()
        {
            return string.Format("name: {0}, age: {1}", Name, Age == null ? "unspecified" : Age.ToString());
        }
    }
}