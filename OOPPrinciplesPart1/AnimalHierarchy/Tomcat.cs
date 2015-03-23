namespace AnimalHierarchy
{
    using System;

    class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, Gender.Male)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Mrrr!");
        }
    }
}
