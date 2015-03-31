namespace CommonTypeSystem.ProblemStudent
{
    using System;

    class StudentTest
    {
        static void Main()
        {
            Student ivan = new Student(
                "Ivan", "Ivanov", "Ivanov", 123, "Sofia Mladost 1", "0888888888", "ivan@abv.bg", 1,
                Universities.NewBulgarianUniversity, Faculties.Business, Specialties.BusinessManagementAndEntrepreneurship);

            Console.WriteLine(ivan);

            Console.WriteLine();

            Student vankata = ivan.Clone() as Student;

            Console.WriteLine(vankata);

            Console.WriteLine();

            Console.WriteLine(ivan.Equals(vankata));
            Console.WriteLine(ivan.GetHashCode());
            Console.WriteLine(vankata.GetHashCode());
            vankata.Specialty = Specialties.IndustrialBusiness;
            Console.WriteLine(ivan.Equals(vankata));
            Console.WriteLine(vankata.GetHashCode());

            Student ana = new Student(
                "Ana", "Ivanova", "Ivanova", 123, "Sofia Mladost 1", "0888888888", "ivan@abv.bg", 1,
                Universities.UniversityOfNationalAndWorldEconomy, Faculties.Business, Specialties.BusinessManagementAndEntrepreneurship);

            Console.WriteLine(ana);

            Console.WriteLine();

            Console.WriteLine(ivan.Equals(ana));
            Console.WriteLine(ana.GetHashCode());

            Console.WriteLine(ana.CompareTo(ivan));
            Console.WriteLine(ivan.CompareTo(vankata));
        }
    }
}
