namespace Computers.Models.CPUs
{
    public class Cpu32 : Cpu
    {
        private const int MaxRange = 500;

        public Cpu32(byte numberOfCores)
            : base(numberOfCores, 32)
        {
        }

        protected override int GetMaxValue()
        {
            return MaxRange;
        }
    }
}
