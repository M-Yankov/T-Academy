using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class Card
    {
        private static int[,] dp;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            dp = new int[n, n];

            for (int length = 3; length <= n; length++)
            {
                for (int i = 0; i <= n - length; i++)
                {
                    for (int j = i + 1; j < i + length - 1; j++)
                    {
                        int current = dp[i, j] + dp[j, i + length - 1]
                             + numbers[j] * (numbers[i] + numbers[i + length - 1]);
                        if (dp[i, i + length - 1] < current)
                        {
                            dp[i, i + length - 1] = current;
                        }
                    }
                }
            }

            Console.WriteLine(dp[0, n - 1]);
        }
    }
}
