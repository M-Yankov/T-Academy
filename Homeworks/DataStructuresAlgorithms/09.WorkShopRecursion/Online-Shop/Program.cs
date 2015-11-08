namespace OnlineShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    class Program
    {
        private static SortedDictionary<string, List<Product>> productsByProducer;
        private static SortedDictionary<string, List<Product>> productsByName;
        private static SortedDictionary<double, List<Product>> productsByPrice;

        static void Main()
        {
            //// OrderBag
            productsByProducer = new SortedDictionary<string, List<Product>>();
            productsByName = new SortedDictionary<string, List<Product>>();
            productsByPrice = new SortedDictionary<double, List<Product>>();

            StreamReader reader = new StreamReader("..\\..\\input.txt");
            Console.SetIn(reader);

            int lengthOfCommands = int.Parse(Console.ReadLine());


            for (int i = 0; i < lengthOfCommands; i++)
            {
                string line = Console.ReadLine();
                int firstSpace = line.IndexOf(" ");
                string command = line.Substring(0, line.IndexOf(" "));
                switch (command)
                {
                    case "AddProduct":
                        string[] parameters = line.Substring(firstSpace + 1).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        string name = parameters[0];
                        double price = double.Parse(parameters[1]);
                        string producer = parameters[2];
                        var product = new Product { Name = name, Price = price, Producer = producer };
                        if (!productsByProducer.ContainsKey(producer))
                        {
                            productsByProducer.Add(producer, new List<Product>());
                        }

                        productsByProducer[producer].Add(product);

                        if (!productsByName.ContainsKey(name))
                        {
                            productsByName.Add(name, new List<Product>());
                        }

                        productsByName[name].Add(product);

                        if (!productsByPrice.ContainsKey(price))
                        {
                            productsByPrice.Add(price, new List<Product>());
                        }

                        productsByPrice[price].Add(product);

                        Console.WriteLine("Product added");
                        break;

                    case "DeleteProducts":
                        string[] deleteParameters = line.Substring(firstSpace + 1).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                        int count = 0;
                        if (deleteParameters.Length == 2)
                        {
                            if (productsByProducer.ContainsKey(deleteParameters[1]) && productsByName.ContainsKey(deleteParameters[0]))
                            {
                                count = productsByProducer[deleteParameters[1]].Count(p => p.Name == deleteParameters[0] && p.Producer == deleteParameters[1]);
                                productsByProducer[deleteParameters[1]].RemoveAll(p => p.Name == deleteParameters[0] && p.Producer == deleteParameters[1]);
                                productsByName[deleteParameters[0]].RemoveAll(p => p.Name == deleteParameters[0] && p.Producer == deleteParameters[1]);

                                foreach (var pair in productsByPrice)
                                {
                                    pair.Value.RemoveAll(p => p.Name == deleteParameters[0] && p.Producer == deleteParameters[1]);
                                }
                            }
                        }
                        else
                        {
                            if (productsByProducer.ContainsKey(deleteParameters[0]))
                            {
                                count = productsByProducer[deleteParameters[0]].Count(p => p.Producer == deleteParameters[0]);
                                productsByProducer[deleteParameters[0]].RemoveAll(p => p.Producer == deleteParameters[0]);

                                foreach (var pair in productsByName)
                                {
                                    pair.Value.RemoveAll(p => p.Producer == deleteParameters[0]);
                                }

                                foreach (var pair in productsByPrice)
                                {
                                    pair.Value.RemoveAll(p => p.Producer == deleteParameters[0]);
                                }
                            }
                        }

                        Console.WriteLine("{0} products deleted", count);
                        break;

                    case "FindProductsByName":
                        string paramName = line.Substring(firstSpace).Trim();

                        List<Product> results = new List<Product>();
                        if (productsByName.ContainsKey(paramName))
                        {
                            results = productsByName[paramName];
                        }

                        PrintResutl(results);
                        break;

                    case "FindProductsByPriceRange":
                        string[] searchParams = line.Substring(firstSpace + 1).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        double minPrice = double.Parse(searchParams[0]);
                        double maxPrice = double.Parse(searchParams[1]);
                        var productsInRange = new List<Product>();
                        var groupedByprice = productsByPrice.Where(p => minPrice <= p.Key && p.Key <= maxPrice);//.Select(x => x.Value);

                        foreach (var pair in groupedByprice)
                        {
                            foreach (var item in pair.Value)
                            {
                                productsInRange.Add(item);
                            }
                        }

                        PrintResutl(productsInRange);
                        break;

                    case "FindProductsByProducer":
                        string paramProducer = line.Substring(firstSpace).Trim();
                        var resultsFromProducer = productsByProducer[paramProducer];
                        PrintResutl(resultsFromProducer);
                        break;

                    default:
                        throw new InvalidOperationException("No such Command!");

                }
            }
        }

        private static void PrintResutl(IEnumerable<Product> collection)
        {
            StringBuilder result = new StringBuilder();
            if (collection.Count() == 0)
            {
                result.AppendLine("No products found");
            }
            else
            {
                foreach (var prod in collection.OrderBy(x => x.Name))
                {
                    result.AppendLine(prod.ToString());
                }
            }

            Console.Write(result.ToString());
        }
    }

    internal class Product : IComparer<Product>
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Producer { get; set; }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2}}}", this.Name, this.Producer, this.Price.ToString("F2"));
        }

        public int Compare(Product x, Product y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
