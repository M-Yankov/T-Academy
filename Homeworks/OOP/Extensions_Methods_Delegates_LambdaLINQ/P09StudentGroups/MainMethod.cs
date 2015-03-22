/*Problem 9. Student groups
    Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
    Create a List<Student> with sample students. Select only the students that are from group number 2.
    Use LINQ query. Order the students by FirstName.

 * Problem 10. Student groups extensions
       Implement the previous using the same query expressed with extension methods.

 * Problem 11. Extract students by email
    Extract all students that have email in abv.bg.
    Use string methods and LINQ.

 * Problem 12. Extract students by phone
    Extract all students with phones in Sofia.
    Use LINQ.
 
 * Problem 13. Extract students by marks
    Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks.
    Use LINQ.

 * Problem 14. Extract students with two marks
    Write down a similar program that extracts the students with exactly two marks "2".
    Use extension methods.

 * Problem 15. Extract marks
    Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).

 * Problem 16.* Groups
    Create a class Group with properties GroupNumber and DepartmentName.
    Introduce a property GroupNumber in the Student class.
    Extract all students from "Mathematics" department.
    Use the Join operator.
 
 * Problem 17  -> please check other solution 
  
 * Problem 18. Grouped by GroupNumber    
    Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
    Use LINQ.

 * Problem 19. Grouped by GroupName extensions    
    Rewrite the previous using extension methods.


 */

namespace P09StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class MainMethod
    {
        static void Main(string[] args)
        {
            string line = new string('#', 20);

            List<Student> students = new List<Student>();

            try
            {
                InicilizeStudents(students);

            }
            catch (ArgumentException ex)
            {
                
                Console.WriteLine(ex.Message);
                return;
            }
            var gropedStudents =
                from s in students
                where s.GroupNumber == 2
                orderby s.FirstName
                select s;

            Show(gropedStudents);

            Console.WriteLine("\n" + line + "    Problem 10   " + line + "\n\r");

            var lambdaGroupstudents = students
                .Where(x => x.GroupNumber == 2)
                .OrderBy(x => x.FirstName);

            Show(lambdaGroupstudents);

            Console.WriteLine("\n" + line + "    Problem 11   " + line + "\n\r");

            var abvMailStudents =
                from s in students
                where s.Email.Contains("abv.bg")
                select s;
            Show(abvMailStudents);

            Console.WriteLine("\n" + line + "    Problem 12   " + line + "\n\r");

            var phonesFromSofia =
                from s in students
                where s.Mobile.Contains("3592") // ако предположим че кода на София е 02 , то заедно с комбинация от кода за България ще е равно на +003592XXXXXX
                select s;
            Show(phonesFromSofia);

            Console.WriteLine("\n" + line + "    Problem 13   " + line + "\n\r");

            var excellentMarks =
                from s in students
                where s.Marks.Any(x => x == 6)
                select new
                {
                    Name = s.FirstName + " " + s.LastName,
                    Marks = string.Join(",", s.Marks)
                };
                //s.FirstName +" " +s.LastName  + " Marks: " +  string.Join("," ,s.Marks) ;
            Show(excellentMarks);

            Console.WriteLine("\n" + line + "    Problem 14   " + line + "\n\r");

            var twoMarks = students
                .Where(x => x.Marks.Count == 2);
            Show(twoMarks);

            Console.WriteLine("\n" + line + "    Problem 15   " + line + "\n\r");

            var years0506 = students
                .Where(x => x.FN.ToString().Substring(4, 2) == "05" || x.FN.ToString().Substring(4, 2) == "06")
                .Select(x => x.FirstName + " " + x.FN);
            Show(years0506);

            Console.WriteLine("\n" + line + "    Problem 16   " + line + "\n\r");

            Group one = new Group(1, "Mathematics");
            Group two = new Group(2, "Information Technologoies");
            Group three = new Group(3, "Biology");

            List<Group> myGroups = new List<Group>() { one, two, three };

            var maethematics =
                from s in myGroups
                where s.GroupNumber ==1
                join stud in students on s.GroupNumber equals stud.GroupNumber
                select new
                {
                    Name = stud.FirstName + " " + stud.LastName,
                    Department = s.DepartName
                };
            Show(maethematics);

            Console.WriteLine("\n" + line + "    Problem 18   " + line + "\n\r");

            var groupStuds =
                from s in students
                group s by s.GroupNumber;

            foreach (var group in groupStuds)
            {
                Console.WriteLine("Grouped by {0}",group.Key);
                Show(group);
            }

            Console.WriteLine("\n" + line + "    Problem 19   " + line + "\n\r");
            var groupStuds2 = students
                .GroupBy(x => x.GroupNumber);
            foreach (var group in groupStuds2)
            {
                Console.WriteLine("Grouped by {0}", group.Key);
                Show(group);
            }
        }
        public static void InicilizeStudents(List<Student> students)
        {

            
            students.Add(new Student("Pesho", "Ivanov", 345606, "+003592891562345", "pesho@mail.bg", new List<int>() { 2, 3, 5, 2, 4, 5, 5 }, 1));
            students.Add(new Student("Petkan", "Georgiev", 339905, "+359894862584", "georgiev@host.bg", new List<int>() { 2, 3, 5, 2, 4, 5, 5 }, 2));
            students.Add(new Student("Ivan", "Atanasov", 300005, "+359884594164", "picacho@mail.bg", new List<int>() { 2, 5, 4, 6, 4, 6, 2 }, 2));
            students.Add(new Student("Ivailo", "Kenov", 299906, "+003593875946441", "pokemon@abv.bg", new List<int>() { 4, 4, 4, 5, 3, 2, 3 }, 3));
            students.Add(new Student("Doncho", "Minkov", 268407, "+003590895959449", "izrod@mail.bg", new List<int>() { 4, 4, 6, 5, 2, 2, 2 }, 2));
            students.Add(new Student("Nikolai", "Kostov", 301506, "+003592895123411", "zybar@abv.bg", new List<int>() { 6, 6, 6, 5, 4, }, 4));
            students.Add(new Student("Evgeni", "Nachev", 301607, "+003592886515412", "dvoikar@mail.bg", new List<int>() { 2, 2, 2 }, 2));
            students.Add(new Student("Nadya", "Paskaleva", 315605, "+003592885519411", "student@abv.bg", new List<int>() { 5, 2, 4, 6, 2, 4, 3 }, 2));
            students.Add(new Student("Tihomira", "TihataStupka-300KG", 308408, "+359892316544", "delegate@mail.bg", new List<int>() { 2, 6, 5, 4, 6, 4, 3 }, 1));
            students.Add(new Student("Velizar", "Dimitrov", 306905, "+003592895159753", "event@mail.bg", new List<int>() { 3, 3, 3, 4, 5, 4 }, 1));
            students.Add(new Student("Magdalena", "Sirtakieva", 311106, "0886516556", "field@mail.bg", new List<int>() { 4, 2, 3, 6, 5, 2, 2 }, 2));
            students.Add(new Student("Mario", "Baloteli", 310205, "0895164642", "Property@abv.bg", new List<int>() { 6, 2 }, 2));
            students.Add(new Student("Katerina", "Momeva", 395404, "0887641346", "Constrtuctor@abv.bg", new List<int>() { 3, 3, 3, 2 }, 4));


        }
        public static void Show<T>(IEnumerable<T> s)
        {
            foreach (var stud in s)
            {
                Console.WriteLine(stud);
            }
        }
    }
}
