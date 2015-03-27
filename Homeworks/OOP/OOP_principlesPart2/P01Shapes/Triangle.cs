
namespace P01Shapes
{
    using System;
    class Triangle : Shape
    {
        public Triangle(double side , double height)
        {
            this.Pheight = height;
            this.Pwitdth = side;
        }

        public override double CalculateSurface()
        {
            return (this.Pheight * this.Pwitdth) / 2;
        }
    }
}
