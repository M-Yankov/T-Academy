namespace Computers.Models.CPUs
{
    public class Cpu64 : Cpu
    {
        private const int MaxValue = 1000;

        public Cpu64(byte numberOFCores) : base(numberOFCores, 64)
        {
        }

        protected override int GetMaxValue()
        {
            return MaxValue;
        }
    }
}