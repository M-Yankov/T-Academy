namespace OneHundredMatrix
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Task 8. Modify the above program to check whether a path exists between two cells without finding all possible paths. 
    ///     ○ Test it over an empty 100 x 100 matrix.
    /// </summary>
    public class StartUp
    {
        private static char[,] matrix;
        private static char passedCell = '∙';
        private static bool isFound = false;

        private static void Main()
        {
            matrix = new char[10, 10] 
            {
                { ' ', '■', ' ', ' ', '■', '■', ' ', ' ', '■', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { '■', ' ', '■', '■', ' ', ' ', '■', ' ', ' ', ' ' },
                { '■', ' ', ' ', ' ', '■', ' ', ' ', '■', '■', ' ' },
                { ' ', ' ', ' ', '■', ' ', ' ', '■', ' ', ' ', ' ' },
                { ' ', '■', ' ', ' ', '■', '■', ' ', ' ', '■', '■' },
                { ' ', ' ', ' ', ' ', ' ', '■', ' ', ' ', '■', ' ' },
                { '■', ' ', '■', ' ', ' ', ' ', '■', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ', '■', ' ', '■', ' ', '■', ' ' },
                { ' ', '■', '■', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
            };

            FintPathTo(6, 9);

            matrix = new char[100, 100];
            isFound = false;
            for (int row = 0; row < 100; row++)
            {
                for (int col = 0; col < 100; col++)
                {
                    matrix[row, col] = ' ';
                }
            }

            FintPathTo(99, 99, printInTextFile: true);
            Console.WriteLine("See results with notepad++ (small font or zoom out) ..\\..\\result.txt");
        }

        private static void FintPathTo(int row, int col, int startRow = 0, int startCol = 0, bool printInTextFile = false)
        {
            if (startRow == row && startCol == col)
            {
                isFound = true;
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = '√';
                PrintPath(matrix, printInTextFile);
                matrix[startRow, startCol] = oldValue;
                return;
            }

            //// Up
            if (startRow - 1 >= 0 && matrix[startRow - 1, startCol] == ' ' && !isFound)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FintPathTo(row, col, startRow - 1, startCol, printInTextFile);
                matrix[startRow, startCol] = oldValue;
            }

            //// Right
            if (startCol + 1 < matrix.GetLength(1) && matrix[startRow, startCol + 1] == ' ' && !isFound)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FintPathTo(row, col, startRow, startCol + 1, printInTextFile);
                matrix[startRow, startCol] = oldValue;
            }

            //// Down
            if (startRow + 1 < matrix.GetLength(0) && matrix[startRow + 1, startCol] == ' ' && !isFound)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FintPathTo(row, col, startRow + 1, startCol, printInTextFile);
                matrix[startRow, startCol] = oldValue;
            }

            //// Left
            if (startCol - 1 >= 0 && matrix[startRow, startCol - 1] == ' ' && !isFound)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FintPathTo(row, col, startRow, startCol - 1, printInTextFile);
                matrix[startRow, startCol] = oldValue;
            }
        }

        private static void PrintPath(char[,] matrix, bool useStreaWriter)
        {
            StringBuilder result = new StringBuilder();
            List<char> chars;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                chars = new List<char>();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    chars.Add(matrix[row, col]);
                }

                string rowChars = string.Format("│{0}│", string.Join("│", chars));
                result.AppendLine(rowChars);
            }

            if (useStreaWriter)
            {
                using (StreamWriter writer = new StreamWriter("..\\..\\results.txt"))
                {
                    writer.Write(result.ToString());
                }
            }
            else
            {
                Console.Write(result.ToString() + "\n");
            }
        }
    }
}
