namespace Computers.Models.Computers
{
    using Composite;
    using CPUs;
    using Graphics;

    public class PersonalComputer : BaseComputer
    {
        public PersonalComputer(Cpu cpu, BaseHardDrive hdd, RAM ram, IDrawable videoCard)
            : base(cpu, hdd, ram, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.Rand(1, 10);
            var number = this.Motherboard.LoadRamValue();
            if (number != guessNumber)
            {
                this.Motherboard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.Motherboard.DrawOnVideoCard("You win!");
            }
        }
    }
}
