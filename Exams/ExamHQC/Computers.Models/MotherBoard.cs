namespace Computers.Models
{
    using CPUs;
    using Graphics;

    public class MotherBoard : IMotherboard
    {
        private RAM ramOnTheBoard;
        private IDrawable integratedVideoCard;

        public MotherBoard(Cpu cpu, RAM ram, IDrawable video)
        {
            cpu.AttachTo(this);
            this.ramOnTheBoard = ram;
            this.integratedVideoCard = video;
        }

        public int LoadRamValue()
        {
            return this.ramOnTheBoard.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.ramOnTheBoard.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.integratedVideoCard.Draw(data);
        }
    }
}
