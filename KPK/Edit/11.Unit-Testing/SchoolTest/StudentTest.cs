using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using School;

namespace SchoolTest
{
    [TestClass]
    public class StudentTest
    {
        private School.School testingSchool = new School.School("Testing Academy");
        private List<Student> testingStudents = new List<Student>();
        private List<Course> testingCourses = new List<Course>();

        [TestMethod]
        public void CreateAStudent()
        {
            Student pesho = new Student("Pesho", 10000);
            Assert.AreEqual("Pesho", pesho.Name);
            Assert.AreEqual((uint)10000, pesho.Number);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void CreateStudentWithBiggerNumber()
        {
            Student pesho = new Student("Pesho", 100000);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException), "Student is not registered to this course")]
        public void RemoveStudentCourseThatHeDoesNotAttend()
        {
            Course math = new Course("Math");
            testingSchool.AddCourse(math);
            testingCourses.Add(math);

            this.testingStudents.Add(new Student("Pesho", 10000));
            testingStudents[0].AddCourse(math);
            Assert.AreEqual("Math", testingStudents[0].AttendedCourse[0].Name);
            Assert.IsNotNull(testingStudents[0].AttendedCourse[0]);

            testingStudents[0].RemoveCourse(math);
        }

        [TestMethod]
        public void AddStudentToCourse()
        {
            Course math = new Course("Math");
            testingSchool.AddCourse(math);
            testingCourses.Add(math);

            this.testingStudents.Add(new Student("Pesho", 10000));

            testingStudents[0].AddCourse(math);
            math.AddStudent(testingStudents[0]);
            Assert.AreEqual(1, math.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException), "Student is registered in this course!")]
        public void AddExistingStudentToCourse()
        {
            Course math = new Course("Math");
            testingSchool.AddCourse(math);
            testingCourses.Add(math);

            this.testingStudents.Add(new Student("Pesho", 10000));

            testingStudents[0].AddCourse(math);
            math.AddStudent(testingStudents[0]);
            math.AddStudent(testingStudents[0]);
        }

        [TestMethod]
        public void RemoveStudentFromCourse()
        {
            Course math = new Course("Math");
            testingSchool.AddCourse(math);
            testingCourses.Add(math);

            this.testingStudents.Add(new Student("Pesho", 10000));

            testingStudents[0].AddCourse(math);
            math.AddStudent(testingStudents[0]);

            math.RemoveStudent(testingStudents[0]);
            Assert.AreEqual(0, math.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException), "Student is not registered in this course!")]
        public void RemoveNotExistingStudentInCourse()
        {
            Course math = new Course("Math");
            testingSchool.AddCourse(math);
            testingCourses.Add(math);
            this.testingStudents.Add(new Student("Pesho", 10000));
            math.RemoveStudent(testingStudents[0]);
        }

        [TestMethod]
        public void RemoveStudentCourse()
        {
            Course math = new Course("Math");
            testingSchool.AddCourse(math);
            testingCourses.Add(math);

            this.testingStudents.Add(new Student("Pesho", 10000));
            testingCourses[0].AddStudent(testingStudents[0]);
            testingStudents[0].AddCourse(math);
            Assert.AreEqual("Math", testingStudents[0].AttendedCourse[0].Name);
            Assert.IsNotNull(testingStudents[0].AttendedCourse[0]);

            testingStudents[0].RemoveCourse(math);
            Assert.AreEqual(0, testingStudents[0].AttendedCourse.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException), "The student name was not entered!")]
        public void AddNewEmptyStudent()
        {
            this.testingStudents.Add(new Student("", 10000));
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException), "The student number is not unique and it is taken!")]
        public void AddNewStudentWithTakenNumber()
        {
            Student studentTest = new Student("Test", 10001);
            Student studentFest = new Student("fest", 10001);
            this.testingSchool.AddStudent(studentTest);
            this.testingSchool.AddStudent(studentFest);
        }
    }
}
