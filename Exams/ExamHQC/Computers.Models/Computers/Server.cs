namespace Computers.Models.Computers
{
    using System;
    using CPUs;
    using Graphics;
    using Models.Composite;

    public class Server : BaseComputer
    {
        public Server(Cpu cpu, BaseHardDrive drives, RAM ram, IDrawable videoCard) : base(cpu, drives, ram, videoCard)
        {
        }

        public void Process(int data)
        {
            this.Motherboard.SaveRamValue(data);
            this.Cpu.SquareNumber();
        }
    }
}
