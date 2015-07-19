namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        private static void Main()
        {
            Circle circle = new Circle(5);
            Rectangle rectengle = new Rectangle(2, 3);

            circle.Introduce();
            rectengle.Introduce();
        }
    }
}