namespace CompanyTask
{
    using System;
    using System.Collections.Generic;
    using LoremNET;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Task 2. A large trade company has millions of articles, each described by barcode, vendor, title and price.
    ///     ○ Implement a data structure to store them that allows fast retrieval of all articles in given price range [x…y].
    ///     ○ Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET.
    /// </summary>
    public class CompanyProblemSolver
    {
        /// <summary>
        /// Change product Count to 1 000 000;
        /// </summary>
        private const int ProductsCount = 10000;
        private const decimal MinPrice = 150000M;
        private const decimal MaxPrice = 160000M;

        public static void Main()
        {
            Company company = new Company();
            company.Articles = Generator.GenerateArticles(ProductsCount);

            IEnumerable<Article> articlesInRange = company.GetArticlesInRange(MinPrice, MaxPrice);
            Console.WriteLine("Products in range {0:C2} - {1:C2}", MinPrice, MaxPrice);
            foreach (var article in articlesInRange)
            {
                Console.WriteLine(article.ToString());
            }
        }
    }
}
