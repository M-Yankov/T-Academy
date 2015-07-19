namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        public string Type { get; set; }

        public virtual double CalcPerimeter()
        {
            double perimeter = 0.0;
            return perimeter;
        }

        public virtual double CalcSurface()
        {
            double surface = 0.0;
            return surface;
        }

        public void Introduce()
        {
            Console.WriteLine("I am a {0} My perimeter is {1:f2}. My surface is {2:f2}.",
                              this.Type,
                              this.CalcPerimeter(),
                              this.CalcSurface());
        } 
    }
}
