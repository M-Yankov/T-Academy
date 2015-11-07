namespace TestsCollectionOfProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReadLargeCollectionOfProducts;
    using Wintellect.PowerCollections;

    [TestClass]
    public class CollectionOfProductsTests
    {
        private const int NumberOfTests = 500000;
        private IEnumerable<Product> products;
        private OrderedBag<Product> bag;

        [TestInitialize]
        public void Init()
        {
            this.products = Generators.GenerateProducts(500);
            this.bag = new OrderedBag<Product>(this.products, new Product());
        }

        [TestMethod]
        public void TestBagToReturnSameObjectsWhenSearchWithTwoDifferentWays()
        {
            var minRangeProd = new Product { Price = 20 };
            var maxRangeProd = new Product { Price = 5999.9555815M };

            for (int i = 0; i < NumberOfTests; i++)
            {
                decimal minPrice = Generators.GenerateDecimalNumber(0, 1000);
                decimal maxPrice = Generators.GenerateDecimalNumber(5000, 10000);

                minRangeProd.Price = minPrice;
                maxRangeProd.Price = maxPrice; 
                var result = this.bag.Where(x => x.Price >= minPrice && x.Price <= maxPrice).Take(20).ToList();
                var result2 = this.bag.Range(minRangeProd, true, maxRangeProd, true).Take(20).ToList();

                Assert.AreEqual(result.Count, result2.Count);

                for (int k = 0; k < result.Count; k++)
                {
                    result[k].Name = result2[k].Name;
                    result[k].Price = result2[k].Price;
                }
            }
        }
    }
}
