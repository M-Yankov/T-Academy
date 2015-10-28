namespace Computers.Models.Manufacturers
{
    using System;
    using System.Collections.Generic;
    using Composite;
    using Computers;
    using CPUs;
    using Graphics;

    public class Lenovo : ComputerFactory
    {
        public Lenovo()
        {
            this.PersonalComputer = new PersonalComputer(
                new Cpu64(2),
                new SingleHardDrive(2000),
                new RAM(4),
                new MonochromeVideoCard());

            this.Server = new Server(
                new Cpu128(2),
                new RaidDrives(new List<BaseHardDrive>()
                {
                    new SingleHardDrive(500),
                    new SingleHardDrive(500)
                }),
                new RAM(8),
                new MonochromeVideoCard());
 
            this.Laptop = new Laptop(
                new Cpu64(2),
                new SingleHardDrive(1000),
                new RAM(16),
                new ColorVideoCard(),
                new LaptopBattery());
        }
    }
}