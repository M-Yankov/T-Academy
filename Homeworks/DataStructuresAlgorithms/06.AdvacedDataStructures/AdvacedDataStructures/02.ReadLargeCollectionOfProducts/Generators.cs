namespace ReadLargeCollectionOfProducts
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Task 2. Write a program to read a large collection of products (name + price) and efficiently find the first 20 products in the price range [a…b]. 
    ///     ○ Test for 500 000 products and 10 000 price searches.
    ///     ○ Hint: you may use OrderedBag<T> and sub-ranges.
    /// </summary>
    public static class Generators
    {
        private const string AlphaBetics = "abcdefghigklmnoprstquvwxyz ABCDEFGHIGKLMNOPRSTQUVWXYZ";
        private static Random generator = new Random();

        public static IEnumerable<Product> GenerateProducts(int size)
        {
            ICollection<Product> result = new List<Product>();

            for (int i = 0; i < size; i++)
            {
                result.Add(new Product()
                {
                    Price = GenerateDecimalNumber(0, 10000),
                    Name = GenerateString(i % 20)
                });
            }

            return result;
        }

        public static decimal GenerateDecimalNumber(int min, int max)
        {
            int result = generator.Next(min, max + 1);
            decimal nre = Convert.ToDecimal(result * Math.PI);
            return nre;
        }

        public static string GenerateString(int length)
        {
            StringBuilder result = new StringBuilder();
            int indexOfLetter = 0;
            for (int i = 0; i < length + 2; i++)
            {
                indexOfLetter = generator.Next(0, AlphaBetics.Length);
                result.Append(AlphaBetics[indexOfLetter]);
            }

            return result.ToString();
        }
    }
}
