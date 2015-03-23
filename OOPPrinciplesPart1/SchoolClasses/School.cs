namespace SchoolClasses
{
    using System.Collections.Generic;

    public class School
    {
        private List<Class> classes;

        public School(string name)
        {
            this.Name = name;
            this.Classes = new List<Class>();
        }

        public string Name { get; private set; }

        public List<Class> Classes
        {
            get
            {
                return new List<Class>(this.classes);
            }

            private set
            {
                this.classes = value;
            }
        }

        public void AddClass(Class @class)
        {
            this.classes.Add(@class);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
