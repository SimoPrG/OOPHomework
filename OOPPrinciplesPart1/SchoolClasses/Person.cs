namespace SchoolClasses
{
    public class Person : ICommentable
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public string Comment { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
