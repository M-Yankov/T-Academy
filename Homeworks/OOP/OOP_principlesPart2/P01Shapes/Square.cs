
namespace P01Shapes
{
    using System;
    class Square : Shape
    {
        public Square(double side)
        {
            this.Pheight = side;
            this.Pwitdth = side;
        }
        public override double CalculateSurface()
        {
            return this.Pheight * this.Pheight;
        }
    }
}
