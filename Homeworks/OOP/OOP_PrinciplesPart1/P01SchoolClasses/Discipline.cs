using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01SchoolClasses
{
    class Discipline : IComment 
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;

        public Discipline(string name , int numLects, int numExe)
        {
            this.Name = name;
            this.Numlects = numLects;
            this.NumExercies = numExe;
        }
        public Discipline(string name, int numLects, int numExe, string comment)
        {
            this.Name = name;
            this.Numlects = numLects;
            this.NumExercies = numExe;
            this.Comment = comment;
        }
        public int NumExercies
        {
            get { return this.numberOfExercises; }
            set { this.numberOfExercises = value; }
        }
        
        public int Numlects
        {
            get { return this.numberOfLectures; }
            set { this.numberOfLectures = value; }
        }
        
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
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
                return string.Format("{0} {1} {2} {3}", this.Name, this.Numlects, this.NumExercies, this.Comment);
            }
            else
            {
                return string.Format("{0} {1} {2}", this.Name, this.Numlects, this.NumExercies);

            }
        }
    }
}
