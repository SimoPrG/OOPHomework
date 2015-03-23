namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;

    public class Class : ICommentable
    {
        private static HashSet<string> uniqueTextIDs;

        private string textID;
        private List<Student> students;
        private List<Teacher> teachers;

        static Class()
        {
            uniqueTextIDs = new HashSet<string>();
        }

        public Class(string textID)
        {
            this.TextID = textID;
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public string TextID
        {
            get
            {
                return this.textID;
            }

            private set
            {
                if (uniqueTextIDs.Contains(value))
                {
                    throw new ArgumentException("A class with the same TextID already exists.");
                }

                uniqueTextIDs.Add(value);
                this.textID = value;
            }
        }

        public string Comment { get; set; }

        public List<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }

            private set
            {
                this.students = value;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return new List<Teacher>(this.teachers);
            }

            private set
            {
                this.teachers = value;
            }
        }

        public override string ToString()
        {
            return this.TextID;
        }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }
    }
}
