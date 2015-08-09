namespace StudentsAndCourses
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Student
    {
        private const int NAME_MIN_LENGTH = 3;
        private const int NAME_MAX_LENGTH = 30;
        private const int ID_MIN = 10000;
        private const int ID_MAX = 99999;

        private List<Course> coursesThatStudentPraticipate = new List<Course>();

        private string name;

        private int id;

        public Student(string name, int IDNumber)
        {
            this.Name = name;
            this.ID = IDNumber;
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
                    throw new ArgumentException("Empty string", "Name cannot be empty");
                }

                if (value.Length < NAME_MIN_LENGTH || NAME_MAX_LENGTH < value.Length)
                {
                    throw new ArgumentOutOfRangeException("Name Length", "Length must be between " + NAME_MIN_LENGTH + " and " + NAME_MAX_LENGTH + ".");
                }

                WordNamesValidation(value);

                this.name = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < ID_MIN || ID_MAX < value)
                {
                    throw new ArgumentOutOfRangeException("Id out of range", "ID of student must be between " + ID_MIN + " and " + ID_MAX + ".");
                }

                if (DuplicateIDsHolder.UniqueIDs.Contains(value))
                {
                    throw new ArgumentException("Duplicate IDs are not allowed", value.ToString());
                }

                this.id = value;
                DuplicateIDsHolder.UniqueIDs.Add(value);
            }
        }

        public List<Course> Courses
        {
            get
            {
                return this.coursesThatStudentPraticipate;
            }
        }

        public void JointInCourse(Course course)
        {
            course.AddStudent(this);

            if (!this.coursesThatStudentPraticipate.Contains(course))
            {
                this.coursesThatStudentPraticipate.Add(course);
            }
        }

        public void LeaveFromCourse(Course course)
        {
            course.RemoveStudent(this);

            if (this.coursesThatStudentPraticipate.Contains(course))
            {
                this.coursesThatStudentPraticipate.Remove(course);
            }
        }

        private static void WordNamesValidation(string names)
        {
            string[] splitedNames = names.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in splitedNames)
            {
                if (!char.IsUpper(name, 0))
                {
                    throw new FormatException("All names must start with capital letter!");
                }

                if (name.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Name Length", "Length must be between " + NAME_MIN_LENGTH + " and " + NAME_MAX_LENGTH + ".");
                }

                foreach (var ch in name)
                {
                    if (char.IsDigit(ch))
                    {
                        throw new FormatException("Names must not contain numbers!");
                    }
                }
            }
        }
    }
}
