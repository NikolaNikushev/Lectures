using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using School;

namespace SchoolTest
{
    [TestClass]
    public class SchoolTest
    {
        private School.School testingSchool = new School.School("Testing Academy");
        private List<Student> testingStudents = new List<Student>();
        private List<Course> testingCourses = new List<Course>();

        [TestMethod]
        public void CreateSchool()
        {
            School.School school = new School.School("Afrika");
            Assert.IsNotNull(school);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException), "The school's name was not entered!")]
        public void CreateSchoolWithEmptyName()
        {
            School.School school = new School.School("");
        }

        [TestMethod]
        public void AddNewStudents()
        {
            this.testingStudents.Add(new Student("Pesho", 10000));
            testingSchool.AddStudent(testingStudents[0]);

            Assert.AreEqual("Pesho", testingStudents[0].Name);
            Assert.AreEqual((uint)10000, testingStudents[0].Number);
            Assert.IsNotNull(testingStudents[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException), "Student already is registered!")]
        public void AddStudentTwice()
        {
            Student pesho = new Student("Pesho", 10000);
            testingSchool.AddStudent(pesho);
            testingSchool.AddStudent(pesho);
        }

        [TestMethod]
        public void AddStudentCourse()
        {
            Course math = new Course("Math");
            testingSchool.AddCourse(math);
            testingCourses.Add(math);

            this.testingStudents.Add(new Student("Pesho", 10000));
            testingStudents[0].AddCourse(math);
            Assert.AreEqual("Math", testingStudents[0].AttendedCourse[0].Name);
            Assert.IsNotNull(testingStudents[0].AttendedCourse[0]);
        }

        [TestMethod]
        public void GetSchoolName()
        {
            Assert.AreEqual("Testing Academy", testingSchool.Name);
        }

        [TestMethod]
        public void GetSchoolStudentList()
        {
            for (int i = 0; i < 5; i++)
            {
                testingStudents.Add(new Student("Mihail" + i, (uint)(10000 + i)));
            }

            foreach (Student student in testingStudents)
            {
                testingSchool.AddStudent(student);
            }

            Assert.AreEqual(5, testingSchool.Students.Count);
        }
    }
}
