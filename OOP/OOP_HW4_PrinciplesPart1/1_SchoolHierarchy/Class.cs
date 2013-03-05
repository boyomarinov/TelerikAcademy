using System;
using System.Collections.Generic;
using System.Text;

namespace _1_SchoolHierarchy
{
    class Class : Comment
    {
        private string className;
        List<Teacher> teachers;
        List<Student> students;

        #region Constructors
        public Class(string className)
            : base()
        {
            this.className = className;
            this.teachers = new List<Teacher>();
            this.students = new List<Student>();
        }

        public Class(string className, List<Teacher> teachers, List<Student> students)
            : base()
        {
            this.className = className;
            this.teachers = teachers;
            this.students = students;
        }

        public Class(string className, List<Teacher> teachers, List<Student> students, string comment)
            : base(comment)
        {
            this.className = className;
            this.teachers = teachers;
            this.students = students;
        }
        #endregion

        //Property
        public string ClassName
        {
            get { return this.className; }
            set { this.className = value; }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(this.className);

            output.AppendLine("Teachers:");
            foreach (Teacher teacher in this.teachers)
            {
                output.AppendLine(teacher.ToString());
            }
            output.AppendLine();

            output.AppendLine("Students:");
            foreach (Student student in this.students)
            {
                output.AppendLine(student.ToString());
            }

            return output.ToString();
        }

        #region AddInfo
        public void AddTeacher(Teacher t)
        {
            if (!this.teachers.Contains(t))
            {
                this.teachers.Add(t);
            }
            else
            {
                Console.WriteLine("This teacher is already assigned to this class.");
            }
        }

        public void AddStudent(Student st)
        {
            if (!this.students.Contains(st))
            {
                this.students.Add(st);
            }
            else
            {
                Console.WriteLine("This student is already assigned to this class.");
            }
        }
        #endregion
    }
}
