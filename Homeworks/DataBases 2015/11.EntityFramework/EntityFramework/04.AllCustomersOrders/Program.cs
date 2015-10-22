namespace AllCustomersOrders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Norttwind;

    /// <summary>
    /// Task 3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            using (NorthwindEntities connectionToDataBase = new NorthwindEntities())
            {
                var meshWithGrapes =
                    from customer in connectionToDataBase.Customers
                    join order in connectionToDataBase.Orders
                    on customer.CustomerID equals order.CustomerID
                    where order.ShipCountry == "Canada" &&
                          order.OrderDate >= new DateTime(1997, 1, 1) &&
                          order.OrderDate <= new DateTime(1997, 12, 31)
                    orderby order.RequiredDate
                    select new
                    {
                        Company = customer.CompanyName,
                        OrderDate = order.RequiredDate,
                        OrderCountry = order.ShipCountry
                    };

                int maxLengthCompany = 0;
                int maxLengthDate = 0;
                int maxLengthCountry = 0;

                meshWithGrapes
                    .ToList()
                    .ForEach(
                    x =>
                    {
                        maxLengthCompany = Math.Max(maxLengthCompany, x.Company.Length);
                        maxLengthDate = Math.Max(maxLengthDate, x.OrderDate.Value.ToShortDateString().Length);
                        maxLengthCountry = Math.Max(maxLengthCountry, x.OrderCountry.Length);
                    });

                maxLengthCompany += 5;
                maxLengthDate += 5;
                maxLengthCountry += 5;

                //// I heard that you love high quality code, so I just write some pretty code below 
                Console.WriteLine(
                    "┌{0}┬{1}┬{2}┐",
                    new string('─', maxLengthCompany),
                    new string('─', maxLengthDate),
                    new string('─', maxLengthCountry));
                Console.WriteLine("│{0,-" + maxLengthCompany + "}│{1,-" + maxLengthDate + "}│{2,-" + maxLengthCountry + "}│", "Name", "Date", "Country");
                Console.WriteLine(
                    "├{0}┼{1}┼{2}┤",
                    new string('─', maxLengthCompany),
                    new string('─', maxLengthDate),
                    new string('─', maxLengthCountry));
                foreach (var customerOrder in meshWithGrapes)
                {
                    Console.WriteLine(
                        "│{0,-" + maxLengthCompany + "}│{1,-" + maxLengthDate + "}│{2,-" + maxLengthCountry + "}│",
                        customerOrder.Company,
                        customerOrder.OrderDate.Value.ToShortDateString(),
                        customerOrder.OrderCountry);
                    Console.WriteLine(
                        "├{0}┼{1}┼{2}┤",
                        new string('─', maxLengthCompany),
                        new string('─', maxLengthDate),
                        new string('─', maxLengthCountry));
                }

                Console.WriteLine(
                    "└{0}┴{1}┴{2}┘",
                    new string('─', maxLengthCompany),
                    new string('─', maxLengthDate),
                    new string('─', maxLengthCountry));
            }
        }
    }
}
