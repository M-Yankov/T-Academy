using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class OLDMathProblem
{
    static void MoveRightUP(long[,] bitshop, ref int brow, ref int bcol, bool[,] passed, ref int times, ref long sum)
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
    static void MoveRightDOWN(long[,] bitshop, ref int row, ref int col, bool[,] passed, ref int times, ref long sum)
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

        //row = row;
        //col = col;
    }
    static void MoveLeftUP(long[,] bitshop, ref int row, ref int col, bool[,] passed, ref int times, ref long sum)
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
    static void MoveLeftDOWN(long[,] bitshop, ref int row, ref int col, bool[,] passed, ref int times, ref long sum)
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
    static void OLDMMMain()
    {
        int[] myArray = new int[1];
        string input = Console.ReadLine();
        myArray = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

        long[,] bitshop = new long[myArray[0], myArray[1]]; // redove coloni ???
        bool[,] passed = new bool[myArray[0], myArray[1]];

        for (int row = 0, i = bitshop.GetLength(0) - 1; row < bitshop.GetLength(0); row++, i--)
        {
            int temp = i * 3;
            for (int col = 0; col < bitshop.GetLength(1); col++)
            {
                bitshop[row, col] = temp;
                //Console.Write("{0,3}", bitshop[row, col]);
                temp += 3;
            }
            //Console.WriteLine();
        }

        int num = int.Parse(Console.ReadLine());
        string tempSTRING;
        string command;
        int times;


        long sum = 0;
        int brow = bitshop.GetLength(0) - 1;
        int bcol = 0;

        for (int i = 0; i < num; i++)
        {
            tempSTRING = Console.ReadLine();
            command = tempSTRING.Substring(0, 2);
            times = int.Parse(tempSTRING.Substring(3));

            if (command == "RD" || command == "DR") //right down
            {
                MoveRightDOWN(bitshop, ref brow, ref bcol, passed, ref times, ref sum);
            }
            else if (command == "RU" || command == "UR") // right up
            {
                MoveRightUP(bitshop, ref  brow, ref bcol, passed, ref times, ref sum);
            }
            else if (command == "LD" || command == "DL") // left down
            {
                MoveLeftDOWN(bitshop, ref  brow, ref bcol, passed, ref times, ref sum);
            }
            else if (command == "LU" || command == "UL") // left up
            {
                MoveLeftUP(bitshop, ref  brow, ref bcol, passed, ref times, ref sum);
            }
        }
        Console.WriteLine(sum);

    }
}