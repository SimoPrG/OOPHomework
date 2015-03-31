/*Problem 1. Student class

    Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, mobile
    phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, universities and faculties.
    Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
*/
namespace CommonTypeSystem.ProblemStudent
{
    using System;

    public class Student
    {
        private readonly int ssn;
        private string firstName;
        private string middleName;
        private string lastName;
        private int course;

        public Student()
        {
        }

        public Student(
            string firstName, string middleName, string lastName, int ssn, string permanentAddress, string mobilePhone,
            string email, int course, Universities university, Faculties faculty, Specialties specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.ssn = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The FirstName cannot be null or white spaces.");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The FirstName cannot be null or white spaces.");
                }

                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The FirstName cannot be null or white spaces.");
                }

                this.lastName = value;
            }
        }

        public int SSN
        {
            get { return this.ssn; }
        }

        public string PermanentAddress { get; private set; }

        public string MobilePhone { get; private set; }

        public string Email { get; private set; }

        public int Course
        {
            get
            {
                return this.course;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("The course cannot be less than 1.");
                }

                this.course = value;
            }
        }

        public Universities University { get; private set; }

        public Faculties Faculty { get; private set; }

        public Specialties Specialty { get; private set; }

        public override string ToString()
        {
            return string.Format(
                "{0}, {1}, {2}, ssn: {3}, specialty: {4}, course: {5}, faculty: {6}, university: {7}, mail: {8}, mobile: {9}",
                this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Specialty,
                this.Course, this.Faculty, this.University, this.Email, this.MobilePhone);
        }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;

            if (student == null)
            {
                return false;
            }

            if (!this.FirstName.Equals(student.FirstName))
            {
                return false;
            }

            if (!this.MiddleName.Equals(student.MiddleName))
            {
                return false;
            }

            if (!this.SSN.Equals(student.SSN))
            {
                return false;
            }

            if (!this.University.Equals(student.University))
            {
                return false;
            }

            if (!this.Faculty.Equals(student.Faculty))
            {
                return false;
            }

            if (!this.Specialty.Equals(student.Specialty))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return
                this.firstName.GetHashCode() ^ this.middleName.GetHashCode() ^ this.SSN.GetHashCode()
                ^ this.University.GetHashCode() ^ this.Faculty.GetHashCode() ^ this.Specialty.GetHashCode();
        }

        public static bool operator ==(Student a, Student b)
        {
            return object.Equals(a, b);
        }

        public static bool operator !=(Student a, Student b)
        {
            return !object.Equals(a, b);
        }
    }
}
