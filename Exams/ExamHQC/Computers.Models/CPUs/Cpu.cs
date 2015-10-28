namespace Computers.Models.CPUs
{
    using System;

    public abstract class Cpu : IMotherboardComponent
    {
        private static readonly Random Random = new Random();
        private readonly byte numberOfBits;
        private string lowNumberNessage = "Number too low.";
        private string highNumberMessge = "Number too high.";
        private string stringFormatsquarenumber = "Square of {0} is {1}.";

        public Cpu(byte numberOfCores, byte numberOfBits)
        {
            this.numberOfBits = numberOfBits;
            this.NumberOfCores = numberOfCores;
        }

        public IMotherboard Motherboard { get; set; }

        public byte NumberOfCores { get; set; }

        public string MessageForLowNumber
        {
            get
            {
                return this.lowNumberNessage;
            }
        }

        public string MessageForHighNumber
        {
            get
            {
                return this.highNumberMessge;
            }
        }

        public string SqureNumberStringFormat
        {
            get
            {
                return this.stringFormatsquarenumber;
            }
        }

        public void AttachTo(IMotherboard motherboard)
        {
            this.Motherboard = motherboard;
        }

        public void SquareNumber()
        {
            var number = this.Motherboard.LoadRamValue();
            if (number < 0)
            {
                this.Motherboard.DrawOnVideoCard(this.MessageForLowNumber);
            }
            else if (number > this.GetMaxValue())
            {
                this.Motherboard.DrawOnVideoCard(this.MessageForHighNumber);
            }
            else
            {
                int squareValue = number * number;
                this.Motherboard.DrawOnVideoCard(string.Format(this.SqureNumberStringFormat, number, squareValue));
            }
        }

        public void Rand(int minNumber, int maxNumber)
        {
            int randomNumber = Random.Next(minNumber, maxNumber + 1);
            this.Motherboard.SaveRamValue(randomNumber);
        }

        protected abstract int GetMaxValue();
    }
}