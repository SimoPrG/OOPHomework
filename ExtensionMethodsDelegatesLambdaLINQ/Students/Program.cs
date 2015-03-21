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
/*Problem 9. Student groups

    Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
    Create a List<Student> with sample students. Select only the students that are from group number 2.
    Use LINQ query. Order the students by FirstName.
*/
/*Problem 10. Student groups extensions

    Implement the previous using the same query expressed with extension methods.
*/
/*Problem 11. Extract students by email

    Extract all students that have email in abv.bg. Use string methods and LINQ.
*/
/*Problem 12. Extract students by phone

    Extract all students with phones in Sofia. Use LINQ.
*/
/*Problem 13. Extract students by marks

    Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
*/
/*Problem 14. Extract students with two marks

    Write down a similar program that extracts the students with exactly two marks "2". Use extension methods.
*/
/*Problem 15. Extract marks

    Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
*/
/*Problem 16.* Groups

    Create a class Group with properties GroupNumber and DepartmentName.
    Introduce a property GroupNumber in the Student class.
    Extract all students from "Mathematics" department.
    Use the Join operator.
*/
/*Problem 18. Grouped by GroupNumber

    Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
    Use LINQ.
*/
/*Problem 19. Grouped by GroupName extensions

    Rewrite the previous using extension methods.
*/

namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            System.Console.BufferHeight = 111;
            List<Student> students = new List<Student>
            {
                new Student("Pesho", "Ivanov", 20, "1112131415", "02 967 1111", "naporist@abv.bg", new List<double> {6, 2, 2}, 2),
                new Student("Pesho", "Georgiev", 24, "1112131416", "0888 888888", "pesho1991@gmail.com", new List<double> {4, 2, 2}, 1),
                new Student("Ivan", "Petrov", 25, "1112106417", "+359 2 920 2222", "vankata@mail.bg", new List<double> {6, 6, 6}, 1),
                new Student("Zornica", "Ziumbiuleva", 19, "1112131418", "064 817 1111", "kote@yahoo.com", new List<double> {6, 3, 5}, 2),
                new Student("Bai", "Ivan", 30, "1112106419", "0887 777777", "ivan.baev@abv.bg", new List<double> {5, 4, 5}, 2)
            };

            // Problem 3. First before last
            //Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
            //Use LINQ query operators.

            var studentsWithFirstNameBeforeLastName = FindStudentsWithFirstNameBeforeTheLast(students);
            Console.WriteLine("Problem 3. First before last");
            foreach (var student in studentsWithFirstNameBeforeLastName)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            // Problem 4. Age range
            // Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
            var firstAndLastNamesOfStudentsBetween18And24 =
                from student in students
                where student.Age > 18 && student.Age < 24
                select new { student.FirstName, student.LastName };
            Console.WriteLine("Problem 4. Age range");
            foreach (var firstAndLastName in firstAndLastNamesOfStudentsBetween18And24)
            {
                Console.WriteLine(firstAndLastName);
            }
            Console.WriteLine();

            // Problem 5. Order students
            //Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name
            //in descending order.
            //Rewrite the same with LINQ.
            var studentsOrderedByFirstAndLastName =
                students.OrderBy(s => s.FirstName).ThenBy(s => s.LastName);
            Console.WriteLine("Problem 5. Order students");
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
            Console.WriteLine();

            // Problem 9. Student groups
            //Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
            //Create a List<Student> with sample students. Select only the students that are from group number 2.
            //Use LINQ query. Order the students by FirstName.
            var studentsFromSecondGroup =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;
            Console.WriteLine("Problem 9. Student groups");
            foreach (var student in studentsFromSecondGroup)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            //Problem 10. Student groups extensions
            //Implement the previous using the same query expressed with extension methods.
            var studentsFromSecondGroupExtensions = students.Where(s => s.GroupNumber == 2).OrderBy(s => s.FirstName);
            Console.WriteLine("Problem 10. Student groups extensions");
            foreach (var student in studentsFromSecondGroupExtensions)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            //Problem 11. Extract students by email
            //Extract all students that have email in abv.bg. Use string methods and LINQ.
            var studentsInAbv_bg =
                from student in students
                where student.Email.EndsWith("@abv.bg")
                select student;
            Console.WriteLine("Problem 11. Extract students by email");
            foreach (var student in studentsInAbv_bg)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            //Problem 12. Extract students by phone
            //Extract all students with phones in Sofia. Use LINQ.
            var studentsWithSofiaTel =
                from student in students
                where Regex.IsMatch(student.Tel, @"^(02)|((\+|00) *359 *2)")
                select student;
            Console.WriteLine("Problem 12. Extract students by phone");
            foreach (var student in studentsWithSofiaTel)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            //Problem 13. Extract students by marks
            //Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
            var studentWithExcellent =
                from student in students
                where student.Marks.Contains(6)
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks };
            Console.WriteLine("Problem 13. Extract students by marks");
            foreach (var student in studentWithExcellent)
            {
                Console.WriteLine(student.FullName + " marks: " + string.Join(", ", student.Marks));
            }
            Console.WriteLine();

            //Problem 14. Extract students with two marks
            //Write down a similar program that extracts the students with exactly two marks "2". Use extension methods.
            var studentsWithTwoMarks = students
                .Where(s => s.Marks.Count(m => m == 2) == 2)
                .Select(s => new { FullName = s.FirstName + " " + s.LastName, Marks = s.Marks });
            Console.WriteLine("Problem 14. Extract students with two marks");
            foreach (var student in studentsWithTwoMarks)
            {
                Console.WriteLine(student.FullName + " marks: " + string.Join(", ", student.Marks));
            }
            Console.WriteLine();

            //Problem 15. Extract marks
            //Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
            var marksOf2006Class = students
                .Where(s => s.FN[5] == '0' && s.FN[6] == '6').SelectMany(s => s.Marks);
            Console.WriteLine("Problem 15. Extract marks");
            foreach (var mark in marksOf2006Class)
            {
                Console.WriteLine(mark);
            }
            Console.WriteLine();

            //Problem 16.* Groups
            //Create a class Group with properties GroupNumber and DepartmentName.
            //Introduce a property GroupNumber in the Student class.
            //Extract all students from "Mathematics" department.
            //Use the Join operator.
            HashSet<Group> groups = new HashSet<Group>{new Group(1, "Mathematics"), new Group(2, "Programming")};
            var mathStudents =
                from groupe in groups
                where groupe.DepartmentName == "Mathematics"
                join student in students on groupe.GroupNumber equals student.GroupNumber
                select student;
            Console.WriteLine("Problem 16.* Groups");
            foreach (var student in mathStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            //Problem 18. Grouped by GroupNumber
            //Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
            //Use LINQ.
            var groupedByGroupNumber =
                from student in students
                group student by student.GroupNumber into newGroup
                orderby newGroup.Key
                select newGroup;
            Console.WriteLine("Problem 18. Grouped by GroupNumber");
            foreach (var group in groupedByGroupNumber)
            {
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine();
            }

            //Problem 19. Grouped by GroupName extensions
            //Rewrite the previous using extension methods.
            var groupedByGroupNumberExtensions = students.GroupBy(s => s.GroupNumber).OrderBy(g => g.Key);
            Console.WriteLine("Problem 19. Grouped by GroupName extensions");
            foreach (var group in groupedByGroupNumberExtensions)
            {
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine();
            }
        }

        private static IEnumerable<Student> FindStudentsWithFirstNameBeforeTheLast(IEnumerable<Student> students)
        {
            var studentsWithFirstNameBeforeLastName =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;
            return studentsWithFirstNameBeforeLastName;
        }
    }
}
