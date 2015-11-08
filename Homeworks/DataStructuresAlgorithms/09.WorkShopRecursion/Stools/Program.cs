namespace Stools
{
    using System;

    class Stool
    {
        public Stool(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    class Program
    {
        static Stool[] stools;
        static int N;
        static int[, ,] memo;

        static int Recourseint(int used, int top, int side)
        {
            if (memo[used, top, side] != 0)
            {
                return memo[used, top, side];
            }

            if (used == (1 << top))
            {
                if (side == 0)
                {
                    return stools[top].X;
                }

                if (side == 1)
                {
                    return stools[top].Y;
                }

                return stools[top].Z;
            }

            int fromStoolMask = used ^ (1 << top);

            int sideX = (side == 0) ? stools[top].Y : stools[top].X;
            int sideY = (side == 2) ? stools[top].Y : stools[top].Z;
            int sideH = stools[top].X + stools[top].Y + stools[top].Z - sideX - sideY;

            int result = sideH;

            for (int i = 0; i < N; i++)
            {
                if (((fromStoolMask >> i) & 1) == 1)
                {
                    if ((stools[i].Y >= sideX && stools[i].Z >= sideY) || (stools[i].Y >= sideY && stools[i].Z >= sideX))
                    {
                        result = Math.Max(result, Recourseint(fromStoolMask, i, 0) + sideH);
                    }

                    if (stools[i].X == stools[i].Y && stools[i].X == stools[i].Z)
                    {
                        continue;
                    }

                    if ((stools[i].X >= sideX && stools[i].Z >= sideY) || (stools[i].X >= sideY && stools[i].Z >= sideX))
                    {
                        result = Math.Max(result, Recourseint(fromStoolMask, i, 1) + sideH);
                    }

                    if ((stools[i].X >= sideX && stools[i].Y >= sideY) || (stools[i].X >= sideY && stools[i].Y >= sideX))
                    {
                        result = Math.Max(result, Recourseint(fromStoolMask, i, 2) + sideH);
                    }
                }
            }

            memo[used, top, side] = result;
            return result;
        }

        static void Main()
        {
            N = int.Parse(Console.ReadLine());
            stools = new Stool[N];
            memo = new int[1 << N, N, 3];

            for (int i = 0; i < N; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                stools[i] = new Stool(
                    int.Parse(line[0]),
                    int.Parse(line[1]),
                    int.Parse(line[2]));
            }

            int result = 0;
            for (int i = 0; i < N; i++)
            {
                result = Math.Max(result, Recourseint((1 << N) - 1, i, 0));
                result = Math.Max(result, Recourseint((1 << N) - 1, i, 1));
                result = Math.Max(result, Recourseint((1 << N) - 1, i, 2));
            }

            Console.WriteLine(result);
        }
    }
}
