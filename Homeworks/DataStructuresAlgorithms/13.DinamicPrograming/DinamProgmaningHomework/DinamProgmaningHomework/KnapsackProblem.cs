namespace DinamProgmaningHomework
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;
    using System.IO;

    /// <summary>
    /// But In The Solution cannon find current products
    /// </summary>
    public class KnapsackProblem
    {
        public static void Main()
        {
            Console.SetIn(new StringReader(GetInput()));

            List<Product> products = new List<Product>();

            int countOfProducts = int.Parse(Console.ReadLine());
            int maxWeight = int.Parse(Console.ReadLine());
            int[] costs = new int[countOfProducts];

            for (int i = 0; i < countOfProducts; i++)
            {
                string[] lineArgs = Console.ReadLine().Split(new char[] { ' ', '=', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = lineArgs[0];

                int price = int.Parse(lineArgs[5]);
                costs[i] = price;

                products.Add(new Product() { Name = name, Weight = int.Parse(lineArgs[3]), Cost = price });
            }

            var answer = Solve(products, costs, maxWeight);
            Console.WriteLine("cost={0} weight={1}", answer.Key, answer.Value);
        }

        public static KeyValuePair<int, int> Solve(IList<Product> products, int[] costs, int maxWeight)
        {
            List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();   // new int[maxWeight + 1];
            result.Add(new KeyValuePair<int, int>(0, 0));

            for (int i = 0; i < products.Count; i++)
            {
                //// Because we add elements in the result inside loop
                int realCount = result.Count;
                for (int k = 0; k < realCount; k++)
                {
                    if (products[i].Weight + result[k].Key > maxWeight)
                    {
                        continue;
                    }

                    result.Add(new KeyValuePair<int, int>(products[i].Weight + result[k].Key, result[k].Value + products[i].Cost));
                }
            }

            int maxCost = int.MinValue;
            int weight = 0;

            //// log / 2
            for (int start = 0, end = result.Count - 1; start <= end; start++, end--)
            {
                if (result[start].Value > maxCost)
                {
                    maxCost = result[start].Value;
                    weight = result[start].Key;
                }

                if (result[end].Value > maxCost)
                {
                    maxCost = result[end].Value;
                    weight = result[end].Key;
                }
            }

            //// Key = max cost, Value = Weight
            return new KeyValuePair<int, int>(maxCost, weight);
        }

        internal static string GetInput()
        {
            return @"7
20
beer – weight=10, cost=13
vodka – weight=3, cost=8
cheese – weight=11, cost=5
nuts – weight=5, cost=6
ham – weight=10, cost=1
whiskey – weight=8, cost=3
cheese – weight=4, cost=8
";
        }
    }

    public class Product
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Cost { get; set; }
    }
}
