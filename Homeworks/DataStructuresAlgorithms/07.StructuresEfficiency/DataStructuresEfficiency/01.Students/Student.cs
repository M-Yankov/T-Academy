namespace Students
{
    using System.Collections.Generic;

    public class Student : IComparer<Student>
    {
        public string Name { get; set; }

        public string Family { get; set; }

        public int Compare(Student first, Student second)
        {
            int comparedResult = first.Family.CompareTo(second.Family);
            if (comparedResult == 0)
            {
                return first.Name.CompareTo(second.Name); 
            }
            else
            {
                return comparedResult;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Family);
        }
    }
}
