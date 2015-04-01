namespace CommonTypeSystem.ProblemPerson
{
    using System;

    public class PersonTest
    {
        static void Main()
        {
            var malakChovek = new Person("Rada", 3);
            Console.WriteLine(malakChovek);

            var dama = new Person("Yavora");
            Console.WriteLine(dama);

            var durtPergish = new Person("Az", 28);
            Console.WriteLine(durtPergish);
        }
    }
}
