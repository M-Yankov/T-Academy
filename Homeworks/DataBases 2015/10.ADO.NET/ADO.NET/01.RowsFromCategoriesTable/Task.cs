namespace RowsFromCategoriesTable
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    public class Task
    {
        private const string SELECT = "SELECT";
        private const string FROM = "FROM";
        private const string WHERE = "WHERE";
        private const string ORDERBY = "ORDER BY";

        public void Start()
        {
            SqlConnection dataBaseConnection =
                new SqlConnection("Server=LENOVO-G710; Database=Northwind; Integrated Security=true");
            dataBaseConnection.Open();

            using (dataBaseConnection)
            {
                //// Advise - Each method is one task execute them one by one 
                //// this.ShowCountOfRowsFromCategories(dbConnection);
                //// this.GetColumsFromCategories(dbConnection);
                //// this.GetProductAndCategories(dataBaseConnection);
                //// this.AddProduct("Kaliakra", 3, 2, "10kg", 20.60m, 40, 10, 5, false, dataBaseConnection);
                //// this.SaveCategoryImagesFromDB(dataBaseConnection);
            }
        }

        /// <summary>
        /// Task 1. Write a program that retrieves from the Northwind sample database in
        /// MS SQL Server the number of rows in the Categories table.
        /// </summary>
        /// <param name="connectionToSql">Using connection to get data from Sql Server.</param>
        private void ShowCountOfRowsFromCategories(SqlConnection connectionToSql)
        {
            Console.WriteLine("*** Task 1 ***");

            SqlCommand command = new SqlCommand(SELECT + " COUNT(*) " + FROM + " Categories ", connectionToSql);
            int result = (int)command.ExecuteScalar();
            Console.WriteLine("Rows in dbo.[Categories] = {0}", result);
        }

        /// <summary>
        /// Task 2. Write a program that retrieves the name and description of all categories in the Northwind DB.
        /// </summary>
        /// <param name="connectionToSql">Using connection to get data from Sql Server.</param>
        private void GetColumsFromCategories(SqlConnection connectionToSql)
        {
            const string CategoryName = "CategoryName";
            const string Description = "Description";
            Console.WriteLine("*** Task 2 ***");

            SqlCommand command = new SqlCommand(SELECT + " " + CategoryName + ", " + Description + " " + FROM + " Categories", connectionToSql);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            using (sqlDataReader)
            {
                Console.WriteLine(string.Format("{0,-20} {1,-20}", CategoryName, Description));
                while (sqlDataReader.Read())
                {
                    string categoryName = sqlDataReader[CategoryName].ToString();
                    string categoryDescription = sqlDataReader[Description].ToString();
                    Console.WriteLine(string.Format("{0,-20} {1,-20}", categoryName, categoryDescription));
                }
            }
        }

        /// <summary>
        ///  Task 3. Write a program that retrieves from the Northwind database all product categories
        ///  and the names of the products in each category.
        ///     ○ Can you do this with a single SQL query (with table join)?
        /// </summary>
        /// <param name="connectionToSql">Using connection to get data from Sql Server.</param>
        private void GetProductAndCategories(SqlConnection connectionToSql)
        {
            Console.WriteLine("*** Task 3 ***");

            SqlCommand command =
                new SqlCommand(
                               "Select distinct c.CategoryName + ' -> ' AS [Category], " +
                               "    substring(                                         " +
                               "        (                                              " +
                               "            Select ','+ p.ProductName AS [text()]      " +
                               "            From Products p                            " +
                               "            Where p.CategoryID = c.CategoryID          " +
                               "            FOR XML PATH ('')                          " +
                               "        ), 2, 5000) AS [ProductNames]                  " +
                               "FROM [dbo].[Categories] c                             ",
                    connectionToSql);

            SqlDataReader sqlReader = command.ExecuteReader();

            using (sqlReader)
            {
                while (sqlReader.Read())
                {
                    Console.WriteLine(sqlReader["Category"]);
                    string[] productNames = sqlReader["ProductNames"].ToString().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string product in productNames)
                    {
                        Console.WriteLine("\t* {0}", product);
                    }
                }
            }
        }

        /// <summary>
        /// Task 4. Write a method that adds a new product in the products table in the Northwind database.
        ///     ○ Use a parameterized SQL command.
        /// </summary>
        /// <param name="productName">Name of the product to add.</param>
        /// <param name="connectionToSql">Using connection to get data from Sql Server.</param>
        private void AddProduct(
            string productName,
            int supliedID,
            int categoryID,
            string quantityPerUnit,
            decimal pricePerUnit,
            int unitsInStock,
            int unitsOnOrder,
            int recorderLevel,
            bool discounted,
            SqlConnection connectionToSql)
        {
            SqlCommand insertCommand =
                new SqlCommand(
                               "INSERT INTO PRODUCTS(ProductName, SupplierID, CategoryID , QuantityPerUnit, " +
                               "UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES " +
                               "(@prodName, @supplier, @category, @qtyPerUnit, @unitPrice, @inStock, @onOrder, " +
                               "@reorderLevel, @discounted)",
                    connectionToSql);

            insertCommand.Parameters.AddWithValue("@prodName", productName);
            insertCommand.Parameters.AddWithValue("@supplier", supliedID);
            insertCommand.Parameters.AddWithValue("@category", categoryID);
            insertCommand.Parameters.AddWithValue("@qtyPerUnit", quantityPerUnit);
            insertCommand.Parameters.AddWithValue("@unitPrice", pricePerUnit);
            insertCommand.Parameters.AddWithValue("@inStock", unitsInStock);
            insertCommand.Parameters.AddWithValue("@onOrder", unitsOnOrder);
            insertCommand.Parameters.AddWithValue("@reorderLevel", recorderLevel);
            insertCommand.Parameters.AddWithValue("@discounted", Convert.ToByte(discounted));

            insertCommand.ExecuteNonQuery();
            Console.WriteLine("Insert Completed");
        }

        /// <summary>
        ///  Task 2. Write a program that retrieves the images for all categories in the Northwind database
        ///  and stores them as JPG files in the file system.
        /// </summary>
        /// <param name="dataBaseConnection">Using connection to get data from Sql Server.</param>
        private void SaveCategoryImagesFromDB(SqlConnection dataBaseConnection)
        {
            //// for me it's easy to check result on the desktop. If you don't like it - change it. 
            string pathToImages = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Images";
            if (!Directory.Exists(pathToImages))
            {
                Directory.CreateDirectory(pathToImages);
            }

            SqlCommand getImages = new SqlCommand(SELECT + " Picture " + FROM + " Categories", dataBaseConnection);
            SqlDataReader sqlReader = getImages.ExecuteReader();

            int counter = 1;
            int somethingSpecial = 78;

            using (sqlReader)
            {
                while (sqlReader.Read())
                {
                    FileStream fileStream = 
                        new FileStream(pathToImages + "/image" + counter + ".jpeg", FileMode.CreateNew, FileAccess.Write);
                    byte[] imageCode = (byte[])sqlReader["Picture"];
                    fileStream.Write(imageCode, somethingSpecial, imageCode.Length - somethingSpecial);
                    fileStream.Flush();
                    fileStream.Close();
                    counter++;
                }
            }

            Console.WriteLine("Images are ready in {0}", pathToImages);
        }
    }
}