namespace Norttwind
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Task 2. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers.
    ///     ○ Write a testing classes.
    /// </summary>
    public static class DataAccessObject
    {
        private const string Empty = "";
        private static NorthwindEntities dataConnection;

        internal static void InsertEmployee(
            string companyName,
            string contactName,
            string contactTitle = Empty,
            string address = Empty,
            string city = Empty,
            string region = Empty,
            string postalCode = Empty,
            string country = Empty,
            string phone = Empty,
            string fax = Empty)
        {
            Customer newCustomer = new Customer()
            {
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = (contactTitle != Empty ? contactTitle : null),
                Address = (address != Empty ? address : null),
                City = (city != Empty ? city : null),
                Region = (region != Empty ? region : null),
                PostalCode = (postalCode != Empty ? postalCode : null),
                Country = (country != Empty ? country : null),
                Phone = (phone != Empty ? phone : null),
                Fax = (fax != Empty ? fax : null)
            };

            using (dataConnection = new NorthwindEntities())
            {
                IList<string> idsOfCustomers = dataConnection.Customers.Select(cust => cust.CustomerID).ToList();
                string idOftheNewCustomer = GenrateID(companyName, idsOfCustomers);
                newCustomer.CustomerID = idOftheNewCustomer;
                try
                {
                    dataConnection.Customers.Add(newCustomer);
                    dataConnection.SaveChanges();
                }
                catch (Exception ex)
                {
                    var a = (ex as System.Data.Entity.Validation.DbEntityValidationException).EntityValidationErrors.ToList()[0].ValidationErrors.ToList()[0];
                    Console.WriteLine(a);
                    ShowMessage(ex);
                }
            }
        }

        internal static void UpdateCustomer()
        {
            using (dataConnection = new NorthwindEntities())
            {
                Customer customerToUpdate = dataConnection.Customers.Where(cust => cust.CustomerID == "EATEN").FirstOrDefault();

                //// Test update
                customerToUpdate.Fax = "090-123";
                customerToUpdate.Phone = "2883812";
                customerToUpdate.PostalCode = "0231";
                int rowsChnaged = dataConnection.SaveChanges();

                if (rowsChnaged == 0)
                {
                    Console.WriteLine("Nothing changed");
                }
                else
                {
                    Console.WriteLine("Success");
                }
            }
        }

        internal static void RemoveCustomer(string idOfTheCustomer)
        {
            using (dataConnection = new NorthwindEntities())
            {
                Customer customerToRemove = dataConnection.Customers.Where(cust => cust.CustomerID == idOfTheCustomer).FirstOrDefault();
                dataConnection.Customers.Remove(customerToRemove);
                int rowsChanged = dataConnection.SaveChanges();
                string message = rowsChanged != 0 ? "Success" : "NothingChanged";
                Console.WriteLine(message);
            }
        }

        private static void ShowMessage(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            Console.WriteLine(ex.Message);
        }

        private static string GenrateID(string companyName, IList<string> allIds)
        {
            int lengthOfId = 5;
            int indexer = lengthOfId;
            StringBuilder result = new StringBuilder();
            result.Append(companyName.Substring(0, lengthOfId));

            while (allIds.Contains(result.ToString().ToUpper()) && indexer < companyName.Length)
            {
                indexer++;
                result[lengthOfId - 1] = Convert.ToChar(companyName.Substring(indexer, 1));
            }

            return result.ToString().ToUpper();
        }
    }
}
