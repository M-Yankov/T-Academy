namespace StudensAndCoursesTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentsAndCourses;

    [TestClass]
    public class StudentTest
    {
        [TestCleanup]
        public void ClearStudents()
        {
            DuplicateIDsHolder.UniqueIDs.Clear();
        }

        [TestMethod]
        public void TestStudentInitialization()
        {
            Student normalStudent = new Student("Ivan Petrov", 12564);
            Assert.AreEqual("Ivan Petrov", normalStudent.Name);
            Assert.AreEqual(12564, normalStudent.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentWithEmptyName()
        {
            Student emptyStudent = new Student("", 12564);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentWithShortName()
        {
            Student invalidShort = new Student("mk", 12564);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentWithLongName()
        {
            Student invlaidLongNames = new Student("Alexandra-Seraphinia Evangeline Zipporah", 12564);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentWithNullName()
        {
            Student nullStudent = new Student(null, 10025);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestStudentWithDigitInNames()
        {
            Student invalidDigit = new Student("Pet3r Pandov Pashov", 15515);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestStudentWithWrongFormatNames()
        {
            Student invalidSmallLetter = new Student("Peter petrov Pashov", 15515);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentWithShormMiddleNames()
        {
            Student invalidShorName = new Student("Peter Pe Pashov", 15515);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentWithInvalidID()
        {
            Student invalidID = new Student("Alexandra Petrova", 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDuplicateIDs()
        {
            Student firstID = new Student("Alexandra Petrova", 10150);
            Student secondID = new Student("Milka Todorova", 10150);
        }

        [TestMethod]
        public void TestCheckCourses()
        {
            Student nerd = new Student("Pavel Kolev", 11111);
            Student nobbie = new Student("Goran Bognanov", 15151);
            Course cSharp = new Course("C#");
            Course cPlusPlus = new Course("C++");
            Course java = new Course("Java");

            nerd.JointInCourse(cSharp);
            nerd.JointInCourse(cPlusPlus);
            nerd.JointInCourse(java);

            Assert.AreEqual(3, nerd.Courses.Count);
            Assert.AreEqual(0, nobbie.Courses.Count);
        }

        [TestMethod]
        public void TestCheckToLeaveNonParticipatedCourseToNoThrow()
        {
            Student nerd = new Student("Pavel Kolev", 11112);
            Student nobbie = new Student("Goran Bognanov", 15152);
            Course cSharp = new Course("C#");
            Course cPlusPlus = new Course("C++");
            Course java = new Course("Java");

            nerd.JointInCourse(cSharp);
            nerd.JointInCourse(cPlusPlus);
            nerd.JointInCourse(java);

            nerd.LeaveFromCourse(cPlusPlus);
            nerd.LeaveFromCourse(cSharp);
            nerd.LeaveFromCourse(java);

            nobbie.LeaveFromCourse(java);
            nobbie.LeaveFromCourse(cPlusPlus);

            Assert.AreEqual(0, nerd.Courses.Count);
            Assert.AreEqual(0, nobbie.Courses.Count);
        }

        [TestMethod]
        public void TestAddOneCourseManyTimes()
        {
            Student nerd = new Student("Pavel Kolev", 11113);
            Course javaScript = new Course("JavaScript");

            nerd.JointInCourse(javaScript);
            nerd.JointInCourse(javaScript);
            nerd.JointInCourse(javaScript);
            nerd.JointInCourse(javaScript);
            nerd.JointInCourse(javaScript);

            Assert.AreEqual(1, nerd.Courses.Count);
        }

        [TestMethod]
        public void TestManyStudentsToOneCourse()
        {
            Student nerd = new Student("Pavel Kolev", 11114);
            Student lazyStudent = new Student("Ivan Begov", 11115);
            Student sportStudent = new Student("Georgi Kishishev", 11116);

            Course javaScript = new Course("JavaScript");

            nerd.JointInCourse(javaScript);
            nerd.JointInCourse(javaScript);
            nerd.JointInCourse(javaScript);

            lazyStudent.JointInCourse(javaScript);
            lazyStudent.JointInCourse(javaScript);
            lazyStudent.JointInCourse(javaScript);

            sportStudent.JointInCourse(javaScript);

            Assert.AreEqual(1, nerd.Courses.Count);
            Assert.AreEqual(1, lazyStudent.Courses.Count);
            Assert.AreEqual(1, sportStudent.Courses.Count);

            nerd.LeaveFromCourse(javaScript);
            lazyStudent.LeaveFromCourse(javaScript);
            sportStudent.LeaveFromCourse(javaScript);

            Assert.AreEqual(0, nerd.Courses.Count);
            Assert.AreEqual(0, lazyStudent.Courses.Count);
            Assert.AreEqual(0, sportStudent.Courses.Count);
        }
    }
}
