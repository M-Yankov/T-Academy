namespace Labyrint
{
    using System.IO;
    using System.Text;

    public class PathSolver
    {
        private readonly StreamWriter writer = new StreamWriter("..\\..\\steps.txt", false, Encoding.Unicode, 2048);

        public void CompleteTask()
        {
            this.writer.AutoFlush = true;
            Matrix exampleMatrix = new Matrix();
            this.TraversePath(exampleMatrix, 1);
            this.ReplaceNonVisitedCells(exampleMatrix);
            System.Console.WriteLine(exampleMatrix.ToString());
            this.writer.WriteLine(exampleMatrix.ToString());
        }

        private void TraversePath(Matrix matrix, int counter)
        {
            int row = matrix.StartRow;
            int col = matrix.StartCol;

            //// System.Console.WriteLine(matrix.ToString());
            this.writer.WriteLine(matrix.ToString());

            //// up
            if (row - 1 >= 0 && !"x*".Contains(matrix.Content[row - 1, col]))
            {
                if (matrix.Content[row - 1, col] == "0" || int.Parse(matrix.Content[row - 1, col]) > counter)
                {
                    matrix.Content[row - 1, col] = counter.ToString();
                    matrix.StartRow = row - 1;
                    this.TraversePath(matrix, counter + 1);
                    matrix.StartRow = row;
                }
            }

            //// left 
            if (col - 1 >= 0 && !"x*".Contains(matrix.Content[row, col - 1]))
            {
                if (matrix.Content[row, col - 1] == "0" || int.Parse(matrix.Content[row, col - 1]) > counter)
                {
                    matrix.Content[row, col - 1] = counter.ToString();
                    matrix.StartCol = col - 1;
                    this.TraversePath(matrix, counter + 1);
                    matrix.StartCol = col;
                }
            }

            //// right
            if (col + 1 < matrix.Content.GetLength(0) && !"x*".Contains(matrix.Content[row, col + 1]))
            {
                if (matrix.Content[row, col + 1] == "0" || int.Parse(matrix.Content[row, col + 1]) > counter)
                {
                    matrix.Content[row, col + 1] = counter.ToString();
                    matrix.StartCol = col + 1;
                    this.TraversePath(matrix, counter + 1);
                    matrix.StartCol = col;
                }
            }

            //// down
            if (row + 1 < matrix.Content.GetLength(1) && !"x*".Contains(matrix.Content[row + 1, col]))
            {
                if (matrix.Content[row + 1, col] == "0" || int.Parse(matrix.Content[row + 1, col]) > counter)
                {
                    matrix.Content[row + 1, col] = counter.ToString();
                    matrix.StartRow = row + 1;
                    this.TraversePath(matrix, counter + 1);
                    matrix.StartRow = row;
                }
            }
        }

        private void ReplaceNonVisitedCells(Matrix matrix)
        {
            for (int i = 0; i < matrix.Content.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.Content.GetLength(1); k++)
                {
                    if (matrix.Content[i, k] == "0")
                    {
                        matrix.Content[i, k] = "u";
                    }
                }
            }
        }
    }
}