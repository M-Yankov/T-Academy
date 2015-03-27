/*Problem 1. School classes

    We are given a school. In the school there are classes of students. Each class has a set of teachers. Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have unique text identifier. Teachers have name. Disciplines have name, number of lectures and number of exercises. Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments (free text block).
    Your task is to identify the classes (in terms of OOP) and their attributes and operations, encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.
 */
namespace P01SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;

    class MainMethodHere
    {
        #region Disciplines
        public static Discipline Maths = new Discipline("Maths", 3, 3);
        public static Discipline Library = new Discipline("BookKnowedge", 2, 2);
        public static Discipline Infomratics = new Discipline("Informatica", 3, 3);
        public static Discipline CommTechs = new Discipline("Communication Technologies", 2, 3);
        public static Discipline CPlus = new Discipline("C++", 4, 4, "Fundamentals");
        public static Discipline CSharp = new Discipline("C#", 4, 5);
        public static Discipline OOP = new Discipline("Object-oriented Programing", 5, 5, "Hard");
        public static Discipline Html = new Discipline("Hyper text mark-up lang - HTML", 2, 3);
        public static Discipline WebCloud = new Discipline("Cloud applications", 4, 3);
        public static Discipline Drinking = new Discipline("How to drink after exam", 1, 1, "Warning");
        public static Discipline DB_SQL = new Discipline("Data & SQL", 4, 5);
        # endregion
        #region Teachers
        public static Teacher ivanov = new Teacher("Ivan Ivanonv", new List<Discipline> { CPlus, CSharp, OOP }, "Good");
        public static Teacher gosho = new Teacher("Georgi Georgiev", new List<Discipline> { WebCloud, DB_SQL });
        public static Teacher sergi = new Teacher("Sergei Sergiev", new List<Discipline> { CSharp, WebCloud, Html });
        public static Teacher hristo = new Teacher("Hristo Hristov", new List<Discipline> { Maths, Library });
        public static Teacher spiderman = new Teacher("Spider man", new List<Discipline> { Drinking }, "Excelent");
        public static Teacher petar = new Teacher("Petur Petrov", new List<Discipline> { OOP, WebCloud, Html });
        public static Teacher teache1 = new Teacher("Stoyan Borisov", new List<Discipline> { Maths, Infomratics });
        public static Teacher teacher2 = new Teacher("Georgi Dimitrov", new List<Discipline> { Infomratics, CommTechs });
        public static Teacher teacher3 = new Teacher("Asen Atanasov", new List<Discipline> { Maths }, "Bad");
        #endregion

        public static Student std1 = new Student("Goshko Dvoikata", 231555);
        public static Student std2 = new Student("Ivan Tupoto", 231234, "Stick");
        public static Student std3 = new Student("Pesho Rakiata", 2323155, "Drinkboy");
        public static Student std4 = new Student("Skapani  Studenti", 45653);
        public static Student std5 = new Student("Kolio Terorista", 835522);
        public static Student std6 = new Student("Atanas Semenov", 231119, "Blackboy");



        public static Teacher[] arrTeachers = new Teacher[] { ivanov, gosho, sergi, hristo, spiderman, petar, teache1, teacher2, teacher3 };
        static void Main(string[] args)
        {
            List<Student> myListStudents = new List<Student>() { std1, std2 };
            List<Student> myListStudents2 = new List<Student>() { std3, std4 };
            List<Student> myListStudents3 = new List<Student>() { std5, std6 };

            ClassOfStudents myClass = new ClassOfStudents(Teachers(), "4g2333", myListStudents);
           
            ClassOfStudents myDrunkClass = new ClassOfStudents(Teachers(), "4g6969", myListStudents2);
            
            ClassOfStudents myClass2 = new ClassOfStudents(Teachers(), "2g13ed", myListStudents3);
            List<ClassOfStudents> listOfclasses = new List<ClassOfStudents>() 
            {
                myClass,  myDrunkClass, myClass2
            };
            School mySchool = new School(listOfclasses);
            Console.WriteLine(mySchool);


        }
        public static List<Teacher> Teachers()
        {
            List<Teacher> TeacherList = new List<Teacher>();
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {

                int index = rand.Next(0, arrTeachers.Length - 1);
                if (TeacherList.Contains(arrTeachers[index]))  // <-- To get unique teacher list 
                {
                    i--;
                }
                else
                {
                    TeacherList.Add(arrTeachers[index]);

                }
                Thread.Sleep(20); // <<< --- Нарочно е забавена програмта за да може да ми генерира различни "Teachers" на различните групи студнетски класове.
            }
            return TeacherList;
        }
    }
}
