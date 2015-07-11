namespace ClassSizeInCSharp
{
    using System;

    internal class Figure
    {
        private double width, height;
        internal Figure(double widthOfFigure, double heightOfFigure)
        {
            this.Width = widthOfFigure;
            this.Height = heightOfFigure;
        }

        public double Width 
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public double Height 
        {
            get { return this.height; }
            set { this.height = value; } 
        }

        internal static Figure GetRotatedFigure(Figure figure, double angleOfTheFigureThatWillBeRotaed)
        {
            double cosinusOfAngle;
            double absoluteCosinus;
            double sinusOfAngle;
            double absoluteSinus;

            cosinusOfAngle  = Math.Cos(angleOfTheFigureThatWillBeRotaed);
            absoluteCosinus = Math.Abs(cosinusOfAngle);
            absoluteCosinus *= figure.Width;

            sinusOfAngle = Math.Sin(angleOfTheFigureThatWillBeRotaed);
            absoluteSinus = Math.Abs(sinusOfAngle);
            absoluteSinus *= figure.Height;

            double widthOfTheNewFigure = absoluteCosinus + absoluteSinus;

            cosinusOfAngle = Math.Cos(angleOfTheFigureThatWillBeRotaed);
            absoluteCosinus = Math.Abs(cosinusOfAngle);
            absoluteCosinus *= figure.Height;

            sinusOfAngle = Math.Sin(angleOfTheFigureThatWillBeRotaed);
            absoluteSinus = Math.Abs(sinusOfAngle);
            absoluteSinus *= figure.Width;

            double heightOfTheNewFigure = absoluteCosinus + absoluteSinus;

            Figure newFigure = new Figure(widthOfTheNewFigure, heightOfTheNewFigure);
            return newFigure;
        }
    }
}
