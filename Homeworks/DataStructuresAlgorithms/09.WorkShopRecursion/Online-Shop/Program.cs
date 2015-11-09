namespace OnlineShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Product
    {
        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
            this.ProductInfo = string.Format("{{{0};{1};{2}}}", this.Name, this.Producer, this.Price.ToString("F2"));
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public string ProductInfo { get; set; }

        public override string ToString()
        {
            return this.ProductInfo;
        }
    }

    public static class Program
    {
        private static StringBuilder outputResult;
        private static SortedDictionary<string, List<Product>> productsByProducer;
        private static SortedDictionary<string, List<Product>> productsByName;
        private static SortedDictionary<decimal, List<Product>> productsByPrice;
        private static int lengthOfCommands;
        public static void Pesho()
        {
            //// OrderBag
            productsByProducer = new SortedDictionary<string, List<Product>>();
            productsByName = new SortedDictionary<string, List<Product>>();
            productsByPrice = new SortedDictionary<decimal, List<Product>>();

            StreamReader reader = new StreamReader("..\\..\\test.txt");
            StreamWriter writer = new StreamWriter("..\\..\\result.txt");
            Console.SetIn(reader);
            Console.SetOut(writer);

            outputResult = new StringBuilder();

            lengthOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < lengthOfCommands; i++)
            {
                string line = Console.ReadLine();
                int firstSpace = line.IndexOf(" ");
                string command = line.Substring(0, firstSpace);

                if (command == "AddProduct")
                {
                    string[] parameters = line.Substring(firstSpace + 1).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = parameters[0];
                    decimal price = decimal.Parse(parameters[1]);
                    string producer = parameters[2];
                    var product = new Product(name, price, producer);// { Name = name, Price = price, Producer = producer };
                    if (!productsByProducer.ContainsKey(producer))
                    {
                        productsByProducer.Add(producer, new List<Product>(5000));
                    }

                    productsByProducer[producer].Add(product);

                    if (!productsByName.ContainsKey(name))
                    {
                        productsByName.Add(name, new List<Product>(5000));
                    }

                    productsByName[name].Add(product);

                    if (!productsByPrice.ContainsKey(price))
                    {
                        productsByPrice.Add(price, new List<Product>(5000));
                    }

                    productsByPrice[price].Add(product);

                    outputResult.AppendLine("Product added");


                }
                else if (command == "DeleteProducts")
                {
                    string[] deleteParameters = line.Substring(firstSpace + 1).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    int count = 0;
                    if (deleteParameters.Length == 2)
                    {
                        string name = deleteParameters[0];
                        string producer = deleteParameters[1];
                        if (productsByProducer.ContainsKey(producer) && productsByName.ContainsKey(name) &&
                            productsByProducer[producer].Count != 0 && productsByName[name].Count != 0)
                        {
                            count = productsByProducer[producer].Count(p => p.Name == name && p.Producer == producer);

                            productsByProducer[producer].RemoveAll(p => p.Name == name);
                            productsByName[name].RemoveAll(p => p.Producer == producer);

                            foreach (var pair in productsByPrice)
                            {
                                pair.Value.RemoveAll(p => p.Name == name && p.Producer == producer);
                            }
                        }
                    }
                    else
                    {
                        string producer = deleteParameters[0];

                        if (productsByProducer.ContainsKey(producer) && productsByProducer[producer].Count != 0)
                        {
                            count = productsByProducer[producer].Count;
                            productsByProducer[producer].Clear();

                            foreach (var pair in productsByName)
                            {
                                pair.Value.RemoveAll(p => p.Producer == producer);
                            }

                            foreach (var pair in productsByPrice)
                            {
                                pair.Value.RemoveAll(p => p.Producer == producer);
                            }
                        }
                    }

                    if (count == 0)
                    {
                        outputResult.AppendLine("No products found");
                    }
                    else
                    {
                        outputResult.AppendLine(string.Format("{0} products deleted", count));
                    }
                }

                else if (command == "FindProductsByName")
                {
                    string paramName = line.Substring(firstSpace + 1);

                    List<Product> results = new List<Product>();
                    if (productsByName.ContainsKey(paramName))
                    {
                        results = productsByName[paramName];
                    }

                    string res = PrintResutl(results);
                    outputResult.Append(res);
                }
                else if (command == "FindProductsByPriceRange")
                {
                    string[] searchParams = line.Substring(firstSpace + 1).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    decimal minPrice = decimal.Parse(searchParams[0]);
                    decimal maxPrice = decimal.Parse(searchParams[1]);
                    var productsInRange = new List<Product>();
                    var groupedByprice = productsByPrice.Where(p => minPrice <= p.Key && p.Key <= maxPrice);//.Select(x => x.Value);

                    foreach (var pair in groupedByprice)
                    {
                        foreach (var item in pair.Value)
                        {
                            productsInRange.Add(item);
                        }
                    }

                    string res = PrintResutl(productsInRange);
                    outputResult.Append(res);
                }
                else if (command == "FindProductsByProducer")
                {
                    string paramProducer = line.Substring(firstSpace + 1);
                    var resultsFromProducer = new List<Product>();
                    if (productsByProducer.ContainsKey(paramProducer))
                    {
                        resultsFromProducer = productsByProducer[paramProducer];
                    }
                        
                    string res = PrintResutl(resultsFromProducer);
                    outputResult.Append(res);
                }

            }

            Console.Write(outputResult.ToString());
        }

        private static string PrintResutl(IEnumerable<Product> collection)
        {
            StringBuilder result = new StringBuilder();
            if (collection.Count() == 0)
            {
                result.AppendLine("No products found");
            }
            else
            {
                foreach (var prod in collection.OrderBy(x => x.ProductInfo))
                {
                    result.AppendLine(prod.ToString());
                }
            }

            return result.ToString();
        }
    }
}
