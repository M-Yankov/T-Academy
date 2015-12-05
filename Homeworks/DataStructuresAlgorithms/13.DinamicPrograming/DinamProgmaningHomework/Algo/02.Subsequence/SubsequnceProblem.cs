namespace Subsequence
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Numerics;

    public class SubsequnceProblem
    {
        public static void Main()
        {
            /*Console.SetIn(new StringReader (ProvideInput()));*/

            /// longs 
            Console.ReadLine();
            Console.ReadLine();

            BigInteger[] firstNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();
            BigInteger[] secondNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();

            Solve(firstNumbers, secondNumbers);
        }

        public static void Solve(BigInteger[] firstNumbers, BigInteger[] secondNumbers)
        {
            if (firstNumbers == null || secondNumbers == null)
            {
                Console.WriteLine(0);
                return;
            }

            BigInteger[,] result = new BigInteger[firstNumbers.Length + 1, secondNumbers.Length + 1];
            for (int row = 1; row < firstNumbers.Length + 1; row++)
            {
                for (int col = 1; col < secondNumbers.Length + 1; col++)
                {
                    if (firstNumbers[row - 1] == secondNumbers[col - 1])
                    {
                        result[row, col] = result[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        result[row, col] = result[row - 1, col] > result[row, col - 1] ? result[row - 1, col] : result[row, col - 1];
                    }
                }
            }

            Console.WriteLine(result[firstNumbers.Length, secondNumbers.Length]);
        }

        private static string ProvideInput()
        {
            return @"5
10
18 12 3 123
19 12 2 31
";
        }
    }
}
