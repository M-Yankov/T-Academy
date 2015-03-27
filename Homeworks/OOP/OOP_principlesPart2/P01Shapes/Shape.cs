
namespace P01Shapes
{
    abstract class Shape
    {
        private double width;

        private double height;

        public double Pheight
        {
            get { return this.height; }
            set { this.height = value; }
        }
        
        public double Pwitdth
        {
            get { return this.width; }
            set { this.width = value; }
        }
        
        public virtual double CalculateSurface()
        {
            return 0;
        }
        
    }
}
