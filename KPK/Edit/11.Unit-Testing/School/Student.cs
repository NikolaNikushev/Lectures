using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace School
{
    public class Student
    {
        private string name;
        private uint number;
        private List<Course> attendingCourse = new List<Course>();

        public Student(string name, uint number)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                throw new NullReferenceException("The student name was not entered!");
            }
            else if (number < School.MinStudentNumber || number > School.MaxStudentNumber)
            {
                throw new IndexOutOfRangeException("The student number must be between " +
                    School.MinStudentNumber + " and " + School.MaxStudentNumber +" inclusive!");
            }
            else
            {
                this.name = name;
                this.number = number;
                this.attendingCourse = new List<Course>();
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

        public uint Number
        {
            get
            {
                return this.number;
            }
            private set
            {
                this.number = value;
            }
        }

        public List<Course> AttendedCourse 
        {
            get
            {
                return this.attendingCourse;
            }
        }

        public void AddCourse(Course course)
        {
            this.attendingCourse.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null || !this.attendingCourse.Contains(course))
            {
                throw new NullReferenceException("Student is not registered to this course");
            }
            this.attendingCourse.Remove(course);
            course.RemoveStudent(this);
        }

        public string DisplayCourseInfoToConsoleAndReturnValue()
        {
            DisplayCoursesFullInfoToConsole();

            StringBuilder studentCourses = new StringBuilder();
            studentCourses.AppendLine(this.Name + " is attending:");
            studentCourses.AppendLine(this.GetCoursesFullInfo());
            return studentCourses.ToString();
        }

        public string DisplayFullCourseInfoToConsoleAndReturnValue()
        {
            DisplayCoursesInfoToConsole();

            StringBuilder studentCourses = new StringBuilder();
            studentCourses.AppendLine(this.Name + " is attending:");
            studentCourses.AppendLine(this.GetCoursesInfo());
            return studentCourses.ToString();
        }

        public void DisplayCoursesInfoToConsole()
        {
            Console.WriteLine(this.Name + " is attending:");
            Console.WriteLine(this.GetCoursesInfo());
        }

        public void DisplayCoursesFullInfoToConsole()
        {
            Console.WriteLine(this.Name + " is attending:");
            Console.WriteLine(this.GetCoursesFullInfo());
        }

        private string GetCoursesInfo()
        {
            StringBuilder result = new StringBuilder();
            foreach (Course course in this.attendingCourse)
            {
                result.AppendLine(course.GetInfo());
            }
            return result.ToString();
        }

        private string GetCoursesFullInfo()
        {
            StringBuilder result = new StringBuilder();
            foreach (Course course in this.attendingCourse)
            {
                result.AppendLine(course.GetFullInfo());
            }
            return result.ToString();
        }
    }
}
