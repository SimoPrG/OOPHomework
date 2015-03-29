namespace AnimalHierarchy
{
    using System;

    public abstract class Animal : ISound
    {
        private string name;
        private int age;
        private Gender sex;

        public Animal(string name, int age, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

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
                    throw new ArgumentException("The Name cannot be null or white spaces.");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The Age cannot be negative.");
                }

                this.age = value;
            }
        }

        public Gender Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        public abstract void MakeSound();
    }
}
