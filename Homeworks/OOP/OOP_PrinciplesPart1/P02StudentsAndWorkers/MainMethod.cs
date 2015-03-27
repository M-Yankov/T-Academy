/*Problem 2. Students and workers

    Define abstract class Human with first name and last name. Define new class Student which is derived from Human and has new field – grade. Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour() that returns money earned by hour by the worker. Define the proper constructors and properties for this hierarchy.
    Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
    Initialize a list of 10 workers and sort them by money per hour in descending order.
    Merge the lists and sort them by first name and last name
 */

namespace P02StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class MainMethod
    {
        public static List<Student> students = new List<Student>();
        public static List<Worker> workers = new List<Worker>();
        static void Main(string[] args)
        {
            Students();
            Console.WriteLine("\n\r" + "\t\tList of workers " + "\n\r");
            Workers();
            Console.WriteLine("\n\r" + "\t\tMerged Sorted list of students and workers " + "\n\r");
            Merge();
        }
         public static void Students()
        {
            Student stud1 = new Student("Ivan", "Ivanov", 5.55);
            Student stud2 = new Student("Petar", "Petrov", 4.25);
            Student stud3 = new Student("Sergei", "Sergiev", 6.00);
            Student stud4 = new Student("Dragan", "Draganov", 4.66);
            Student stud5 = new Student("Hristo", "Karakolev", 5.02);
            Student stud6 = new Student("Ivailo", "Kenov", 4.08);
            Student stud7 = new Student("Doncho", "Minkov", 4.98);
            Student stud8 = new Student("Nikolai", "Kostov", 3.94);
            Student stud9 = new Student("Evlogi", "Hrisov", 4.57);
            Student stud10 = new Student("Vyara", "Koceva", 2.14);
               students = new List<Student>()
               {
                    stud1, stud2, stud3, stud4, stud5 , stud6 ,stud7 ,stud8, stud9 , stud10
                };
            var sortedStudents =  // students.OrderBy(x => x.Pgrade);
                from s in students
                orderby s.Pgrade
                select s;
            foreach (var stud in sortedStudents)
            {
                Console.WriteLine(stud);
            }
        }
         public static void Workers()
        {
            Worker workMan1 = new Worker("Ivan", "Petrov", 350, 7);
            Worker workMan2 = new Worker("Ivailo", "Kenov", 300, 8);
            Worker workMan3 = new Worker("Doncho", "Minkov", 450, 6);
            Worker workMan4 = new Worker("Nikolai", "Kostov", 400, 8);
            Worker workMan5 = new Worker("Evlogi", "Hristov", 550, 9);
            Worker workMan6 = new Worker("Dimirat", "Petrov", 500, 10);
            Worker workMan7 = new Worker("Ivan", "Atanasov", 250, 5);
            Worker workMan8 = new Worker("Kaloyan", "Liubomirov", 450, 4);
            Worker workMan9 = new Worker("Kiril", "Asenov", 350, 6);
            Worker workMan10 = new Worker("Orlin", "Zahaeiev", 250, 8);
             workers = new List<Worker>()
             {
                 workMan1 ,workMan2 , workMan3,workMan4 , workMan5 ,workMan6 ,workMan7 ,workMan8 ,workMan9, workMan10
             };
            var sortedWorkesrs =  //workers.OrderByDescending(x => x.MoneyPerHour());
                from w in workers
                orderby w.MoneyPerHour() descending
                select w;
            foreach (var worker in sortedWorkesrs)
            {
                Console.WriteLine(worker);
            }
        }
         public static void Merge()
         {
             List<Human> merged = new List<Human>();
             foreach (var stud in students)
             {
                 merged.Add(stud);
             }
             foreach (var worker in workers)
             {
                 merged.Add(worker);
             }
             var sortedMerge =
                 from i in merged
                 orderby i.LastName
                 orderby i.FirstName
                 select i;
             foreach (var human in sortedMerge)
             {
                 string text =  String.Format("{0} {1} as {2}", human.FirstName, human.LastName , human.GetType().Name);
                 Console.WriteLine(text);
             }
         }

        

    }
}
