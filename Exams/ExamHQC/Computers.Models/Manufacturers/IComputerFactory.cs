namespace Computers.Models.Manufacturers
{
    using System;
    using Models.Computers;

    public abstract class ComputerFactory
    {
        public PersonalComputer PersonalComputer { get; set; }

        public Laptop Laptop { get; set; }

        public Server Server { get; set; }
    }
}
