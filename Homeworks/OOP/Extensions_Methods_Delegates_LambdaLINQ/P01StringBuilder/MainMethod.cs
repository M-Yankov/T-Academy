/* 
 * Problem 1. StringBuilder.Substring
    Implement an extension method Substring(int index, int length) 
    for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.
   
 * Problem 2. IEnumerable extensions
      Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
  
 * Problem 3. First before last
    Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
    Use LINQ query operators.
  
 * Problem 4. Age range
       Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
  
 * Problem 5. Order students
        Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
      Rewrite the same with LINQ.

 * Problem 6. Divisible by 7 and 3
       Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
       Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

 */


namespace P01StringBuilder
{
    using System;
    using System.Text;
    using P01StringBuilder.Extensions;
    using System.Linq;
    using System.Collections.Generic;
    

    class MainMethod
    {
        static void Main(string[] args)
        {
            string line = new string('#' , 20);
            /*char myChar = 'A';
            Console.WriteLine((int)myChar);
            Console.WriteLine((char)67);   <-- Convert char to int and int to char.
            */
            
            Problem1(line);
            Problem2(line);
            Problem3And4and5(line);
            Problem6(line);
        }
        

        public static void Problem1(string line)
        {
            Console.WriteLine("\n" + line + "    Problem 1   " + line + "\n\r");
            var text = "Just some text!";
            try
            {
                int five = 5;
                StringBuilder myStrBuild = text.MySubstring(five, text.Length - five);  // "text.Length - five" this is allaways equals to end of string
                Console.WriteLine(myStrBuild);
            }
            catch (ArgumentOutOfRangeException wex)
            {

                Console.WriteLine(wex.Message);
            }//<--! problem 1 ends here -->

        }
        /// <summary>
        /// Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
        /// </summary>
        /// <param name="line"></param>
        public static void Problem2(string line)
        {
            Console.WriteLine("\n" + line + "    Problem 2   " + line + "\n\r");
            List<int> ints = new List<int>() { 1, 3, 6, 8, 9, 2, 5, 6 };
            List<float> floats = new List<float>() { 5.53F, 2.33F, 2.4F, 1.234F, -3.43F };
            List<long> longues = new List<long>() { 414L, 1324L, 32L, 56L };
            List<decimal> decimals = new List<decimal>() { 12.152512M, 2314.12341M, 231.23143M, -12.311M, -23.234M };
            Console.WriteLine("LIST of integers: {0}\nSum {1}\nProduct {2}\nMin {3}\nMax {4}\nAveradge {5}",string.Join(" ",ints), ints.Sum(), ints.Product(), ints.MyMin(), ints.MyMax(), ints.Averadge());
            Console.WriteLine(new string('-', 55));
            Console.WriteLine("LIST of floats: {0}\nSum {1}\nProduct {2}\nMin {3}\nMax {4}\nAveradge {5}", string.Join(" ", floats), floats.Sum(), floats.Product(), floats.MyMin(), floats.MyMax(), floats.Averadge());
            Console.WriteLine(new string('-', 55));
            Console.WriteLine("LIST of longs: {0}\nSum {1}\nProduct {2}\nMin {3}\nMax {4}\nAveradge {5}", string.Join(" ", longues), longues.Sum(), longues.Product(), longues.MyMin(), longues.MyMax(), longues.Averadge());
            Console.WriteLine(new string('-', 55));
            Console.WriteLine("LIST of decimals: {0}\nSum {1}\nProduct {2}\nMin {3}\nMax {4}\nAveradge {5}", string.Join(" ", decimals), decimals.Sum(), decimals.Product(), decimals.MyMin(), decimals.MyMax(), decimals.Averadge());
            // <--! Problem 2 ends here -->
        }
        /// <summary>
        /// Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators.
        /// </summary>
        /// <param name="line"></param>
        public static void Problem3And4and5(string line)
        {
            Console.WriteLine("\n" + line + "    Problem 3   " + line + "\n\r");
            // <-- Problem 3 starts -->
            Student[] students = new Student[] 
            {
                new Student("Ivan", "Draganov", 19),
                new Student("Murzeliv", "Studentov", 26),
                new Student("Sergei", "Stanishev", 22),
                new Student("Dimitar", "Berbatov", 22),
                new Student("Kiril", "Borisov", 20),
                new Student("Mihail", "Yankov", 21),
                new Student("Trendafil", "Zahariev", 23),
                new Student("Zahari", "Stoyanov", 24),
                new Student("Doncho", "Minkov", 25),
                new Student("Ivailo", "Kenov", 26),
                new Student("Nikolai", "Kostov",21),
                new Student("Evlogi", "Hristov",20)
            };
            var filteredstudents =
                    from s in students              //students.Where(x => (int)x.FirstName[0] <= (int)x.LastName[0]);  // code of first letter in names 
                    where (int)s.FirstName[0] <= (int)s.LastName[0]
                    select s;

            Console.WriteLine(string.Join("\n\r", filteredstudents));

            // <-- Problem 4 -->

            Console.WriteLine("\n" + line + "    Problem 4   " + line + "\n\r");
            var studentsAgeRange =
                from s in students                          //students.Where(x => x.Age >= 18 && x.Age <= 24);
                where s.Age >= 18 && s.Age <= 24
                select s;

            Console.WriteLine(string.Join("\n\r", studentsAgeRange));    

            // <-- Problem 5 -->
            Console.WriteLine("\n" + line + "    Problem 5   " + line + "\n\r");
            var orderedStudents = students
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName);
            Console.WriteLine(string.Join("\n\r" , orderedStudents));    
            // rewrite
            Console.WriteLine("\n\r with LINQ \n\r");
            orderedStudents =
                from s in students
                orderby s.FirstName descending  // <-- prostotiq losing 30 min to search where must be writen those "descending"...
                orderby s.LastName descending
                select s;
            Console.WriteLine(string.Join("\n\r", orderedStudents));    
                
                
                
        }
        /// <summary>
        /// Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
        /// </summary>
        /// <param name="line"></param>
        public static void Problem6(string line)
        {
            Console.WriteLine("\n" + line + "    Problem 6   " + line + "\n\r");
            int[] myArray = new int[] {84 , 42 ,1, 3, 5, 21, 33, 35, 7, 77, 12, 11, 46, 18, 143, 55, 63, 234 };
            Console.WriteLine("List of ints: {0}", string.Join(" ", myArray));
            var divisibleByThereeAndSeven = myArray
                .Where(x => x % 3 == 0 && x % 7 == 0);
            Console.WriteLine("All numbers divisible by 3 and 7: {0}",string.Join(" ", divisibleByThereeAndSeven));
            var linqDivisibleNumbers =
                from num in myArray
                where num % 3 == 0 && num % 7 == 0
                select num;
            Console.WriteLine("Same with LINQ: {0}", string.Join(" ", linqDivisibleNumbers));
        }
        
    }
}
