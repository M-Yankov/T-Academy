using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01SchoolClasses
{
    class School
    {
        private List<ClassOfStudents> students;
        public School(List<ClassOfStudents> studs)
        {
            this.Students = studs;
            
        }
        public List<ClassOfStudents> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            string nums = String.Format("In this school studies: {0} classes", Students.Count);
            
            result.AppendLine(nums);
            result.AppendLine();
            for (int i = 0; i < this.Students.Count; i++)
            {
                result.AppendLine("\n\r  Class Group ID:" + students[i].TextInd);
                result.AppendLine(String.Format("Comment for class: {0}", students[i].Comment ?? "No"));
                result.AppendLine("\nList of Students:");
                for (int std = 0; std < students[i].StudentsInClass.Count; std++)
                {
                    result.AppendLine("Student name: " + students[i].StudentsInClass[std].Name);
                    result.AppendLine("Student id: " + students[i].StudentsInClass[std].Classnumber);
                    result.AppendLine(String.Format("Student Comment: {0}" , students[i].StudentsInClass[std].Comment ?? "No"));
                }
                result.AppendLine(new string('-', 20));
                for (int z = 0; z < students[i].Teachers.Count; z++)
                {
                    result.AppendLine("Lector: " + students[i].Teachers[z].Name);
                    
                    result.AppendLine("Disciplines:");
                    for (int y = 0; y < students[i].Teachers[z].Disciplines.Count; y++)
                    {
                        result.AppendLine("Name: " + students[i].Teachers[z].Disciplines[y].Name);
                        result.AppendLine("Number of lectures: " + students[i].Teachers[z].Disciplines[y].Numlects);
                        result.AppendLine("Number of exercises: " + students[i].Teachers[z].Disciplines[y].NumExercies);
                        result.AppendLine(String.Format("Comment for discipline: {0}" , students[i].Teachers[z].Disciplines[y].Comment ?? "None"));
                    }
                    result.AppendLine();
                }
            }
            return result.ToString();
        }
    }
}
