using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02StudentsAndWorkers
{
    class Worker : Human
    {
        private double weeksalary; // 350

        private int workHoursDay; // 10 * 5  = 50 hours for five working days

        public Worker(string fname, string lname, double weekSalary , int workingHoursPerDay)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Pweeksalary = weekSalary;
            this.PworkHours = workingHoursPerDay;
        }
        public int PworkHours
        {
            get { return this.workHoursDay; }
            set {
                if (value > 24)
                {
                    string text = String.Format("Can't be more than 24! Your value {0}", value);
                    throw new ArgumentException(text);    
                } 
                this.workHoursDay = value;
            }
        }
        
        public double Pweeksalary
        {
            get { return this.weeksalary; }
            set { this.weeksalary = value; }
        }
        public double MoneyPerHour()
        {
            return this.weeksalary / (this.PworkHours*5) ;
        }
        public override string ToString()
        {
            return String.Format("{0} \t{1:C2} per hour", this.FirstName + " " + this.LastName, this.MoneyPerHour());
        }
    }
}
