/*Problem 3. Animal hierarchy

    Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. Dogs, frogs and cats are Animals.
    All animals can produce sound (specified by the ISound interface). Kittens and tomcats are cats. All animals are described by age,
    name and sex. Kittens can be only female and tomcats can be only male. Each animal produces a specific sound.
    Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static method
    (you may use LINQ).
*/

namespace AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AnimalHierarchyTest
    {
        public static void Main()
        {
            Animal[] animals = new Animal[]
            {
                new Dog("Sharo", 2, Gender.Male),
                new Cat("Maca", 5, Gender.Female),
                new Frog("Antracid", 0, Gender.Male),
                new Tomcat("Tom", 3),
                new Kitten("Pussy", 1)
            };

            Console.WriteLine("Animals average age is {0}.\n", CalculateAnimalsAverageAge(animals));

            foreach (var animal in animals)
            {
                animal.MakeSound();
            }
        }

        public static double CalculateAnimalsAverageAge(IEnumerable<Animal> animals)
        {
            var averageAge =
                (from animal in animals
                 select animal.Age).Average();

            return averageAge;
        }
    }
}
