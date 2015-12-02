namespace DataStructuresAlgoritms
{
    using System;
    using System.IO;
    using System.Linq;

    public class Portals
    {
        private static int X;
        private static int Y;
        private static string[,] labirynth;
        private static bool[,] visited;

        private static long sum = 0;
        private static string fog = "#";
        private static long answer = long.MinValue;

        private static int rows;
        private static int cols;

        private static string GetInput()
        {
            return @"0 0
5 6
1 # 5 4 6 4
3 2 # 2 6 2
9 1 7 6 3 1 
8 2 7 3 8 6
3 6 1 3 1 2";
        }

        public static void Main()
        {
            Console.SetIn(new StringReader(GetInput()));

            int[] startCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            X = startCoordinates[0];
            Y = startCoordinates[1];

            int[] dimesions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            rows = dimesions[0];
            cols = dimesions[1];

            labirynth = new string[rows, cols];
            visited = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine().Split(' ').ToArray();
                for (int a = 0; a < cols; a++)
                {
                    labirynth[i, a] = line[a];
                }
            }

            RecursiveSearchMaxValue(X, Y);

            Console.WriteLine(answer);
        }

        private static void RecursiveSearchMaxValue(int startRowIndex, int startColIndex)
        {
            int currentValue = int.Parse(labirynth[startRowIndex, startColIndex]);

            //// up
            if (startRowIndex - currentValue >= 0 && labirynth[startRowIndex - currentValue, startColIndex] != fog)
            {
                sum += currentValue;
                if (sum > answer)
                {
                    answer = sum;
                }

                if (!visited[startRowIndex - currentValue, startColIndex])
                {
                    visited[startRowIndex, startColIndex] = true;
                    RecursiveSearchMaxValue(startRowIndex - currentValue, startColIndex);
                    visited[startRowIndex, startColIndex] = false;
                }

                sum -= currentValue;
            }

            //// right
            if (startColIndex + currentValue < cols && labirynth[startRowIndex, startColIndex + currentValue] != fog)
            {
                sum += currentValue;
                if (sum > answer)
                {
                    answer = sum;
                }

                if (!visited[startRowIndex, startColIndex + currentValue])
                {
                    visited[startRowIndex, startColIndex] = true;
                    RecursiveSearchMaxValue(startRowIndex, startColIndex + currentValue);
                    visited[startRowIndex, startColIndex] = false;
                }

                sum -= currentValue;
            }

            //// down
            if (startRowIndex + currentValue < rows && labirynth[startRowIndex + currentValue, startColIndex] != fog)
            {
                sum += currentValue;
                if (sum > answer)
                {
                    answer = sum;
                }

                if (!visited[startRowIndex + currentValue, startColIndex])
                {
                    visited[startRowIndex, startColIndex] = true;
                    RecursiveSearchMaxValue(startRowIndex + currentValue, startColIndex);
                    visited[startRowIndex, startColIndex] = false;
                }

                sum -= currentValue;
            }

            //// left
            if (startColIndex - currentValue >= 0 && labirynth[startRowIndex, startColIndex - currentValue] != fog)
            {
                sum += currentValue;
                if (sum > answer)
                {
                    answer = sum;
                }

                if (!visited[startRowIndex, startColIndex - currentValue])
                {
                    visited[startRowIndex, startColIndex] = true;
                    RecursiveSearchMaxValue(startRowIndex, startColIndex - currentValue);
                    visited[startRowIndex, startColIndex] = false;
                }

                sum -= currentValue;
            }


            //sum -= currentValue;
            //if (!isPassedInRecuriosn)
            //{
            //}
        }
    }
}
