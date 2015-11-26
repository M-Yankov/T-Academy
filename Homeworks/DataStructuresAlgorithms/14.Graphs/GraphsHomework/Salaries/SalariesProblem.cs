namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SalariesProblem
    {
        private static char employeeChar = 'Y';
        private static Dictionary<int, List<int>> allemployees;
        private static Dictionary<int, int> employeeSalary;

        public static void Main()
        {
            allemployees = new Dictionary<int, List<int>>();
            employeeSalary = new Dictionary<int, int>();

            //Console.SetIn(new StringReader(ProvideInput()));

            ReadInput();
            Solve();
        }

        private static void Solve()
        {
            int sum = 0;
            foreach (var item in allemployees)
            {
                sum += TraverseDFS(item.Key);
            }

            Console.WriteLine(sum);
        }

        private static int TraverseDFS(int vertex)
        {
            if (employeeSalary.ContainsKey(vertex))
            {
                return employeeSalary[vertex];
            }

            int sum = 0;
            if (allemployees[vertex].Count == 0)
            {
                return 1;
            }

            foreach (var item in allemployees[vertex])
            {
                sum += TraverseDFS(item);
            }

            employeeSalary.Add(vertex, sum);
            return sum;
        }

        private static void ReadInput()
        {
            int employeesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < employeesCount; i++)
            {
                string line = Console.ReadLine();

                allemployees.Add(i, new List<int>());

                bool isBoss = true;
                for (int z = 0; z < employeesCount; z++)
                {
                    if (line[z] == employeeChar)
                    {
                        isBoss = false;
                        allemployees[i].Add(z);
                    }
                }

                if (isBoss)
                {
                    employeeSalary.Add(i, 1);
                }
            }
        }

        private static string ProvideInput()
        {
            return @"4
NNYN
NNYN
NNNN
NYYN";
        }
    }
}
