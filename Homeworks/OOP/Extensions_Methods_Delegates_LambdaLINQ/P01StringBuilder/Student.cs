using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01StringBuilder
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Student(string fname, string lname, int age)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Age = age;
        }
        public override string ToString()
        {
            return this.FirstName + " "+  this.LastName + " " + this.Age + " years.";
        }
    }
}
