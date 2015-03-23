namespace AnimalHierarchy
{
    using System;
    class Cat : Animal
    {
        public Cat(string name, int age, Gender sex)
            : base(name, age, sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }
}
