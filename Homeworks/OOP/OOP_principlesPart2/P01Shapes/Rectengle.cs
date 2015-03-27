
namespace P01Shapes
{
    using System;

    class Rectengle : Shape
    {
        public Rectengle(double width, double height)
        {
            this.Pheight = height;
            this.Pwitdth = width;
        }

        public override double CalculateSurface()
        {
            return this.Pwitdth * this.Pheight;
        }
    }
}
