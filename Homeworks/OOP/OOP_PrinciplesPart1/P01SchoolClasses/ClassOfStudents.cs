using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01SchoolClasses
{
    class ClassOfStudents : IComment
    {
        private List<Student> studentsinTheclass;
        private List<Teacher> techs;
        private string textInditifier;
        public ClassOfStudents(List<Teacher> teachers , string inditefier , List<Student> inTheclass)
        {
            this.Teachers = teachers;
            this.TextInd = inditefier;
            this.StudentsInClass = inTheclass;
        }
        public ClassOfStudents(List<Teacher> teachers, string inditefier, List<Student> inTheclass ,string comment)
        {
            this.Teachers = teachers;
            this.TextInd = inditefier;
            this.StudentsInClass = inTheclass;
            this.Comment = comment;
        }
        public List<Teacher> Teachers
        {
            get { return this.techs; }
            set { this.techs = value; }
        }
        public string TextInd
        {
            get { return this.textInditifier; }
            set { this.textInditifier = value; }
        }
        public List<Student> StudentsInClass
        {
            get {return this.studentsinTheclass; }
            set { this.studentsinTheclass = value;}
        }



        public string Comment
        {
            get;
            set;
        }
    }
}
