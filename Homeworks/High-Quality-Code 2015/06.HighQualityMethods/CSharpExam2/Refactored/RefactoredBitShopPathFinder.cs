namespace CSharpExam2.Refactored
{
    using System;
    using System.Linq;

    // This task is also knows as "Lover of 3";
    public class RefactoredBitShopPathFinder
    {
        internal static void Main()
        {
            int[] sizesOfNewArray = new int[1];
            string inputFromConsole = Console.ReadLine();

            sizesOfNewArray = inputFromConsole.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            long[,] bitshop = new long[sizesOfNewArray[0], sizesOfNewArray[1]];
            bool[,] passed = new bool[sizesOfNewArray[0], sizesOfNewArray[1]];

            for (int row = 0, i = bitshop.GetLength(0) - 1; row < bitshop.GetLength(0); row++, i--)
            {
                int numberForBoard = i * 3;

                for (int col = 0; col < bitshop.GetLength(1); col++)
                {
                    bitshop[row, col] = numberForBoard;
                    numberForBoard += 3;
                }
            }

            int moves = int.Parse(Console.ReadLine());

            string commandLine;
            string command;
            int times;

            long sum = 0;
            int bitshopRow = bitshop.GetLength(0) - 1;
            int bitshopCol = 0;

            for (int i = 0; i < moves; i++)
            {
                commandLine = Console.ReadLine();
                command = commandLine.Substring(0, 2);
                times = int.Parse(commandLine.Substring(3));

                if (command == "RD" || command == "DR")
                {
                    MoveRightDOWN(bitshop, ref bitshopRow, ref bitshopCol, passed, ref times, ref sum);
                }
                else if (command == "RU" || command == "UR")
                {
                    MoveRightUP(bitshop, ref bitshopRow, ref bitshopCol, passed, ref times, ref sum);
                }
                else if (command == "LD" || command == "DL")
                {
                    MoveLeftDOWN(bitshop, ref bitshopRow, ref bitshopCol, passed, ref times, ref sum);
                }
                else if (command == "LU" || command == "UL")
                {
                    MoveLeftUP(bitshop, ref bitshopRow, ref bitshopCol, passed, ref times, ref sum);
                }
            }

            Console.WriteLine(sum);
        }

        private static void MoveRightUP(long[,] bitshop, ref int brow, ref int bcol, bool[,] passed, ref int times, ref long sum)
        {
            for (int i = 0; i < times; i++)
            {
                if (passed[brow, bcol] == false)
                {
                    sum += bitshop[brow, bcol];
                    passed[brow, bcol] = true;
                }

                if (brow - 1 < 0 || bcol + 1 > bitshop.GetLength(1) - 1)
                {
                    break;
                }
                else
                {
                    if (i == times - 1)
                    {
                        break;
                    }
                    else
                    {
                        brow = brow - 1;
                        bcol = bcol + 1;
                    }
                }
            }
        }

        private static void MoveRightDOWN(long[,] bitshop, ref int row, ref int col, bool[,] passed, ref int times, ref long sum)
        {
            for (int i = 0; i < times; i++)
            {
                if (passed[row, col] == false)
                {
                    sum += bitshop[row, col];
                    passed[row, col] = true;
                }

                if (row + 1 > bitshop.GetLength(0) - 1 || col + 1 > bitshop.GetLength(1) - 1)
                {
                    break;
                }
                else
                {
                    if (i == times - 1)
                    {
                        break;
                    }
                    else
                    {
                        row += 1;
                        col += 1;
                    }
                }
            }
        }

        private static void MoveLeftUP(long[,] bitshop, ref int row, ref int col, bool[,] passed, ref int times, ref long sum)
        {
            for (int i = 0; i < times; i++)
            {
                if (passed[row, col] == false)
                {
                    sum += bitshop[row, col];
                    passed[row, col] = true;
                }

                if (row - 1 < 0 || col - 1 < 0)
                {
                    break;
                }
                else
                {
                    if (i == times - 1)
                    {
                        break;
                    }
                    else
                    {
                        row--;
                        col--;
                    }
                }
            }
        }

        private static void MoveLeftDOWN(long[,] bitshop, ref int row, ref int col, bool[,] passed, ref int times, ref long sum)
        {
            for (int i = 0; i < times; i++)
            {
                if (passed[row, col] == false)
                {
                    sum += bitshop[row, col];
                    passed[row, col] = true;
                }

                if (row + 1 > bitshop.GetLength(0) - 1 || col - 1 < 0)
                {
                    break;
                }
                else
                {
                    if (i == times - 1)
                    {
                        break;
                    }
                    else
                    {
                        row++;
                        col--;
                    }
                }
            }
        }
    }
}
