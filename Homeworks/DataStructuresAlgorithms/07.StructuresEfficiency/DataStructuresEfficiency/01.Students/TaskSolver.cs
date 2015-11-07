namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Task 1. A text file students.txt holds information about students and their courses in the following format: 
    ///     ○ Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them prints the students
    ///       ordered by family and then by name:
    ///       
    ///         Kiril  | Ivanov   | C#
    ///         Stefka | Nikolova | SQL
    ///         Stela  | Mineva   | Java
    ///         Milena | Petrova  | C#
    ///         Ivan   | Grigorov | C#
    ///         Ivan   | Kolev    | SQL
    ///         
    ///         C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
    ///         Java: Stela Mineva
    ///         SQL: Ivan Kolev, Stefka Nikolova
    /// </summary>
    public class TaskSolver
    {
        private static SortedDictionary<string, OrderedBag<Student>> coursesStudents;

        public static void Main()
        {
            coursesStudents = new SortedDictionary<string, OrderedBag<Student>>();
            using (StreamReader reader = new StreamReader("..\\..\\students.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] lineElements = reader.ReadLine().Split('|').Select(x => x.Trim()).ToArray();
                    string courseKey = lineElements[2];

                    if (!coursesStudents.ContainsKey(courseKey))
                    {
                        var orderedBag = new OrderedBag<Student>(new Student());
                        coursesStudents.Add(courseKey, orderedBag);
                    }

                    coursesStudents[courseKey].Add(new Student
                    {
                        Name = lineElements[0],
                        Family = lineElements[1]
                    });
                }
            }

            Print();
        }

        private static void Print()
        {
            StringBuilder result = new StringBuilder();

            foreach (var pair in coursesStudents)
            {
                string line = string.Format("{0}: {1}", pair.Key, string.Join(", ", pair.Value));
                result.AppendLine(line);
            }

            Console.WriteLine(result.ToString());
        }
    }
}
