namespace CompanyTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LoremNET;
    using Wintellect.PowerCollections;

    public static class Generator
    {
        private static Random generator = new Random();
        private static IEnumerable<string> loremParagraphs = Lorem.Paragraphs(100, 100, 100);
        private static IList<string> loremWords = new List<string>();
        private static int minPrice = 150000;
        private static int maxPrice = 9999000;

        private static bool IsInitialized { get; set; }

        public static OrderedMultiDictionary<decimal, Article> GenerateArticles(int length)
        {
            if (!IsInitialized)
            {
                Initialize();
                IsInitialized = true;
            }

            OrderedMultiDictionary<decimal, Article> result = new OrderedMultiDictionary<decimal, Article>(true);
            Article articleToAdd;
            for (int i = 0; i <= length; i++)
            {
                articleToAdd = new Article
                {
                    Barcode = loremWords[(int)Lorem.Number(0, loremWords.Count - 1)],
                    Title = loremWords[(int)Lorem.Number(0, loremWords.Count - 1)],
                    Vendor = loremWords[(int)Lorem.Number(0, loremWords.Count - 1)],
                    Price = GetPrice(minPrice, maxPrice)
                };

                decimal key = articleToAdd.Price;
                result.Add(key, articleToAdd);

                if (i % 5000 == 0)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Write(i + " products added.");
                }
            }

            Console.WriteLine();
            return result;
        }

        public static decimal GetPrice(int min, int max)
        {
            long number = Lorem.Number(min, max);
            return (decimal)(number + Math.PI); 
        }

        private static void Initialize()
        {
            foreach (var item in loremParagraphs)
            {
                item.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Length > 5).ToList().ForEach(word => loremWords.Add(word));
            }
        }
    }
}
