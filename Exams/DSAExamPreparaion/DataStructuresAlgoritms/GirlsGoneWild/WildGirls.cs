namespace GirlsGoneWild
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class WildGirls
    {
        public static void Main()
        {
            var result = new HashSet<string>();

            int K = int.Parse(Console.ReadLine());
            char[] chars = Console.ReadLine().ToCharArray(); //new char[] { 'b', 'a', 'c', 'a'};
            Array.Sort(chars);

            string grlsCount = Console.ReadLine();

            var numbers = Enumerable.Range(0, K).ToArray();

            switch (grlsCount)
            {
                case "2":
                    SolutionForTwoGirls(result, chars, numbers);
                    break;
                case "3":
                    SolutionForThreeGirls(result, chars, numbers);
                    break;
                case "1":
                    SolutionForOneGirl(result, chars, numbers);
                    break;
                case "5":
                    SolutionForFiveGirls(result, chars, numbers);
                    break;

                default:
                    throw new NotImplementedException();
            }

            Console.WriteLine(result.Count);
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static void SolutionForOneGirl(HashSet<string> result, char[] chars, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    result.Add(i.ToString() + chars[i]);
                }
            }
        }


        private static void SolutionForTwoGirls(HashSet<string> result, char[] chars, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    for (int y = i + 1; y < numbers.Length; y++)
                    {
                        for (int z = 0; z < chars.Length; z++)
                        {
                            if (j != z)
                            {
                                result.Add(i.ToString() + chars[j] + "-" + y.ToString() + chars[z]);
                            }
                        }
                    }
                }
            }
        }

        private static void SolutionForThreeGirls(HashSet<string> result, char[] chars, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    for (int y = i + 1; y < numbers.Length; y++)
                    {
                        for (int z = 0; z < chars.Length; z++)
                        {
                            for (int o = y + 1; o < numbers.Length; o++)
                            {
                                for (int c = 0; c < chars.Length; c++)
                                {
                                    if (j != z && z != c && c != j)
                                    {
                                        result.Add(i.ToString() + chars[j] + "-" + y.ToString() + chars[z] + "-" + o.ToString() + chars[c]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void SolutionForFiveGirls(HashSet<string> result, char[] chars, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    for (int y = i + 1; y < numbers.Length; y++)
                    {
                        for (int z = 0; z < chars.Length; z++)
                        {
                            for (int o = y + 1; o < numbers.Length; o++)
                            {
                                for (int c = 0; c < chars.Length; c++)
                                {
                                    for (int q = 0; q < numbers.Length; q++)
                                    {
                                        for (int p = 0; p < chars.Length; p++)
                                        {
                                            for (int f = 0; f < numbers.Length; f++)
                                            {
                                                for (int r = 0; r < chars.Length; r++)
                                                {
                                                    if (!HasEqualItems(j, z, c, p, r))
                                                    {
                                                        result.Add(
                                                            i.ToString() + chars[j] + "-"
                                                            + y.ToString() + chars[z] + "-"
                                                            + o.ToString() + chars[c] + "-"
                                                            + q.ToString() + chars[p] + "-"
                                                            + f.ToString() + chars[r]);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static bool HasEqualItems(params int[] values)
        {
            HashSet<int> tempRes = new HashSet<int>();
            for (int i = 0; i < values.Length; i++)
            {
                if (tempRes.Contains(values[i]))
                {
                    return false;
                }
                tempRes.Add(values[i]);
            }

            if (tempRes.Count != values.Length)
            {
                return false;
            }

            return true;
        }
    }
}
