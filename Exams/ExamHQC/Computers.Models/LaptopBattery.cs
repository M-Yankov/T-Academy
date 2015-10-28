namespace Computers.Models
{
    public class LaptopBattery
    {
        private const int InitalChargePercentage = 50;
        
        public LaptopBattery() 
        {
            this.Percentage = InitalChargePercentage;
        }

        public int Percentage { get; set; }

        public void Charge(int additionalPercet)
        {
            this.Percentage += additionalPercet;
            
            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }

            if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}
