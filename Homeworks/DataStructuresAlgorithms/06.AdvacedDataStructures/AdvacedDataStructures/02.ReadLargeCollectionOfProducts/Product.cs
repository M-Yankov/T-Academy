namespace ReadLargeCollectionOfProducts
{
    using System.Collections.Generic;

    public class Product : IComparer<Product>
    {
        public decimal Price { get; set; }

        public string Name { get; set; }

        public int Compare(Product first, Product second)
        {
            return first.Price.CompareTo(second.Price);
        }

        public override string ToString()
        {
            return string.Format("{{Price: {0:F2}; Name: {1};}}", this.Price, this.Name);
        }
    }
}
