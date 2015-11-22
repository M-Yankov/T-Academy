using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MatchMaker
{
    public class MatchMakerSolver
    {                       // name             // interest
        private static Dictionary<string, Dictionary<string, int>> mans;
        private static Dictionary<string, Dictionary<string, int>> womens;

        //                       man name          woman name , matches
        private static Dictionary<string, Dictionary<string, int>> result;

        private const string manGenre = "m";
        private const string womenGenre = "f";

        public static void Main()
        {
            mans = new Dictionary<string, Dictionary<string, int>>();
            womens = new Dictionary<string, Dictionary<string, int>>();
            result = new Dictionary<string, Dictionary<string, int>>();

            //Console.SetIn(new StringReader(GetInput()));
            ReadInput();

            //Console.WriteLine("Pea".CompareTo("Gosho"));

            Solve();
        }

        private static void ReadInput()
        {
            int count = int.Parse(Console.ReadLine());
            for (int z = 0; z < count; z++)
            {
                string name = Console.ReadLine();
                string genre = Console.ReadLine();
                string numberOfInterests = Console.ReadLine();
                string[] interests = Console.ReadLine().Split(' ');

                if (numberOfInterests == "0")
                {
                    continue;
                }

                if (genre == manGenre)
                {
                    mans.Add(name, new Dictionary<string, int>());
                    for (int i = 0; i < interests.Length; i++)
                    {
                        mans[name][interests[i]] = 1;
                    }
                }
                else
                {
                    womens.Add(name, new Dictionary<string, int>());
                    for (int i = 0; i < interests.Length; i++)
                    {
                        womens[name][interests[i]] = 1;
                    }
                }
            }
        }

        private static void Solve()
        {
            int maxMathes = -1;
            string boy = string.Empty;
            string girl = string.Empty;

            foreach (var manInter in mans)
            {
                if (manInter.Value.Count < maxMathes)
                {
                    continue;
                }

                foreach (var womanInter in womens)
                {
                    Dictionary<string, int> smaller;
                    Dictionary<string, int> bigger;
                    if (manInter.Value.Count != womanInter.Value.Count)
                    {
                        smaller = manInter.Value.Count < womanInter.Value.Count ? manInter.Value : womanInter.Value;
                        bigger = manInter.Value.Count > womanInter.Value.Count ? manInter.Value : womanInter.Value;
                    }
                    else
                    {
                        smaller = manInter.Value;
                        bigger = womanInter.Value;
                    }

                    foreach (var item in smaller)
                    {
                        if (bigger.ContainsKey(item.Key))
                        {
                            if (!result.ContainsKey(manInter.Key))
                            {
                                result[manInter.Key] = new Dictionary<string, int>();
                            }

                            if (!result[manInter.Key].ContainsKey(womanInter.Key))
                            {
                                result[manInter.Key].Add(womanInter.Key, 0);
                            }

                            result[manInter.Key][womanInter.Key]++;

                            int currentValue = result[manInter.Key][womanInter.Key];
                            if (currentValue > maxMathes)
                            {
                                maxMathes = currentValue;
                                boy = manInter.Key;
                                girl = womanInter.Key;
                            }
                            else if (currentValue == maxMathes && boy.ToLower().CompareTo(manInter.Key.ToLower()) > 0)
                            {
                                boy = manInter.Key;
                                girl = womanInter.Key;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("{0} and {1} have {2} common {3}!", boy, girl, maxMathes, maxMathes == 1 ? "interest" : "interests");
        }

        private static string GetInput()
        {
            string result;
            using (StreamReader reader = new StreamReader("..\\..\\test.txt"))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
