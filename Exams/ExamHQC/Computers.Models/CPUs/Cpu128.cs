namespace Computers.Models.CPUs
{
    using System;

    public class Cpu128 : Cpu
    {
        private const int MaxValue = 2000;

        public Cpu128(byte numberOfCores) : base(numberOfCores, 128)
        {
        }

        protected override int GetMaxValue()
        {
            return MaxValue;
        }
    }
}