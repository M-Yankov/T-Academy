
namespace SalesByRegionAndPeriod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Norttwind;

    /// <summary>
    /// Task 5. Write a method that finds all the sales by specified region and period (start / end dates).
    /// </summary>
    public class StartUp
    {
        public static void Main()
        {
            SalesInREgionBetweenPeriod("SP", new DateTime(1997, 01, 01), new DateTime(2019, 01, 01));
        }

        private static void SalesInREgionBetweenPeriod(string region, DateTime startDate, DateTime endDate)
        {
            using (NorthwindEntities connection = new NorthwindEntities())
            {
                string dateFormat = "{0:yyyy.MM.dd}";

                string sqlQuery =
                    "SELECT o.EmployeeID, c.CompanyName, o.RequiredDate, o.ShipRegion  " +
                    "FROM [Customers] c " +
                    "JOIN [Orders] o ON c.CustomerID = o.CustomerID " +
                    "WHERE o.RequiredDate BETWEEN '{1}' AND '{2}' " +
                    "AND o.ShipRegion LIKE '{0}'";

                string theNewQuery =
                    string.Format(sqlQuery, region, string.Format(dateFormat, startDate), string.Format(dateFormat, endDate));

                //// s parametri ne stava nekvi gurmeji ima...
                IEnumerable<CustomerOrder> sales = connection.Database.SqlQuery<CustomerOrder>(theNewQuery);

                foreach (var sale in sales)
                {
                    Console.WriteLine(
                        "{0,-35}{1,-25}{2,-20}",
                        sale.CompanyName, 
                        sale.RequiredDate.Value.ToShortDateString(), 
                        sale.ShipRegion);
                }
            }
        }
    }
}
