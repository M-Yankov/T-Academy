namespace Towns
{
    using System;
    using System.IO;

    public class TownsProblem
    {
        public static void Main()
        {
            //Console.SetIn(new StringReader(ProvideInput()));

            int num = int.Parse(Console.ReadLine());

            int[] arr = new int[num];
            for (int i = 0; i < num; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                arr[i] = int.Parse(line[0]);
            }

            int answer = Solve(arr);
            Console.WriteLine(answer);
        }

        private static int Solve(int[] arr)
        {
            /// --> 
            int[] toRight = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                int max = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] < arr[i])
                    {
                        max = Math.Max(toRight[j], max);
                    }
                }

                toRight[i] = max + 1;
            }


            /// <---
            int[] toLeft = new int[arr.Length];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int max = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        max = Math.Max(toLeft[j], max);
                    }
                }

                toLeft[i] = max + 1;
            }

            int answer = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (toLeft[i] + toRight[i] - 1 > answer)
                {
                    answer = toLeft[i] + toRight[i] - 1;
                }
            }

            return answer; 
        }

        private static string ProvideInput()
        {
            return @"3
2 HaxorTown
2 LeetTown
2 RoxxorTown
";
        }
    }
}