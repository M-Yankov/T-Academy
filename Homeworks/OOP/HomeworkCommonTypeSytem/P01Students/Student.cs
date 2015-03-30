
using System;
namespace P01Students
{
    enum Speciality
    {
        InnfomationSystems,
        ComputerScince,
        Geography,
        Math,
        AI,
        Infomationtechnologies,
        Mobiletechnologies,
        WebApplication,
        Programing,
        BusinessIndustry,
        Banking,
        Cycle,
        Sport,
        Finance,
        Inconomics,
        Polytology,
        BookKnowedge,
        PressComunity

    }
    enum Univercity
    {
        Unibit,
        StKlimentOxridski,
        MEI,
        UNSS,
        TelerikAcademy,
        SoftwareAcademy
    }
    enum Faculty
    {
        InforamtionScience,
        CountryIndusty
    }
    class Student : ICloneable, IComparable // : System.Object
    {
        private string firstName;
        private string midName;
        private string lastname;
        private int serialNumber;
        private string email;
        private string address;
        private string mobilePhone;
        private string course;

        private Speciality special;

        private Univercity univercity;

        private Faculty facultet;


        public Student(string fname, string midname, string lname, int serialNum, string address, string email, string mobilphone, string course, Speciality spec, Univercity uni, Faculty fac)
        {
            this.Paddress = address;
            this.Pcourse = course;
            this.Pemail = email;
            this.PfirstName = fname;
            this.PlastName = lname;
            this.PmidName = midname;
            this.PmobilePhone = mobilphone;
            this.PserNumber = serialNum;
            this.Pspecial = spec;
            this.Punivercity = uni;
            this.Pfacultet = fac;
        }

        public Faculty Pfacultet
        {
            get { return this.facultet; }
            set { this.facultet = value; }
        }

        public Univercity Punivercity
        {
            get { return this.univercity; }
            set { this.univercity = value; }
        }


        public Speciality Pspecial
        {
            get { return this.special; }
            set { this.special = value; }
        }


        public string PfirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string Pcourse  // I have tradition to call Properties with prefix "P" for easy access.
        {
            get { return this.course; }
            set { this.course = value; }
        }


        public string Pemail
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string PmobilePhone
        {
            get { return this.mobilePhone; }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("Ten digit number");
                }
                this.mobilePhone = value;
            }
        }

        public string Paddress
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public int PserNumber
        {
            get { return this.serialNumber; }
            set { this.serialNumber = value; }
        }

        public string PlastName
        {
            get { return this.lastname; }
            set { this.lastname = value; }
        }

        public string PmidName
        {
            get { return this.midName; }
            set { this.midName = value; }
        }
        /// <summary>
        /// Check univercity, number, first and last name
        /// </summary>
        /// <param name="obj"></param>
        /// <returns ></returns>
        public override bool Equals(object obj) // if I think more carefully they can be compared by HashCode() :)
        {
            Student stud = obj as Student;
            if (this.Punivercity == stud.Punivercity && this.PfirstName == stud.PfirstName && this.PlastName == stud.PlastName && this.PserNumber == stud.PserNumber)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()  // if hashCode can returns long ...
        {
            string num = "";
            string text = this.PfirstName;
            for (int i = 0; i < text.Length; i++)
            {
                num += (int)text[i] ^ 10;
            }

            int result = this.PserNumber ^ (this.PserNumber * 3);
            return result;
        }
        public static bool operator ==(Student stud1, Student stud2)
        {
            return stud1.Equals(stud2);
        }
        public static bool operator !=(Student stud1, Student stud2)
        {
            return !stud1.Equals(stud2);
        }
        public override string ToString()
        {
            return String.Format("Name: {0} {1} {2}\nINFO:\n Univercity: {3}\n Faculty: {4}\n Specialtity: {5}\n Fac.Number: {6}\n Course: {7}\nPersonal info:\n EMail: {8}\n Phone: {9}\n Address: {10}", this.PfirstName, this.PmidName, this.PlastName, this.Punivercity, this.Pfacultet, this.Pspecial, this.PserNumber, this.Pcourse, this.Pemail, this.PmobilePhone, this.Paddress); /// horrible 
        }


        public object Clone() // Deeep Copy
        {
            var myNewStud = new Student(this.PfirstName,this.PmidName,this.PlastName ,this.PserNumber,this.Paddress,this.Pemail,this.PmobilePhone,this.Pcourse,this.Pspecial , this.Punivercity,this.Pfacultet);
            
            return (object)myNewStud;
        }

        public int CompareTo(object obj)
        {
            var stud = obj as Student;
            if (this.PfirstName.CompareTo(stud.PfirstName) < 0) // "Atanas" "Gosho" -> -1 , but from th given task we must think that they are ordered.
            {
                return 1;
            }
            else if (this.PserNumber.CompareTo(stud.PserNumber) > 0)
            {
                return 1;
            }
            else if (this.PfirstName.CompareTo(stud.PfirstName) == 0 && this.PserNumber.CompareTo(stud.PserNumber) == 0)
            {
                return 0; 
            }
            else
            {
                return -1;  // They are'n ordered;
            }
            
        }
    }
}
