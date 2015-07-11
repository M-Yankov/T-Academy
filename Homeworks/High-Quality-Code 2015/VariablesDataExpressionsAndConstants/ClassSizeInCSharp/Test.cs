namespace ClassSizeInCSharp
{
    using System;

    class Test
    {
        // this class is not included in homework. I just put it for test purposes.
        static void Main()
        {
            Figure square = new Figure(3.5, 3.5);
            Figure Idkwhatisthis = Figure.GetRotatedFigure(square, 90);
            Console.WriteLine(Idkwhatisthis.Width + " " + Idkwhatisthis.Height);
        }
    }
}
