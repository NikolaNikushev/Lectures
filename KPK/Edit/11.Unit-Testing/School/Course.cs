using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class Course
    {
        private string name;
        private readonly List<Student> students = new List<Student>();

        public Course(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new NullReferenceException("The course name cannot be null or empty!");
            }
            else if (String.IsNullOrWhiteSpace(name))
            {
                throw new NullReferenceException("The course name cannot be white spaces!");
            }
            else
            {
                this.name = name;
                this.students = new List<Student>();
            }
        }

        public string Name
        {
            get
            { 
                return this.name;
            }
            private set 
            {
                this.name = value;

            } 
        }
        public List<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public void AddStudent(Student student)
        {
            if(this.students.Contains(student))
            {
                throw new NullReferenceException("Student is registered in this course!");
            }
            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if(!this.students.Contains(student))
            {
                throw new NullReferenceException("Student is not registered in this course!");
            }
            this.students.Remove(student);
        }

        public void DisplayCourseFullInfoToConsole()
        {
            Console.WriteLine(this.RetrieveFullInfo());
        }

        public void DisplayCourseInfoToConsole()
        {
            Console.WriteLine(this.RetrieveInfo());
        }
        
        //To be used for testing with Unit Tests
        public string GetFullInfo()
        {
            return this.RetrieveFullInfo();
        }

        //To be used for testing with Unit Tests
        public string GetInfo()
        {
            return this.RetrieveInfo();
        }

        private string RetrieveFullInfo()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.RetrieveInfo());
            result.AppendLine("The student attending this course are:");
            foreach (Student student in this.students)
            {
                result.AppendLine(student.Name + " -  " + student.Number);
            }
            return result.ToString();
        }

        private string RetrieveInfo()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Course name : {0}", this.name);
            result.AppendLine();
            return result.ToString();
        }
    }
}
