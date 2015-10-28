namespace Computers.Models.Manufacturers
{
    using System;
    using System.Collections.Generic;
    using Composite;
    using Computers;
    using CPUs;
    using Graphics;

    public class Dell : ComputerFactory
    {
        public Dell()
        {
            this.PersonalComputer = new PersonalComputer(
                new Cpu64(4),
                new SingleHardDrive(1000), 
                new RAM(8), 
                new ColorVideoCard());

            this.Server = new Server(
                new Cpu64(8), 
                new RaidDrives(
                    new List<BaseHardDrive>() 
                    { 
                        new SingleHardDrive(2000), 
                        new SingleHardDrive(2000) 
                    }), 
                new RAM(64), 
                new MonochromeVideoCard());

            this.Laptop = new Laptop(
                new Cpu32(4), 
                new SingleHardDrive(1000), 
                new RAM(8), 
                new ColorVideoCard(),
                new LaptopBattery());
        }
    }
}
