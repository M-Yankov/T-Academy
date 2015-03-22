
namespace P09StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

     class Student
    {
        private string firstname;
        private string lastname;
        private int fackilteten;
        private string mobile;
        private string email;
        private List<int> marks;
        private int groupNumber;


        public string FirstName
        {
            get { return this.firstname; }
            set { this.firstname = value; }
        }


        public string LastName
        {
            get { return this.lastname; }
            set { this.lastname = value; }
        }

        public int FN
        {
            get { return this.fackilteten; }
            set { this.fackilteten = value; }
        }

        public string Mobile
        {
            get { return this.mobile; }
            set
            {
                if (value.Length < 10)
                {
                    string text = string.Format("Mobie lenght must be 10 --> {0} - {1}", this.FirstName, value);
                    throw new ArgumentException(text);
                }
                this.mobile = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (!value.Contains("@") && !value.Contains(".")) // a simple validation
                {
                    string text = String.Format("Maybe this is not an email --> {0} - {1}", this.FirstName, value);
                    throw new ArgumentException(text);
                }
                this.email = value;
            }
        }

        public List<int> Marks
        {
            get { return this.marks; }
            set            {
                if (value.Any(x => x < 2 || x > 6))
                {
                    string text = String.Format("Mark are between 2 and 6. --> {0} {1}", this.FirstName, string.Join(",", value));
                    throw new ArgumentException(text); 
                }
                this.marks = value;
            }
        }
        

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set { this.groupNumber = value; }
        }
        public Student(string fname, string lname, int fn, string gsm, string email, List<int> marks, int gNumber)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.FN = fn;
            this.Mobile = gsm;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = gNumber;
        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {6} \nMarks: {5}", this.FirstName, this.lastname, this.FN, this.Mobile, this.Email, string.Join(",", this.Marks), this.GroupNumber);
        }

    }
}
