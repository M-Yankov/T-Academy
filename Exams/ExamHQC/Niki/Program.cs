namespace Computers.UI
{
    using System;
    using Computers.Models;

    public class Program
    {
        private static ManufacturerFactory manufactuersFactory = new ManufacturerFactory();
        private static ManufacturerType type;

        public static void Main()
        {
            var userInput = Console.ReadLine();
            Enum.TryParse(userInput, false, out type);
            var manufacteur = manufactuersFactory.GetManufacturer(type);

            while (true)
            {
                var c = Console.ReadLine();
                if (c == null)
                {
                    break;
                }

                if (c.StartsWith("Exit"))
                {
                    break;
                }

                var cp = c.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (cp.Length != 2)
                {
                    Console.WriteLine("Invalid command!");
                    continue;
                }

                var cn = cp[0];
                var ca = int.Parse(cp[1]);

                if (cn == "Charge")
                {
                    manufacteur.Laptop.ChargeBattery(ca);
                }
                else if (cn == "Process")
                {
                    manufacteur.Server.Process(ca);
                }
                else if (cn == "Play")
                {
                    manufacteur.PersonalComputer.Play(ca);
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
            }
        }
    }
}