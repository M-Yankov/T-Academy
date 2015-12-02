
namespace DogeTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Numerics;

    public class DogeHelp
    {
        private static BigInteger[,] matrix;
        private static readonly long Enemy = -1;

        public static void Main()
        {
            int[] matrixDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            matrix = new BigInteger[matrixDimensions[0], matrixDimensions[1]];
            
            int[] foodCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int dogeEnemies = int.Parse(Console.ReadLine());

            for (int i = 0; i < dogeEnemies; i++)
            {
                int[] enemyCoords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[enemyCoords[0], enemyCoords[1]] = Enemy;
            }

            BigInteger answer = DinamicSolution(foodCoordinates);

            Console.WriteLine(answer);
        }

        private static BigInteger DinamicSolution(int[] foodCoordinates)
        {
            int matrixRows = matrix.GetLength(0);
            int matrixCols = matrix.GetLength(1);

            matrix[0, 0] = 1;

            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixCols; col++)
                {
                    if (row + col == 0)
                    {
                        continue;
                    }

                    if (matrix[row, col] != Enemy)
                    {
                        BigInteger sum = 0;

                        if (row - 1 >= 0 && matrix[row - 1, col] != Enemy)
                        {
                            sum += matrix[row - 1, col];
                        }

                        if (col - 1 >= 0 && matrix[row, col - 1] != Enemy)
                        {
                            sum += matrix[row, col - 1];
                        }

                        matrix[row, col] = sum;

                        if (row == foodCoordinates[0] && col == foodCoordinates[1])
                        {
                            return matrix[row, col];
                        }
                    }
                }
            }

            return matrix[foodCoordinates[0], foodCoordinates[1]];
        }

        private static void PrintMatrix(BigInteger[,] matrix)
        {
            StringBuilder result = new StringBuilder();
            List<BigInteger> chars;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                chars = new List<BigInteger>();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    chars.Add(matrix[row, col]);
                }

                string rowChars = string.Format("│{0,2}│", string.Join("│", chars));
                result.AppendLine(rowChars);
            }

            Console.Write(result.ToString() + "\n");
        }
    }
}
