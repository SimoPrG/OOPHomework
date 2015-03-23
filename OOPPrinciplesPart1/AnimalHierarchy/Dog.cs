namespace AnimalHierarchy
{
    using System;
    class Dog : Animal
    {
        public Dog(string name, int age, Gender sex) : base(name, age, sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Bau-bau!");
        }
    }
}
