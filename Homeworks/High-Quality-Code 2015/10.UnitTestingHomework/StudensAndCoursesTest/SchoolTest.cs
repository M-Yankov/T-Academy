namespace StudensAndCoursesTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentsAndCourses;

    [TestClass]
    public class SchoolTest
    {
        [TestCleanup]
        public void CleanStudents()
        {
            DuplicateIDsHolder.UniqueIDs.Clear();
        }

        [TestMethod]
        public void TestSchool()
        {
            School academy = new School();
            Assert.AreEqual(this.RetutnInfo(0, 0), academy.ShowInformationAboutSchool());
        }

        [TestMethod]
        public void TestCoursesAndStudents()
        {
            School academy = new School();
            string[] letters = new string[] { "s", "a", "e", "ela", "ina", "ka", "ona", };

            for (int i = 0; i < 5; i++)
            {
                Course pesho = new Course("Course #" + i);

                for (int j = 0; j < 30; j++)
                {
                    Student thisStudent = new Student("Ivan" + letters[i % letters.Length], (10344 * (i + 1)) + j);
                    pesho.AddStudent(thisStudent);
                    academy.AddStudentToSchool(thisStudent);
                }

                academy.AddCourseToSchool(pesho);
            }

            Assert.AreEqual(this.RetutnInfo(150, 5), academy.ShowInformationAboutSchool());
        }

        private string RetutnInfo(int students, int courses)
        {
            return string.Format("In this school has {0} students and {1} courses", students, courses);
        }
    }
}
