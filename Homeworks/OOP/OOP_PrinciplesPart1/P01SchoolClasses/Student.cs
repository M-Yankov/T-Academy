using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01SchoolClasses
{
    class Student : People , IComment
    {
        
        private int number;


        public Student(string name , int numberFak)
        {
            this.Name = name;
            this.Classnumber = numberFak;
        }
        public Student(string name, int numberFak , string comment)
        {
            this.Name = name;
            this.Classnumber = numberFak;
            this.Comment = comment;
        }
        
        public int Classnumber
        {
            get { return this.number; }
            set { this.number = value; }
        }



        public string Comment
        {
            get;
            
            set;
            
        }
        public override string ToString()
        {
            if (this.Comment != null)
            {
                return String.Format("{0} {1} {2}" , this.Name, this.Classnumber ,this.Comment);
            }
            else{
                return String.Format("{0} {1}", this.Name, this.Classnumber);
            }
        }
    }
}
