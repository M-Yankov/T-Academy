namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;
        
        private double height;

        public Rectangle() 
            : this(1, 1)
        {
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
            this.Type = "rectengle";
        }

        public double Width 
        {
            get 
            { 
                return this.width;
            }

            set 
            {
                Validator.ValidateValue(value);

                this.width = value; 
            } 
        }

        public double Height 
        {
            get
            {
                return this.height; 
            }

            set
            {
                Validator.ValidateValue(value);

                this.height = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}