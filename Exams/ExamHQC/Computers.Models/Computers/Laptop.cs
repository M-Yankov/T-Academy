namespace Computers.Models.Computers
{
    using System;
    using Composite;
    using CPUs;
    using Graphics;

    public class Laptop : BaseComputer
    {
        private readonly LaptopBattery battery;

        public Laptop(Cpu cpu, BaseHardDrive hardDrives, RAM ram, IDrawable videoCard, LaptopBattery battery)
            : base(cpu, hardDrives, ram, videoCard)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);
            this.Motherboard.DrawOnVideoCard(string.Format("Battery status: {0}%", this.battery.Percentage));
        }
    }
}
