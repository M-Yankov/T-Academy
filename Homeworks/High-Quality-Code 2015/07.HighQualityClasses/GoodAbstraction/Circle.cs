namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle()
            : this(1)
        {
        }

        public Circle(double radius)
        {
            this.Radius = radius;
            this.Type = "circle";
        }

        public double Radius 
        {
            get
            {
                return this.radius;
            }

            set
            {
                Validator.ValidateValue(value);
                
                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}