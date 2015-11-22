
namespace DogeTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static char[,] matrix;
        private static int paths = 0;
        private static char passedCell = 'X';

        public static void Main()
        {
            Console.WriteLine("()({0})", '\0');

            int[] matrixDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            matrix = new char[matrixDimensions[0], matrixDimensions[1]];

           /* for (int i = 0; i < matrixDimensions[0]; i++)
            {
                for (int k = 0; k < matrixDimensions[1]; k++)
                {
                    matrix[i, k] = ' ';
                }
            }*/

            int[] foodCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int dogeEnemies = int.Parse(Console.ReadLine());

            for (int i = 0; i < dogeEnemies; i++)
            {
                int[] enemyCoords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[enemyCoords[0], enemyCoords[1]] = 'E';
            }

            TraverseMatrix(foodCoordinates[0], foodCoordinates[1]);
            Console.WriteLine(paths);
        }

        private static void TraverseMatrix( int targetRow, int targetCol, int row = 0, int col = 0)
        {
            if (row == targetRow && col == targetCol)
            {
                paths++;
                return;
            }

            //// PrintMatrix(matrix); 

            //// Right
            if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == '\0')
            {
                char oldValue = matrix[row, col];
                matrix[row, col] = passedCell;
                TraverseMatrix(targetRow, targetCol, row, col + 1);
                matrix[row, col] = oldValue;
            }

            //// Down
            if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == '\0')
            {
                char oldValue = matrix[row, col];
                matrix[row, col] = passedCell;
                TraverseMatrix(targetRow, targetCol, row + 1, col);
                matrix[row, col] = oldValue;
            }
        }

        private static void PrintMatrix(char[,] matrix)
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
