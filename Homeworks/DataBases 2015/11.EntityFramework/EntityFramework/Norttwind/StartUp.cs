namespace Norttwind
{
    using System;
    using System.Linq;

    public class StartUp
    {
        /// <summary>
        /// Task 1. Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database
        /// </summary>
        public static void Main()
        {
            using (NorthwindEntities dataBaseConnection = new NorthwindEntities())
            {
                //// Do queries
            }

            //// Test insert
            DataAccessObject.InsertEmployee("Eaten apple", "Gosho pochivka", "Owner", "Amzon 89 avenu");
           
            DataAccessObject.UpdateCustomer();
            DataAccessObject.RemoveCustomer("EATEA");
        }
    }
}
