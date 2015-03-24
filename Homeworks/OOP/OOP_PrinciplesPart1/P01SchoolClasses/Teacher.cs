using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01SchoolClasses
{
    class Teacher : People , IComment
    {
        private List<Discipline> disciplines;
        private string commentStatus;
        public Teacher(string name , List<Discipline> discipList, string status)
        {
            this.Name = name;
            this.Disciplines = discipList;
            this.Comment = status;
        } 
        public Teacher(string name, List<Discipline> discipList )
        {
            this.Name = name;
            this.Disciplines = discipList;
        }

        public List<Discipline> Disciplines
        {
            get { return this.disciplines; }
            set { this.disciplines = value; }
        }


        public string Comment
        {
            get
            {
                return this.commentStatus;
            }
            set
            {
                this.commentStatus = value;
            }
        }
        public override string ToString()
        {
            if(this.Comment != null)
            {
                return String.Format("{0} {1} {2}" ,this.Name , string.Join(",", this.Disciplines,this.Comment));
            }
            else
            {
                return String.Format("{0} {1}" ,this.Name , string.Join(",", this.Disciplines));
                
            }
        }
    }
}
