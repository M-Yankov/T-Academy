namespace Computers.Models.Computers
{
    using System;
    using Composite;
    using CPUs;
    using Graphics;

    public abstract class BaseComputer 
    {
        public BaseComputer(Cpu cpu, BaseHardDrive hardDrives, RAM ram, IDrawable videoCard)
        {
            this.Cpu = cpu;
            this.HardDrives = hardDrives;
            this.Motherboard = new MotherBoard(cpu, ram, videoCard);
        }

        protected IMotherboard Motherboard { get; set; }

        protected Cpu Cpu { get; set; }

        protected BaseHardDrive HardDrives { get; set; }
    }
}
