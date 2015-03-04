using System;
using System.Text;


class Program
{
    static bool[,] field;
    static string ConvertCommand(string s)
    {
        StringBuilder result = new StringBuilder();
        s = s.Replace("M", " M ");
        s = s.Replace("L", " L ");
        s = s.Replace("R", " R ");

        string[] separated = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string lastNumber = null;

        for (int i = 0; i < separated.Length; i++)
        {
            if (separated[i] == "L" || separated[i] == "R")
            {
                result.Append(separated[i]);
            }
            else if (separated[i] == "M")
            {
                if (lastNumber == null)
                {
                    result.Append("M");
                }
                else
                {
                    int number = int.Parse(lastNumber);
                    result.Append('M', number);
                    lastNumber = null;
                }
            }
            else
            {
                lastNumber = separated[i];
            }
        }
        result.Replace("LM", "L");
        result.Replace("RM", "R");
        return result.ToString();
    }
    static void Main()
    {
        string[] xyz = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        int x = int.Parse(xyz[0]);
        int y = int.Parse(xyz[1]);
        int z = int.Parse(xyz[2]);
        string redPlayer = ConvertCommand(Console.ReadLine());
        string bluePlayer = ConvertCommand(Console.ReadLine());
        field = new bool[y + 1, 2 * (x + z)];

        int redRow = y / 2;
        int redCol = z + x / 2;
        string redDirection = "right";

        int blueRow = y / 2;
        int blueCol = 2 * z + x + x / 2;
        string blueDirection = "left";

        bool redDies = false;
        bool blueDies = false;


        field[redRow, redCol] = true;
        field[blueRow, blueCol] = true;

        for (int i = 0; i < redPlayer.Length; i++)
        {
            //red 
            char currentRedCommand = redPlayer[i];
            if (currentRedCommand == 'R' || currentRedCommand == 'L')
            {
                redDirection = ChangeDirection(redDirection, currentRedCommand);
            }

            Move(ref redRow, ref redCol, redDirection);

            // check forbvidden walls
            if (redRow < 0)
            {

                redRow = 0;
                redDies = true;
            }
            if (redRow == field.GetLength(0))
            {
                redRow = field.GetLength(0) - 1;
                redDies = true;
            }



            //Chekc for dies for red player

            if (field[redRow, redCol])
            {
                redDies = true;
            }


            //blue
            char currentBlueCommand = bluePlayer[i];
            if (currentBlueCommand == 'R' || currentBlueCommand == 'L')
            {
                blueDirection = ChangeDirection(blueDirection, currentBlueCommand);
            }

            Move(ref blueRow, ref blueCol, blueDirection);

            if (blueRow < 0)
            {
                blueRow = 0;
                blueDies = true;
            }
            if (blueRow == field.GetLength(0))
            {
                blueRow = field.GetLength(0) - 1;
                blueDies = true;
            }
            if (field[blueRow, blueCol])
            {
                blueDies = true;
            }

            //Check crash toghether
            if (redRow == blueRow && redCol == blueCol)
            {
                redDies = true;
                blueDies = true;
            }

            if (redDies && !blueDies)
            {
                Console.WriteLine("BLUE");
                break;
            }
            if (!redDies && blueDies)
            {
                Console.WriteLine("RED");
                break;
            }
            if (redDies && blueDies)
            {
                Console.WriteLine("DRAW");
                break;
            }


            field[redRow, redCol] = true;
            field[blueRow, blueCol] = true;
        }
        int distanceRow = Math.Abs(redRow - (y / 2));
        int distanceCol = Math.Abs(redCol - (z + x / 2));
        if (distanceCol > field.GetLength(1) / 2)
        {
            distanceCol = field.GetLength(1) - distanceCol;
        }
        Console.WriteLine(distanceCol + distanceRow);
    }

    static void Move(ref int row, ref int col, string direction)
    {
        switch (direction)
        {
            case "up": row--; break;
            case "down": row++; break;
            case "left": col--; break;
            case "right": col++; break;
            default:
                throw new ArgumentException("direction", "invalid direction");
        }
        if (col < 0)
        {
            col = field.GetLength(1) - 1;
        }
        if (col == field.GetLength(1))
        {
            col = 0;
        }
    }


    static string ChangeDirection(string direction, char command)
    {
        switch (direction)
        {
            case "up":
                if (command == 'L')
                {
                    return "left";
                }
                if (command == 'R')
                {
                    return "right";
                }
                break;
            case "down":
                if (command == 'L')
                {
                    return "right";
                }
                if (command == 'R')
                {
                    return "left";
                }
                break;
            case "left":
                if (command == 'L')
                {
                    return "down";
                }
                if (command == 'R')
                {
                    return "up";
                }
                break;
            case "right":
                if (command == 'L')
                {
                    return "up";
                }
                if (command == 'R')
                {
                    return "down";
                }
                break;



            default:
                throw new ArgumentException("direction ", "Direction is not valid");
        }
        throw new ArgumentException("direction ", "Direction is not valid");

    }
}
