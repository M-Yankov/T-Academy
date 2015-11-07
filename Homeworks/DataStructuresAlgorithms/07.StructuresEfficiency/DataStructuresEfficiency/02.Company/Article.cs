namespace CompanyTask
{
    using System;
    using System.Collections.Generic;

    public class Article : IComparable<Article>
    {
        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("Barcode: {0}; Vendor: {1}; Title: {2}; Price: {3:C2}", this.Barcode, this.Vendor, this.Title, this.Price);
        }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
