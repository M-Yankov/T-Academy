using System;


    class Company
    {
        static void Main()
        {
            Console.Write("Company name: ");
            string companyName = Console.ReadLine();
            Console.Write("Company address: ");
            string companyAdres = Console.ReadLine();
            Console.Write("Phone number: ");
            string phone = Console.ReadLine();
            Console.Write("Fax: ");
            string fax = Console.ReadLine();
            if(fax.Length<5)
            {
                fax = "(no fax)";
            }
            Console.Write("Website: ");
            string webSite = Console.ReadLine();
            if (!webSite.Contains("www"))
            {
                Console.WriteLine("Make sure you enter correct url address");
            }
            Console.Write("Manager first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Manager last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Manager age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Manager phone: ");
            string mangPhone = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(companyName+"\nAddress\t\t"+ companyAdres +"\nTel. \t\t"+ phone+"\nFax: \t\t"+fax +"\nWeb Site: \t"+ webSite);
            Console.WriteLine("Manager: \t{0} {1} (Age: {2}, tel. {3}) ", firstName, lastName, age, phone);
        }
    }
