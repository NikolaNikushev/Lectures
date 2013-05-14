using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class School
    {
        private string name;
        public const uint MinStudentNumber = 10000;
        public const uint MaxStudentNumber = 99999;
        private List<Course> courses = new List<Course>();
        private List<Student> students = new List<Student>();


        public School(string name)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                throw new NullReferenceException("The school's name was not entered!");
            }
            this.name = name;
            this.courses = new List<Course>();
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public List<Course> Courses 
        {
            get 
            { 
                return this.courses; 
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
            if (this.students.Contains(student))
            {
                throw new InvalidOperationException("Student already is registered!");
            }
            if (StudentNumberIsUsed(student))
            {
                throw new IndexOutOfRangeException("The student number is not unique and it is taken!");
            }
            this.students.Add(student);
        }

        public void AddCourse(Course course)
        {
            if (this.courses.Contains(course))
            {
                throw new ArgumentException("Course already exists!");
            }
            this.courses.Add(course);
        }

        public void AddStudentToCourse(Student student, Course course)
        {
            if (!this.students.Contains(student))
            {
                throw new ArgumentNullException("The student is not registered in" + this.name);
            }
            if (!this.courses.Contains(course))
            {
                throw new NullReferenceException("The course specified does not exist!");
            }

            courses.Find(x => x == course).AddStudent(student);
            student.AddCourse(course);
        }

        public void AddStudentToCourse(Student student, List<Course> coursesToBeAssignedTo)
        {
            foreach (Course course in coursesToBeAssignedTo)
            {
                this.AddStudentToCourse(student, course);
            }
        }

        public void AddStudentToCourse(List<Student> studentsToAssign, List<Course> coursesToBeAssignedTo)
        {
            foreach (Student student in studentsToAssign)
            {
                for (int course = 0; course < coursesToBeAssignedTo.Count(); course++)
                {
                    this.AddStudentToCourse(student, coursesToBeAssignedTo[course]);
                }
            }
        }

        private bool StudentNumberIsUsed(Student student)
        {
            if (this.students.Count > 0)
            {
                foreach (Student studen in students)
                {
                    if (studen.Number.Equals(student.Number))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
