 namespace FibonacciTask
{
    using System;

    public class Matrix
    {
        private const int MOD = 1000000007;

        public long[,] InnerMatrix { get; set; }

        public Matrix(long a, long b, long c, long d)
        {
            this.InnerMatrix = new long[2, 2];

            this.InnerMatrix[0, 0] = a;
            this.InnerMatrix[0, 1] = b;
            this.InnerMatrix[1, 0] = c;
            this.InnerMatrix[1, 1] = d;
        }

        public Matrix(Matrix first, Matrix second)
        {
            this.InnerMatrix = new long[2, 2];

            this.InnerMatrix[0, 0] = first.InnerMatrix[0, 0] * second.InnerMatrix[0, 0]
                                   + first.InnerMatrix[0, 1] * second.InnerMatrix[1, 0];

            this.InnerMatrix[0, 1] = first.InnerMatrix[0, 0] * second.InnerMatrix[0, 1]
                                   + first.InnerMatrix[0, 1] * second.InnerMatrix[1, 1];

            this.InnerMatrix[1, 0] = first.InnerMatrix[1, 0] * second.InnerMatrix[0, 0]
                                   + first.InnerMatrix[1, 1] * second.InnerMatrix[1, 0];

            this.InnerMatrix[1, 1] = first.InnerMatrix[1, 0] * second.InnerMatrix[0, 1]
                                   + first.InnerMatrix[1, 1] * second.InnerMatrix[1, 1];

            this.InnerMatrix[0, 0] %= MOD;
            this.InnerMatrix[0, 1] %= MOD;
            this.InnerMatrix[1, 0] %= MOD;
            this.InnerMatrix[1, 1] %= MOD;
        }
    }

    class Program
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            Matrix result = PowOf(new Matrix(1, 1, 1, 0), number);
            Console.WriteLine(result.InnerMatrix[1, 0]);
        }

        static Matrix PowOf(Matrix a, long pow)
        {
            if (pow == 1)
            {
                return a;
            }

            if (pow % 2 == 1)
            {
                return new Matrix(PowOf(a, pow - 1), a);
            }

            a = PowOf(a, pow / 2);
            return new Matrix(a, a);
        }
    }
}
