namespace StudentsAndCourses
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class School
    {
        private List<Student> allStudents = new List<Student>();

        private List<Course> courses = new List<Course>();

        public void AddStudentToSchool(Student student)
        {
            if (!this.allStudents.Contains(student))
            {
                this.allStudents.Add(student);
            }
        }

        public void AddCourseToSchool(Course course)
        {
            if (!this.courses.Contains(course))
            {
                this.courses.Add(course);
            }
        }

        public string ShowInformationAboutSchool()
        {
            return string.Format("In this school has {0} students and {1} courses", this.allStudents.Count, this.courses.Count);
        }
    }
}
