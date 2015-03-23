namespace SchoolClasses
{
    public class Student : Person
    {
        private static uint id = 1;

        private uint uniqueID;

        public Student(string name) : base(name)
        {
            this.uniqueID = id++;
        }

        public uint UniqueID
        {
            get { return this.uniqueID; }
        }

        public override string ToString()
        {
            return base.ToString() + " ID: " + this.UniqueID;
        }
    }
}
