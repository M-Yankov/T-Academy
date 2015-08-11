namespace Matrix
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class SquareMatrix
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;

        private int[,] board;
        private bool[,] visitedCells;
        private Cursor pointer;
        private int length;

        public SquareMatrix(int baseLength)
        {
            this.Board = new int[baseLength, baseLength];
            this.VisitedCells = new bool[baseLength, baseLength];
            this.Pointer = new Cursor(0, 0, Direction.DownRight);
            this.Length = baseLength;
        }

        public int[,] Board
        {
            get
            {
                return this.board;
            }

            set
            {
                Validation(value.GetUpperBound(0));

                this.board = value;
            }
        }

        public bool[,] VisitedCells
        {
            get
            {
                return this.visitedCells;
            }

            set
            {
                Validation(value.GetUpperBound(0));

                this.visitedCells = value;

                for (int row = 0; row < this.visitedCells.GetUpperBound(0); row++)
                {
                    for (int col = 0; col < this.visitedCells.GetUpperBound(1); col++)
                    {
                        this.visitedCells[row, col] = false;
                    }
                }
            }
        }

        public int Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (value < MIN_VALUE || MAX_VALUE < value)
                {
                    throw new ArgumentException("VAlue must be between " + MIN_VALUE + " and " + MAX_VALUE + "!", value.ToString());
                }

                this.length = value;
            }
        }

        public Cursor Pointer
        {
            get
            {
                return this.pointer;
            }

            set
            {
                this.pointer = value;
            }
        }

        // values of surrounding cells
        public int UpValue
        {
            get
            {
                if (this.Pointer.Row == 0)
                {
                    return -1;
                }

                return this.Board[this.Pointer.Row - 1, this.Pointer.Column];
            }
        }

        public int UpRightValue
        {
            get
            {
                if (this.Pointer.Row == 0 || this.Pointer.Column == this.Length - 1)
                {
                    return -1;
                }

                return this.Board[this.Pointer.Row - 1, this.Pointer.Column + 1];
            }
        }

        public int RightValue
        {
            get
            {
                if (this.Pointer.Column == this.Length - 1)
                {
                    return -1;
                }

                return this.Board[this.Pointer.Row, this.Pointer.Column + 1];
            }
        }

        public int DownRightValue
        {
            get
            {
                if (this.Pointer.Row == this.Length - 1 || this.Pointer.Column == this.Length - 1)
                {
                    return -1;
                }

                return this.Board[this.Pointer.Row + 1, this.Pointer.Column + 1];
            }
        }

        public int DownValue
        {
            get
            {
                if (this.Pointer.Row == this.Length - 1)
                {
                    return -1;
                }

                return this.Board[this.Pointer.Row + 1, this.Pointer.Column];
            }
        }

        public int DownLeftValue
        {
            get
            {
                if (this.Pointer.Row == this.Length - 1 || this.Pointer.Column == 0)
                {
                    return -1;
                }

                return this.Board[this.Pointer.Row + 1, this.Pointer.Column - 1];
            }
        }

        public int LeftValue
        {
            get
            {
                if (this.Pointer.Column == 0)
                {
                    return -1;
                }

                return this.Board[this.Pointer.Row, this.Pointer.Column - 1];
            }
        }

        public int UpLeftValue
        {
            get
            {
                if (this.Pointer.Row == 0 || this.Pointer.Column == 0)
                {
                    return -1;
                }

                return this.Board[this.Pointer.Row - 1, this.Pointer.Column - 1];
            }
        }

        public bool HasEmptyCellAroundCursor()
        {
            int[] cellsAroundCursor = new int[] { this.UpValue, this.UpRightValue, this.RightValue, this.DownRightValue,
                                                  this.DownValue, this.DownLeftValue, this.LeftValue, this.UpLeftValue };

            if (cellsAroundCursor.Any(cell => cell == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetCursorToFirstNonVisitedCell()
        {
            for (int row = 0; row < this.Length; row++)
            {
                for (int col = 0; col < this.Length; col++)
                {
                    if (this.VisitedCells[row, col] == false)
                    {
                        this.Pointer.Row = row;
                        this.Pointer.Column = col;
                        this.Pointer.Direction = Direction.DownRight;
                        return;
                    }
                }
            }

            throw new InvalidOperationException("Can't find empty cell in the matrix board!");
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.Length; row++)
            {
                if (row != 0)
                {
                    result.AppendLine();
                }

                for (int col = 0; col < this.Length; col++)
                {
                    result.Append(string.Format("{0,6}", this.Board[row, col]));
                }
            }

            return result.ToString();
        }

        public void RecordToTextFile()
        {
            StreamWriter writer = new StreamWriter("..\\..\\Results.txt");
            string result = this.Print();

            using (writer)
            {
                writer.WriteLine(result);
            }
        }

        public void TraverseMatrix()
        {
            Direction[] directions = { Direction.Up, Direction.UpRight, Direction.Right, Direction.DownRight, 
                                       Direction.Down, Direction.DownLeft, Direction.Left, Direction.UpLeft };
            int[] nextMoves = new int[directions.Length];

            int step = 1;
            int lengthOfTravel = this.Length * this.Length;

            for (int i = 0; i < lengthOfTravel; i++)
            {
                // update next moves;
                nextMoves[0] = this.UpValue;
                nextMoves[1] = this.UpRightValue;
                nextMoves[2] = this.RightValue;
                nextMoves[3] = this.DownRightValue;
                nextMoves[4] = this.DownValue;
                nextMoves[5] = this.DownLeftValue;
                nextMoves[6] = this.LeftValue;
                nextMoves[7] = this.UpLeftValue;

                this.Board[this.Pointer.Row, this.Pointer.Column] = step;
                this.VisitedCells[this.Pointer.Row, this.Pointer.Column] = true;
                step++;

                if (this.HasEmptyCellAroundCursor())
                {
                    int indexOfDirection = Array.IndexOf(directions, this.Pointer.Direction);

                    while (nextMoves[indexOfDirection] != 0)
                    {
                        this.Pointer.ChangeToNextClockWiseDirection();
                        indexOfDirection++;

                        if (indexOfDirection >= 8)
                        {
                            indexOfDirection = 0;
                        }
                    }

                    this.Pointer.MoveCursor();
                }
                else
                {
                    if (i != lengthOfTravel - 1)
                    {
                        this.SetCursorToFirstNonVisitedCell();
                    }
                }
            }
        }

        private static void Validation(int value)
        {
            if (value < MIN_VALUE || MAX_VALUE < value)
            {
                throw new ArgumentException("VAlue must be between " + MIN_VALUE + " and " + MAX_VALUE + "!", value.ToString());
            }
        }
    }
}
