/*Problem 2. Students and workers

    Define abstract class Human with first name and last name. Define new class Student which is derived from Human and has
    new field – grade. Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and method
    MoneyPerHour() that returns money earned by hour by the worker. Define the proper constructors and properties for this
    hierarchy.
    Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
    Initialize a list of 10 workers and sort them by money per hour in descending order.
    Merge the lists and sort them by first name and last name.
*/

namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StudentsAndWorkersTest
    {
        public static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("Petur", "Petrov", 0),
                new Student("Ivan", "Ivanov", 3.01),
                new Student("Todor", "Todorov", 5.99),
                new Student("Hristo", "Hristov", 3.5),
                new Student("Dan", "Kolov", 6),
                new Student("Chang", "Xin", 4),
                new Student("Vasil", "Vasilev", 6),
                new Student("Maya", "Mileva", 5),
                new Student("Ivet", "Lalova", 10),
                new Student("Barack", "Obama", 2)
            };
            Console.WriteLine("Students unsorted:");
            Console.WriteLine(PrintCollection(students));

            var sortedStudents = students.OrderBy(s => s.Grade);

            Console.WriteLine("Students sorted:");
            Console.WriteLine(PrintCollection(sortedStudents));

            List<Worker> workers = new List<Worker>
            {
                new Worker("Ivan", "Petrov", 200, 8),
                new Worker("Petar", "Ivanov", 300, 8),
                new Worker("Car", "Pluh", 1, 24),
                new Worker("Su", "Smith", 500, 7),
                new Worker("Kuc", "Gulab", 0, 16),
                new Worker("Lili", "Ivanova", 0, 0),
                new Worker("Osman", "Pasha", 1000, 0),
                new Worker("Pope", "Francis", 1000000, 1),
                new Worker("Baba", "Iaga", 10, 8),
                new Worker("Nu", "Pogodi", 5, 2),
            };

            Console.WriteLine("Workers unsorted:");
            Console.WriteLine(PrintCollection(workers));

            var sortedWorkers = workers.OrderByDescending(w => w.MoneyPerHour());

            Console.WriteLine("Workers sorted:");
            Console.WriteLine(PrintCollection(sortedWorkers));

            var sortedMergedList = students.Concat<Human>(workers).OrderBy(h => h.FirstName).ThenBy(h => h.LastName);
            Console.WriteLine("Humans sorted:");
            Console.WriteLine(PrintCollection(sortedMergedList));
        }

        private static string PrintCollection<T>(IEnumerable<T> collection)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in collection)
            {
                builder.AppendLine(item.ToString());
            }

            return builder.ToString();
        }
    }
}
