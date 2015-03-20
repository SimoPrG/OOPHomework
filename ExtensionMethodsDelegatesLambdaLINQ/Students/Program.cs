/*Problem 3. First before last

    Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
    Use LINQ query operators.
*/
/*Problem 4. Age range

    Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
*/
/*Problem 5. Order students

    Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name
    in descending order.
    Rewrite the same with LINQ.
*/

namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Student[] students =
            {
                new Student("Pesho", "Ivanov", 20),
                new Student("Pesho", "Georgiev", 24),
                new Student("Ivan", "Petrov", 25),
                new Student("Zornica", "Ziumbiuleva", 19),
                new Student("Bai", "Ivan", 99)
            };

            // Problem 3. First before last

            var studentsWithFirstNameBeforeLastName = FindStudentsWithFirstNameBeforeTheLast(students);

            foreach (var student in studentsWithFirstNameBeforeLastName)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            // Problem 4. Age range
            var firstAndLastNamesOfStudentsBetween18And24 =
                from student in students
                where student.Age > 18 && student.Age < 24
                select new { student.FirstName, student.LastName };

            foreach (var firstAndLastName in firstAndLastNamesOfStudentsBetween18And24)
            {
                Console.WriteLine(firstAndLastName);
            }

            Console.WriteLine();

            // Problem 5. Order students
            var studentsOrderedByFirstAndLastName =
                students.OrderBy(s => s.FirstName).ThenBy(s => s.LastName);

            foreach (var student in studentsOrderedByFirstAndLastName)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            var studentsOrderedWithLINQQuery =
                from student in students
                orderby student.FirstName, student.LastName
                select student;

            foreach (var student in studentsOrderedWithLINQQuery)
            {
                Console.WriteLine(student);
            }
                


        }

        private static IEnumerable<Student> FindStudentsWithFirstNameBeforeTheLast(Student[] students)
        {
            var studentsWithFirstNameBeforeLastName =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;
            return studentsWithFirstNameBeforeLastName;
        }
    }
}
