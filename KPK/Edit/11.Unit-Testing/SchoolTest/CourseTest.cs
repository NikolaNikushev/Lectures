using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using School;

namespace SchoolTest
{
    [TestClass]
    public class CourseTest
    {
        private School.School testingSchool = new School.School("Testing Academy");
        private List<Student> testingStudents = new List<Student>();
        private List<Course> testingCourses = new List<Course>();

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException), "The student is not registered in")]
        public void AddStudentToNotExistingCourse()
        {
            Course math = new Course("Math");
            testingSchool.AddCourse(math);
            testingCourses.Add(math);

            this.testingStudents.Add(new Student("Pesho", 10000));
            this.testingSchool.AddStudentToCourse(testingStudents[0], math);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException), "The course specified does not exist!")]
        public void AddStudentToCourseHeIsNotRegisterIn()
        {
            Course math = new Course("Math");

            this.testingStudents.Add(new Student("Pesho", 10000));
            testingSchool.AddStudent(testingStudents[0]);
            this.testingSchool.AddStudentToCourse(testingStudents[0], math);
        }

        [TestMethod]
        public void AddNewCourses()
        {
            testingCourses.Add(new Course("Math"));
            Assert.AreEqual("Math", testingCourses[0].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException), "The course name cannot be white spaces!")]
        public void AddNewCoursesThatIsNamedWithWhiteSpaces()
        {
            testingCourses.Add(new Course("                     "));
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException), "The course name cannot be null or empty!")]
        public void AddNewEmptyCourse()
        {
            testingCourses.Add(new Course(""));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "Course already exists!")]
        public void AddExistingCourse()
        {
            testingCourses.Add(new Course("Test"));
            testingSchool.AddCourse(testingCourses[0]);
            testingSchool.AddCourse(testingCourses[0]);
        }

        [TestMethod]
        public void AddCourseToSchoolAndAssignStudentToCourse()
        {
            Student pesho = new Student("Pesho", 12345);
            testingSchool.AddStudent(pesho);

            Course history = new Course("History");
            testingSchool.AddCourse(history);

            this.testingSchool.AddStudentToCourse(pesho, history);
            Assert.AreEqual(1, testingSchool.Courses.Count);
            Assert.AreEqual(1, testingSchool.Courses[0].Students.Count);
            Assert.AreEqual("History", pesho.AttendedCourse[0].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException), "Student is not registered to this course")]
        public void RemoveStudentCourseThatHeIsNotIn()
        {
            Student pesho = new Student("Pesho", 12345);
            testingSchool.AddStudent(pesho);

            Course history = new Course("History");
            testingSchool.AddCourse(history);

            this.testingSchool.AddStudentToCourse(pesho, history);
            Assert.AreEqual(1, testingSchool.Courses.Count);
            Assert.AreEqual(1, testingSchool.Courses[0].Students.Count);
            Assert.AreEqual("History", pesho.AttendedCourse[0].Name);
            pesho.RemoveCourse(history);
            pesho.RemoveCourse(history);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException), "Student is registered in this course!")]
        public void AddCourseToSchoolAndAssignStudentToCourseTwice()
        {
            Student pesho = new Student("Pesho", 12345);
            testingSchool.AddStudent(pesho);

            Course history = new Course("History");
            testingSchool.AddCourse(history);

            this.testingSchool.AddStudentToCourse(pesho, history);
            Assert.AreEqual(1, testingSchool.Courses.Count);
            Assert.AreEqual(1, testingSchool.Courses[0].Students.Count);
            Assert.AreEqual("History", pesho.AttendedCourse[0].Name);
            this.testingSchool.AddStudentToCourse(pesho, history);
        }

        [TestMethod]
        public void AssignMultipleStudentsToCourses()
        {
            testingStudents.Add(new Student("Stefan", 11111));
            testingStudents.Add(new Student("Martin", 12344));
            testingStudents.Add(new Student("Felipe", 32154));
            foreach (Student student in testingStudents)
            {
                testingSchool.AddStudent(student);
            }

            testingCourses.Add(new Course("Iconomics"));
            testingCourses.Add(new Course("Bulgarian"));
            foreach (Course course in testingCourses)
            {
                testingSchool.AddCourse(course);
            }

            this.testingSchool.AddStudentToCourse(
                new List<Student>()
                {
                    this.testingStudents[0],
                    this.testingStudents[1],
                    this.testingStudents[2]
                },
                new List<Course>()
                {
                    this.testingCourses[0],
                    this.testingCourses[1]
                });
            foreach (Student student in testingStudents)
            {
                Assert.AreEqual(2, student.AttendedCourse.Count);
            }
        }

        [TestMethod]
        public void AssignStudentToMultipleCourses()
        {
            Student nikola = new Student("Nikola", 99393);
            testingSchool.AddStudent(nikola);

            List<Course> courses = new List<Course>()
            {
               new Course("History"),
               new Course("Math"),
               new Course("Panda")
            };

            foreach (Course course in courses)
            {
                testingSchool.AddCourse(course);
            }

            this.testingSchool.AddStudentToCourse(nikola, courses);
            Assert.AreEqual(3, nikola.AttendedCourse.Count);
        }

        [TestMethod]
        public void GetCourseStudentInfo()
        {
            Student pesho = new Student("Pepito", 10101);
            pesho.AddCourse(new Course("Pottary"));

            StringBuilder actualResult = new StringBuilder();
            actualResult.AppendLine(pesho.DisplayCourseInfoToConsoleAndReturnValue());

            StringBuilder expectedResult = new StringBuilder();
            expectedResult.AppendLine("Pepito is attending:");
            expectedResult.AppendFormat("Course name: Pottary");
            expectedResult.AppendLine();
            Assert.AreEqual(expectedResult, expectedResult);
        }

        [TestMethod]
        public void GetFullCourseStudentInfo()
        {
            Student pesho = new Student("Pepito", 10101);
            Student gosho = new Student("Gosho", 10201);
            Course pottary = new Course("Pottary");

            testingSchool.AddStudent(pesho);
            testingSchool.AddStudent(gosho);
            testingSchool.AddCourse(pottary);
            testingSchool.AddStudentToCourse(pesho, pottary);
            testingSchool.AddStudentToCourse(gosho, pottary);

            StringBuilder actualResult = new StringBuilder();
            actualResult.AppendLine(pesho.DisplayFullCourseInfoToConsoleAndReturnValue());

            StringBuilder expectedResult = new StringBuilder();
            expectedResult.AppendLine("Pepito is attending:");
            expectedResult.AppendFormat("Course name: Pottary");
            expectedResult.AppendLine();
            expectedResult.AppendLine("The students appending this course are:");
            foreach (Course course in pesho.AttendedCourse)
            {
                expectedResult.AppendLine(course.GetFullInfo());
            }

            Assert.AreEqual(expectedResult, expectedResult);
        }
    }
}
