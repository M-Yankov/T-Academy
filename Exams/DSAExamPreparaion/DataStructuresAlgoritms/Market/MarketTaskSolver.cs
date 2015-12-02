namespace Market
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class MarketTaskSolver
    {
        public static void Main(string[] args)
        {
            //StreamReader tests = new StreamReader("..\\..\\test.txt");
            //Console.SetIn(tests);

            StringBuilder result = new StringBuilder();
            Market market = new Market();

            string line = string.Empty;
            while (line != CommandTypes.End)
            {
                line = Console.ReadLine();
                string[] lineArgumnets = line.Split(' ');
                string command = lineArgumnets[0];

                switch (command)
                {
                    case CommandTypes.Add:
                        string resultFromAdd = market.Add(new Product() { Name = lineArgumnets[1], Price = double.Parse(lineArgumnets[2]), Type = lineArgumnets[3] });
                        result.AppendLine(resultFromAdd);
                        break;

                    case CommandTypes.Filter:
                        string filterOption = lineArgumnets[2];

                        switch (filterOption)
                        {
                            case FilterOprions.ByType:
                                string type = lineArgumnets[3];
                                if (market.IsProductTypeExist(type))
                                {
                                    result.AppendLine(string.Format("Ok: {0}", string.Join(", ", market.GetProductsByType(type))));
                                }
                                else
                                {
                                    result.AppendLine(string.Format("Error: Type {0} does not exists", type));
                                }
                                break;

                            case FilterOprions.ByPrice:
                                double minPrice = 0.0;
                                double maxPrice = double.MaxValue;

                                if (lineArgumnets.Length == 7)
                                {
                                    minPrice = double.Parse(lineArgumnets[4]);
                                    maxPrice = double.Parse(lineArgumnets[6]);
                                }
                                else if (lineArgumnets[3] == "from")
                                {
                                    minPrice = double.Parse(lineArgumnets[4]);
                                }
                                else
                                {
                                    maxPrice = double.Parse(lineArgumnets[4]);
                                }

                                result.AppendLine(string.Format("Ok: {0}", string.Join(", ", market.GetProductsByPrice(minPrice, maxPrice))));
                                break;

                            default:
                                break;
                        }

                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }

    public class CommandTypes
    {
        public const string Add = "add";
        public const string Filter = "filter";
        public const string End = "end";
    }

    public class FilterOprions
    {
        public const string ByType = "type";
        public const string ByPrice = "price";
    }

    public class Market
    {
        private const int DefaultNumberOfProduts = 10;
        private SortedSet<Product> productsByName ;
        private IDictionary<string, SortedSet<Product>> productsByType ;
        private IDictionary<double, SortedSet<Product>> productsByPrices ;
        private SortedSet<double> prices;

        public Market()
        {
            productsByName = new SortedSet<Product>();
            productsByType = new Dictionary<string, SortedSet<Product>>();
            productsByPrices = new Dictionary<double, SortedSet<Product>>();
            prices = new SortedSet<double>();
        }

        public string Add(Product product)
        {
            //// OMG! DO noy USe .Any(x => x... == ... )!
            if (this.productsByName.Contains(product))
            {
                return string.Format("Error: Product {0} already exists", product.Name);
            }

            if (!this.productsByType.ContainsKey(product.Type))
            {
                //// this.productsByType.Add[product.Type] = new SortedSet<Product>();
                productsByType.Add(product.Type, new SortedSet<Product>());
            }

            if (!this.productsByPrices.ContainsKey(product.Price))
            {
                productsByPrices.Add(product.Price, new SortedSet<Product>());
            }

            this.productsByPrices[product.Price].Add(product);
            this.productsByType[product.Type].Add(product);
            this.prices.Add(product.Price);
            this.productsByName.Add(product);

            return string.Format("Ok: Product {0} added successfully", product.Name);
        }

        public IEnumerable<Product> GetProductsByType(string type)
        {
            return this.productsByType[type].Take(DefaultNumberOfProduts);
        }

        public IEnumerable<Product> GetProductsByPrice(double minPrice, double maxPrice)
        {
            List<Product> result = new List<Product>();

            var filteredPrices = this.prices.GetViewBetween(minPrice, maxPrice);
            if (filteredPrices.Count == 0)
            {
                return result;
            }

            foreach (var price in filteredPrices)
            {
                foreach (var product in this.productsByPrices[price])
                {
                    result.Add(product);
                    if (result.Count == 10)
                    {
                        break;
                    }
                }

                if (result.Count == 10)
                {
                    break;
                }
            }

            return result;
        }

        public bool IsProductTypeExist(string type)
        {
            if (this.productsByType.ContainsKey(type))
            {
                return true;
            }

            return false;
        }
    }

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public int CompareTo(Product other)
        {
            int result = this.Price.CompareTo(other.Price);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
                if (result == 0)
                {
                    result = this.Type.CompareTo(other.Type);
                }
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }
    }
}
