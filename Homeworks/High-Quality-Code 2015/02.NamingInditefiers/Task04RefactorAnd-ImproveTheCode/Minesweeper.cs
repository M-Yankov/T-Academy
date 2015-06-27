/*Task 4. Re-factor and improve the code

    Refactor and improve the naming in the C# source project Application1.sln.
    You are allowed to make other improvements in the code as well (not only naming) as well as to fix bugs.
*/
namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Mines
    {
        public class Point
        {
            string name;
            int points;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Points
            {
                get { return points; }
                set { points = value; }
            }

            public Point() 
            {
            }

            public Point(string name, int points)
            {
                this.name = name;
                this.points = points;
            }
        }

        static void Main(string[] arguments)
        {
            const int FIELDS_IN_PLAYGROUND = 35;
            string command = string.Empty;
            char[,] playground = CreatePlayground();
            char[,] bombs = PlaceBombs();
            int fieldsOpened = 0;
            int row = 0;
            int column = 0;
            List<Point> topPlayers = new List<Point>(6);
            bool gameover = false;
            bool newGame = true;
            bool gameWon = false;

            do
            {
                if (newGame)
                {
                    Console.WriteLine("Let's play MINESWEEPER. Try your luck to discover all empty fields without mines." +
                    " Command 'top' shows the ratings, 'restart' starts a new game, 'exit' exits from the application!");
                    DrawPlayground(playground);
                    newGame = false;
                }

                Console.Write("Row and Column: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= playground.GetLength(0) && column <= playground.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Highscores(topPlayers);
                        break;
                    case "restart":
                        playground = CreatePlayground();
                        bombs = PlaceBombs();
                        DrawPlayground(playground);
                        gameover = false;
                        newGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, have a nice day!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                NextTurn(playground, bombs, row, column);
                                fieldsOpened++;
                            }

                            if (FIELDS_IN_PLAYGROUND == fieldsOpened)
                            {
                                gameWon = true;
                            }
                            else
                            {
                                DrawPlayground(playground);
                            }
                        }
                        else
                        {
                            gameover = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid Command\n");
                        break;
                }

                if (gameover)
                {
                    DrawPlayground(bombs);
                    Console.Write("\nGame Over! You have {0} points. " + "Your nickname: ", fieldsOpened);
                    string nickname = Console.ReadLine();
                    
                    // Missing validation for nickname. "", "   ", " "
                    Point playerScore = new Point(nickname, fieldsOpened);

                    if (topPlayers.Count < 5)
                    {
                        topPlayers.Add(playerScore);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].Points < playerScore.Points)
                            {
                                topPlayers.Insert(i, playerScore);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayers.Sort((Point firstScore, Point secondScore) => secondScore.Name.CompareTo(firstScore.Name));
                    topPlayers.Sort((Point firstScore, Point secondScore) => secondScore.Points.CompareTo(firstScore.Points));

                    Highscores(topPlayers);

                    playground = CreatePlayground();
                    bombs = PlaceBombs();
                    fieldsOpened = 0;
                    gameover = false;
                    newGame = true;
                }

                if (gameWon)
                {
                    Console.WriteLine("\nCongratolations! You opened {0} fields.", FIELDS_IN_PLAYGROUND);
                    DrawPlayground(bombs);
                    Console.WriteLine("Enter your nickname: ");
                    string nickname = Console.ReadLine();
                    Point points = new Point(nickname, fieldsOpened);

                    topPlayers.Add(points);
                    Highscores(topPlayers);

                    playground = CreatePlayground();
                    bombs = PlaceBombs();
                    fieldsOpened = 0;
                    gameWon = false;
                    newGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria!");

            // Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Highscores(List<Point> points)
        {
            Console.WriteLine("\nHighscores:");

            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} fields", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Emtpy highscores!\n");
            }
        }

        private static void NextTurn(char[,] board, char[,] bombs, int row, int column)
        {
            char minesCount = CalculateMinesAroundField(bombs, row, column);
            bombs[row, column] = minesCount;
            board[row, column] = minesCount;
        }

        private static void DrawPlayground(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayground()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] playground = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    playground[i, j] = '-';
                }
            }

            List<int> numbers = new List<int>();
            while (numbers.Count < 15)
            {
                Random randomGeneratorForNumbers = new Random();
                int generatedNumber = randomGeneratorForNumbers.Next(50);
                if (!numbers.Contains(generatedNumber))
                {
                    numbers.Add(generatedNumber);
                }
            }

            foreach (int number in numbers)
            {
                int column = (number / columns);
                int row = (number % columns);

                if (row == 0 && number != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                playground[column, row - 1] = '*';
            }

            return playground;
        }

        
        private static void MinesAroundField(char[,] playground)
        {
            int col = playground.GetLength(0);
            int row = playground.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (playground[i, j] != '*')
                    {
                        char numberOfMines = CalculateMinesAroundField(playground, i, j);
                        playground[i, j] = numberOfMines;
                    }
                }
            }
        }

        private static char CalculateMinesAroundField(char[,] board, int row, int column)
        {
            int minesCount = 0;
            int boardRows = board.GetLength(0);
            int boardColumns = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, column] == '*')
                {
                    minesCount++;
                }
            }

            if (row + 1 < boardRows)
            {
                if (board[row + 1, column] == '*')
                {
                    minesCount++;
                }
            }

            if (column - 1 >= 0)
            {
                if (board[row, column - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (column + 1 < boardColumns)
            {
                if (board[row, column + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (board[row - 1, column - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < boardColumns))
            {
                if (board[row - 1, column + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < boardRows) && (column - 1 >= 0))
            {
                if (board[row + 1, column - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < boardRows) && (column + 1 < boardColumns))
            {
                if (board[row + 1, column + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}
