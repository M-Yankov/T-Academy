namespace Baba
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text;

    public class GrandMotherTask
    {
        public static void Main()
        {
            Console.SetIn(new StringReader(ProvideInput()));

            /*int money = int.Parse(Console.ReadLine());

            string line = string.Empty;

            List<KeyValuePair<int, int>> offerts = new List<KeyValuePair<int, int>>();
            while (true)
            {
                line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                var parts = line.Split(' ');
                // 1 - count Of Prods; 2 - money;
                offerts.Add(new KeyValuePair<int, int>(int.Parse(parts[1]), int.Parse(parts[2])));
            }*/

            int maxWeight = int.Parse(Console.ReadLine());

            List<int> costs = new List<int>();
            List<int> products = new List<int>();

            string line = Console.ReadLine();
            while (line != "END")
            {
                string[] split = line.Split(' ');
                products.Add(int.Parse(split[1]));
                costs.Add(int.Parse(split[2]));

                line = Console.ReadLine();
            }

            int n = costs.Count;

            int[,] mat = new int[n + 1, maxWeight];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < maxWeight; j++)
                {
                    if (costs[i - 1] <= j && j - costs[i - 1] >= 0)
                    {
                        mat[i, j] = Math.Max(mat[i - 1, j], mat[i - 1, j - costs[i - 1]] + products[i - 1]);
                    }
                    else
                    {
                        mat[i, j] = mat[i - 1, j];
                    }
                }
            }

            Console.WriteLine(mat[n, maxWeight - 1]);

            return;

            /*

            int[] sums = new int[money];
            sums[0] = 0;


            for (int i = 0; i < offerts.Count; i++)
            {
                int[] justAdded = new int[money];
                int[] oldValue = new int[money];

                Array.Copy(sums, oldValue, money);

                bool[] visited = new bool[money];
                visited[0] = true;

                for (int z = 0; z < sums.Length; z++)
                {
                    if (!visited[z] || offerts[i].Value + z > money - 1 || oldValue[offerts[i].Value + z] > oldValue[z] + offerts[i].Key)
                    {
                        continue;
                    }


                    //visited[offerts[i].Value + z] = true;
                    justAdded[offerts[i].Value + z] = oldValue[z] + offerts[i].Key;
                }

                for (int index = 0; index < money; index++)
                {
                    sums[index] = Math.Max(oldValue[index], justAdded[index]);
                }
            }

            int answer = 0;
            //// Find Max 
            for (int start = 0, end = sums.Length - 1; start <= end; start++, end--)
            {
                if (sums[start] > answer)
                {
                    answer = sums[start];
                }

                if (sums[end] > answer)
                {
                    answer = sums[end];
                }
            }

            Console.WriteLine(answer);*/
        }

        private static void MatrixToString(int[,] currentMatrix)
        {
            StringBuilder res = new StringBuilder();
            for (int rows = 0; rows < currentMatrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < currentMatrix.GetLength(1); cols++)
                {
                    res.Append(string.Format("{0,3}", currentMatrix[rows, cols]));
                }
                res.Append(Environment.NewLine);
            }

            Console.WriteLine(res.ToString());
        }


        private static string ProvideInput()
        {
            return @"20
aaaaa 15 1
bbbbb 3 2
ccccc 2 1
ddddd 13 2
eeeee 5 14
END";
        }
    }
}
