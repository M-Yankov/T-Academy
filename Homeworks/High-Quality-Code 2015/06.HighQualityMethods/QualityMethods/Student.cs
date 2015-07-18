namespace QualityMethods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public DateTime BornDate { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = this.BornDate;
            DateTime secondDate = other.BornDate;
               
            return firstDate > secondDate;
        }
    }
}