namespace Computers.Models.Manufacturers
{
    using System;
    using System.Collections.Generic;
    using Composite;
    using Computers;
    using CPUs;
    using Graphics;

    public class HP : ComputerFactory
    {
        public HP()
        {
            this.PersonalComputer = new PersonalComputer(
                new Cpu32(2),
                new SingleHardDrive(500),
                new RAM(2),
                new ColorVideoCard());

            this.Server = new Server(
                new Cpu32(4),
                new RaidDrives(
                    new List<BaseHardDrive>()
                    {
                        new SingleHardDrive(1000),
                        new SingleHardDrive(1000)
                    }),
                new RAM(32),
                new MonochromeVideoCard());

            this.Laptop = new Laptop(
                new Cpu64(2),
                new SingleHardDrive(500), 
                new RAM(4), 
                new ColorVideoCard(), 
                new LaptopBattery());
        }
    }
}