using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02StudentsAndWorkers
{
    class Student : Human
    {
        private double grade;

        public double Pgrade
        {
            get { return this.grade; }
            set {
                if (value > 6 || value < 2)
                {
                    string text = String.Format("Can't be less than 2 or bigger than 6! Your value {0}", value);
                    throw new ArgumentException(text);
                }
                this.grade = value; 
            }
        }

        public Student(string fname , string lname , double grade)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Pgrade = grade;
        }
        public override string ToString()
        {
            return String.Format("Name: {0} {1} \tGrade {2}", this.FirstName, this.LastName, this.Pgrade);
        }
    }
}
