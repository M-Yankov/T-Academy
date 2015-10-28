namespace Labyrint
{
    using System.Linq;
    using System.Text;

    public class Matrix
    {
        private string[,] matrix;

        public Matrix()
        {
            this.StartRow = 2;
            this.StartCol = 1;

            this.matrix = new[,]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" }
            };
        }

        public string[,] Content
        {
            get
            {
                return this.matrix;
            } 
        }

        public int StartRow { get; set; }

        public int StartCol { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int k = 0; k < this.matrix.GetLength(1); k++)
                {
                    if (k == this.matrix.GetLength(1))
                    {
                        result.Append(this.matrix[i, k]);
                    }

                    result.Append(this.matrix[i, k] + ", ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}