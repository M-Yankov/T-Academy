namespace Facade
{
    using System;
    using System.Linq;

    class Beer : Alcohol
    {
        private int beerDegees;

        public Beer(int degrees)
        {
            this.Degrees = degrees;
        }

        public int Degrees
        {
            get
            {
                return this.beerDegees;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Degrees cannot be under zero!", value.ToString());
                }

                this.beerDegees = value;
            }
        }
    }
}
