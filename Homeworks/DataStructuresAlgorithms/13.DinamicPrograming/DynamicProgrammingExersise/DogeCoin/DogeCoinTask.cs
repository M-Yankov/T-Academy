namespace DogeCoin
{
    using System;
    using System.Linq;

    public class DogeCoinTask
    {
        private static int[,] matrix;

        public static void Main()
        {
            var matrixDimesion = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            matrix = new int[matrixDimesion[0], matrixDimesion[1]];

            int numberOfCoins = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCoins; i++)
            {
                var coinCoords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[coinCoords[0], coinCoords[1]]++;
            }

            for (int row = 0; row < matrixDimesion[0]; row++)
            {
                for (int col = 0; col < matrixDimesion[1]; col++)
                {
                    int sum = 0;
                    if (row - 1 < 0 && col - 1 < 0)
                    {
                        continue;
                    }
                    else if (row - 1 < 0)
                    {
                        matrix[row, col] += matrix[row, col - 1];
                    }
                    else if (col - 1 < 0)
                    {
                        matrix[row, col] += matrix[row - 1, col];
                    }
                    else
                    {
                        matrix[row, col] += matrix[row - 1, col] > matrix[row, col - 1] ? matrix[row - 1, col] : matrix[row, col - 1];
                    }
                }
            }

            Console.WriteLine(matrix[matrixDimesion[0] - 1, matrixDimesion[1] - 1]);
        }
    }
}
