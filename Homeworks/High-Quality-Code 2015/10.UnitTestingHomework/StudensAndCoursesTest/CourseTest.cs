namespace StudensAndCoursesTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentsAndCourses;

    [TestClass]
    public class CourseTest
    {
        // Clears ids of students after each test
        [TestCleanup]
        public void TestClearStudents()
        {
            DuplicateIDsHolder.UniqueIDs.Clear();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWithEmptyName()
        {
            Course emptyNameCourse = new Course("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWithNullName()
        {
            Course nullCourse = new Course(null);
        }

        [TestMethod]
        public void TestANormalCourse()
        {
            Course additionalCourse = new Course("Java");
        }

        [TestMethod]
        public void TestAddingStudents()
        {
            Course normalCourse = new Course("C# OOP");
            string[] letters = new string[] { "s", "a", "e", "ela", "ina", "ka", "ona", };

            for (int i = 0; i < 30; i++)
            {
                normalCourse.AddStudent(new Student("Ivan" + letters[i % letters.Length], 10101 + i));
            }

            Assert.AreEqual(30, normalCourse.Participants.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestOvreloadCourse()
        {
            Course normalCourse = new Course("C# OOP");
            string[] letters = new string[] { "s", "a", "e", "ela", "ina", "ka", "ona", };

            for (int i = 0; i < 60; i++)
            {
                normalCourse.AddStudent(new Student("Ivan" + letters[i % letters.Length], 10101 + i));
            }
        }

        [TestMethod]
        public void TestAddRemoveStudents()
        {
            Course normalCourse = new Course("C# OOP");
            string[] letters = new string[] { "s", "a", "e", "ela", "ina", "ka", "ona", };
            Student[] participants = new Student[30];
            
            for (int i = 0; i < 30; i++)
            {
                participants[i] = new Student("Ivan" + letters[i % letters.Length], 10101 + i);
                normalCourse.AddStudent(participants[i]);
            }

            for (int i = 0; i < 30; i++)
            {
                normalCourse.RemoveStudent(participants[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                normalCourse.AddStudent(new Student("Ivan" + letters[i % letters.Length], 20101 + i));
            }

            Assert.AreEqual(5, normalCourse.Participants.Count);
        }
    }
}
