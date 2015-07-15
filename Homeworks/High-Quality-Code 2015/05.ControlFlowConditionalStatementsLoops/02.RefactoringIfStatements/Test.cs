namespace RefactoringIfStatements
{
    using System;

    public class Test
    {
        

        static void Main()
        {
            // Part 1
            Potato potato = new Potato();
            bool isReadyForCook = potato != null && potato.HasBeenPeeled && !potato.IsRotten;

            if (isReadyForCook)
            {
                Cook(potato);
            }

            // Part 2 Vised Cell
            Random generator = new Random();

            int MAX_X = generator.Next(0, 100);
            int MIN_X = MAX_X - 50;
            int MAX_Y = generator.Next(0, 100);
            int MIN_Y = MAX_Y - 50;
            int x = generator.Next(0, 100);
            int y = generator.Next(0, 100);

            bool shouldVisitCell = true;
            bool hasCorrectVerticalValue = (MIN_Y <= y && y <= MAX_Y);
            bool hasCorrectHorizontalValue = (MIN_X <= x && x <= MAX_X);
            bool hasPermisionToVisitCell = hasCorrectVerticalValue && hasCorrectHorizontalValue && shouldVisitCell;

            if (hasPermisionToVisitCell)
            {
                VisitCell();
            }
        }

        static void Cook(Potato potato)
        {
            //..
        }

        static void VisitCell()
        {
            //..
        }
    }

    internal class Potato
    {
        public Potato()
        {

        }

        public bool HasBeenPeeled { get; set; }

        public bool IsRotten { get; set; }

    }
}
