namespace ConcurentProblem
{
    using System;
    using System.Linq;
    using Norttwind;

    /// <summary>
    ///  Try to open two different data contexts and perform concurrent changes on the same records.
    ///     ○ What will happen at SaveChanges()? A: Last one wins.
    ///     ○ How to deal with it? A Probably use some configuration option on the context.
    /// </summary>
    public class StartUp
    {
        public static void Main()
        {
            NorthwindEntities connection = new NorthwindEntities();
            NorthwindEntities anotherConnection = new NorthwindEntities();

            Customer anton = connection.Customers.Where(cust => cust.CustomerID == "ANTON").FirstOrDefault();
            Customer antonio = anotherConnection.Customers.Where(cust => cust.CustomerID == "ANTON").FirstOrDefault();

            
            anton.Region = "BG";
            antonio.Region = "GR";

            connection.SaveChanges();
            anotherConnection.SaveChanges();

            connection.Dispose();
            anotherConnection.Dispose();
        }
    }
}
