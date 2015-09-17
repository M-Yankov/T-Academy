
namespace Facade
{
    using System;
    using System.Linq;

    public class Container
    {
        private ContainerType type;
        private double liters;

        public Container(ContainerType containerType, double litres)
        {
            this.Type = containerType;
            this.Liters = litres;
            this.FilledWith = null;
            this.CurrentLiters = 0;
        }

        public ContainerType Type
        {
            get
            { 
                return this.type; 
            }
            set
            { 
                this.type = value; 
            }
        }

        public double Liters
        { 
            get
            {
                return this.liters;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Liters cannot be under zero!", value.ToString());
                }
                this.liters = value;
            }
        }

        public double CurrentLiters { get; set; }

        public Alcohol FilledWith { get; set; }
    }
}
