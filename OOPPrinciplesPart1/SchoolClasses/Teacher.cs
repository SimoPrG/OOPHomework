namespace SchoolClasses
{
    using System.Collections.Generic;

    public class Teacher : Person
    {
        private List<Discipline> disciplines;

        public Teacher(string name) : base(name)
        {
            this.Disciplines = new List<Discipline>();
        }

        public List<Discipline> Disciplines
        {
            get
            {
                return new List<Discipline>(this.disciplines);
            }

            private set
            {
                this.disciplines = value;
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public override string ToString()
        {
            string disciplines = string.Join(", ", this.Disciplines);
            return base.ToString() + " disciplines: " + disciplines;
        }
    }
}
