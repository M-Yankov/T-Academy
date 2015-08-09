namespace StudentsAndCourses
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Course
    {
        private const byte MAX_PARTICIPANS_COUNT = 30;

        private string name;

        private List<Student> studentsInCourse = new List<Student>();

        public Course(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == string.Empty || value == null)
                {
                    throw new ArgumentException("Name cannot be empty!", "Name");
                }

                this.name = value;
            }
        }

        public List<Student> Participants
        {
            get
            {
                return this.studentsInCourse;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.studentsInCourse.Count >= MAX_PARTICIPANS_COUNT)
            {
                throw new ArgumentOutOfRangeException(student.Name, "Student cannot be added, because no free slots for this course!");
            }

            if (this.studentsInCourse.Contains(student))
            {
                // No need to throw
                Console.WriteLine("Already participate!");
                return;
            }

            this.studentsInCourse.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (this.studentsInCourse.Contains(student))
            {
                this.studentsInCourse.Remove(student);
            }
            else
            {
                Console.WriteLine("You are not participate in this course!");
            }
        }
    }
}
