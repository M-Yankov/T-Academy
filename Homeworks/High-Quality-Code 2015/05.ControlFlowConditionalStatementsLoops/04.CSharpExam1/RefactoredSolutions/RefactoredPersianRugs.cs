namespace CSharpExam1.RefactoredSolutions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class RefactoredPersianRugs
    {

        static void MustBeMainMethod()
        {
            int halfWitdh = int.Parse(Console.ReadLine());
            int diagonalSpace = int.Parse(Console.ReadLine());

            DrawRug(halfWitdh, diagonalSpace);
        }

        private static void DrawRug(int halfWidth, int space)
        {
            int height = (halfWidth - 1) - space;
            int lenghtForSpace = space;
            bool isWithoutTriangles = false;

            List<string> topHalf = new List<string>();
            List<string> bottomHalf = new List<string>();
            List<string> midleLine = new List<string>();

            midleLine.Add(new string('#', halfWidth) + "X" + new string('#', halfWidth));

            if (height < 0)
            {
                isWithoutTriangles = true;
                lenghtForSpace = (halfWidth * 2) - 1;
            }

            topHalf = MakeTopHalf(halfWidth, height, lenghtForSpace, isWithoutTriangles);
            

            for (int i = topHalf.Count - 1; i >= 0; i--)
            {
                string item = topHalf[i];
                item = ReplaceSlashes(item);
                bottomHalf.Add(item);
            }

            PrintCollection(topHalf);
            PrintCollection(midleLine);
            PrintCollection(bottomHalf);
        }

        private static List<string> MakeTopHalf(int halfWidth, int height, int lenghtOfSpaces, bool hasNotSmallTriangles)
        {
            List<string> collectedLinesOfTopHalf = new List<string>();

            for (int i = 0, diesChar = 0, dots = (height * 2) - 1; i < halfWidth; i++, diesChar++, dots -= 2)
            {
                string diesisSymbol = new string('#', diesChar);
                string whiteSpaces = new string(' ', lenghtOfSpaces);
                string points;

                if (i < height)
                {
                    points = new string('.', dots);
                    collectedLinesOfTopHalf.Add(diesisSymbol + "\\" + whiteSpaces + "\\" + points + "/" + whiteSpaces + "/" + diesisSymbol);
                }
                else
                {
                    string middleSpace;

                    if (hasNotSmallTriangles)
                    {
                        middleSpace = new string(' ', lenghtOfSpaces);
                        lenghtOfSpaces--;
                    }
                    else
                    {
                        middleSpace = new string(' ', (lenghtOfSpaces * 2) + 1);

                    }

                    collectedLinesOfTopHalf.Add(diesisSymbol + "\\" + middleSpace + "/" + diesisSymbol);
                    lenghtOfSpaces--;
                }

                if (lenghtOfSpaces < -1)
                {
                    break;
                }
            }

            return collectedLinesOfTopHalf;
        }

        private static string ReplaceSlashes(string text)
        {
            int midleLenght = text.Length / 2;
            string leftPart = text.Substring(0, midleLenght);
            string rightPart = text.Substring(midleLenght);

            leftPart = leftPart.Replace("\\", "/");
            rightPart = rightPart.Replace("/", "\\");

            return leftPart + rightPart;
        }

        private static void PrintCollection(List<string> strings)
        {
            foreach (string line in strings)
            {
                Console.WriteLine(line);
            }
        }
    }
}
