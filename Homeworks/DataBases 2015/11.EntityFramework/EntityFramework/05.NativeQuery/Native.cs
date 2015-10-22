namespace NativeQuery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Norttwind;

    /// <summary>
    /// Task 4.  Implement previous by using native SQL query and executing it through the DbContext.
    /// </summary>
    public class Native
    {
        public static void Main()
        {
            const string FormatInformation = "║{0,-35}║{1,-20}║{2,-15}║";

            using (NorthwindEntities connection = new NorthwindEntities())
            {
                string nativeSql =
                    "SELECT c.CompanyName, o.RequiredDate, o.ShipCountry " +
                    "FROM [Customers] c " +
                    "JOIN [Orders] o ON c.CustomerID = o.CustomerID " +
                    "WHERE o.RequiredDate BETWEEN '1997.01.01' AND '1997.12.31' " +
                    "AND o.ShipCountry LIKE 'Canada' " +
                    "ORDER BY o.RequiredDate";

                var result = connection.Database.SqlQuery<CustomerJoinedOrder>(nativeSql);

                Console.WriteLine(FormatInformation, "CompanyName", "Date", "Country");
                foreach (var order in result)
                {
                    Console.WriteLine(FormatInformation, order.CompanyName, order.RequiredDate.Value.ToShortDateString(), order.ShipCountry);
                }
            }
        }
    }
}
