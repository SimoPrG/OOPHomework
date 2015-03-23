namespace SchoolClasses
{
    public class Discipline : ICommentable
    {
        public Discipline(string name, uint numberOfLectures, uint numberOfExcercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExcercises = numberOfExcercises;
        }

        public string Name { get; private set; }

        public string Comment { get; set; }

        public uint NumberOfLectures { get; private set; }

        public uint NumberOfExcercises { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}: lectures {1}, excercises {2}", this.Name, this.NumberOfLectures, this.NumberOfExcercises);
        }
    }
}
