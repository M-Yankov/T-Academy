namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string name) 
            : base(name)
        {
            this.Town = null;
            this.Type = "OffsiteCourse";
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Town = null;
            this.Type = "OffsiteCourse";
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Town = null;
            this.Type = "OffsiteCourse";
        }

        public string Town { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}