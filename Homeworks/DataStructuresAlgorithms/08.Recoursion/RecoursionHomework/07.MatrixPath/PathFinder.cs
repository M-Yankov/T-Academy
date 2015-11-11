namespace MatrixPath
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Task 7. e are given a matrix of passable and non-passable cells. 
    ///     ○ Write a recursive program for finding all paths between two cells in the matrix.
    /// </summary>
    public class PathFinder
    {
        private static char[,] matrix;
        private static char passedCell = '∙';

        private static void Main()
        {
            matrix = new char[10, 10] 
            {
                { ' ', '■', ' ', ' ', '■', '■', ' ', ' ', '■', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { '■', ' ', '■', '■', ' ', ' ', '■', ' ', ' ', ' ' },
                { '■', ' ', ' ', ' ', '■', ' ', ' ', '■', '■', ' ' },
                { ' ', ' ', ' ', '■', ' ', ' ', '■', ' ', ' ', ' ' },
                { ' ', '■', ' ', '■', '■', '■', ' ', ' ', '■', '■' },
                { ' ', ' ', ' ', ' ', ' ', '■', ' ', ' ', '■', ' ' },
                { '■', ' ', '■', ' ', ' ', ' ', '■', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ', '■', ' ', '■', ' ', '■', ' ' },
                { ' ', '■', '■', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
            };

            FintPathTo(6, 9);
        }

        private static void FintPathTo(int row, int col, int startRow = 0, int startCol = 0)
        {
            if (startRow == row && startCol == col)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = '√';
                PrintPath(matrix);
                matrix[startRow, startCol] = oldValue;
                return;
            }

            //// Up
            if (startRow - 1 >= 0 && matrix[startRow - 1, startCol] == ' ')
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FintPathTo(row, col, startRow - 1, startCol);
                matrix[startRow, startCol] = oldValue;
            }

            //// Right
            if (startCol + 1 < matrix.GetLength(1) && matrix[startRow, startCol + 1] == ' ')
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FintPathTo(row, col, startRow, startCol + 1);
                matrix[startRow, startCol] = oldValue;
            }

            //// Down
            if (startRow + 1 < matrix.GetLength(0) && matrix[startRow + 1, startCol] == ' ')
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FintPathTo(row, col, startRow + 1, startCol);
                matrix[startRow, startCol] = oldValue;
            }

            //// Left
            if (startCol - 1 >= 0 && matrix[startRow, startCol - 1] == ' ')
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FintPathTo(row, col, startRow, startCol - 1);
                matrix[startRow, startCol] = oldValue;
            }
        }

        private static void PrintPath(char[,] matrix)
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

            Console.Write(result.ToString() + "\n");
        }
    }
}
