namespace Matrix
{
    using System;

    public class Cursor
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;
        private int currentRow;
        private int currentColumn;
        private Direction direction;
        private Direction[] allClockWiseDirections =
            new Direction[] { Direction.Up, Direction.UpRight, Direction.Right, Direction.DownRight,
                              Direction.Down, Direction.DownLeft, Direction.Left, Direction.UpLeft };


        public Cursor(int startRow, int startCol, Direction dir)
        {
            this.Row = startRow;
            this.Column = startCol;
            this.Direction = dir;
        }

        public Cursor(int startRow, int startCol)
            : this(startRow, startCol, Direction.DownRight)
        {

        }

        public Cursor()
            : this(0, 0, Direction.DownRight)
        {

        }

        public int Row
        {
            get
            {
                return this.currentRow;
            }

            set
            {
                if (value < MIN_VALUE || MAX_VALUE < value)
                {
                    throw new ArgumentException("Value must be between " + MIN_VALUE + " and " + MAX_VALUE + "!", value.ToString());
                }

                this.currentRow = value;
            }
        }

        public int Column
        {
            get
            {
                return this.currentColumn;
            }

            set
            {
                if (value < MIN_VALUE || MAX_VALUE < value)
                {
                    throw new ArgumentException("Value must be between " + MIN_VALUE + " and " + MAX_VALUE + "!", value.ToString());
                }

                this.currentColumn = value;
            }
        }

        public Direction Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                this.direction = value;
            }
        }

        public void MoveCursor()
        {
            switch (this.Direction)
            {
                case Direction.Up:
                    this.Row -= 1;
                    break;
                case Direction.UpRight:
                    this.Row -= 1;
                    this.Column += 1;
                    break;
                case Direction.Right:
                    this.Column += 1;
                    break;
                case Direction.DownRight:
                    this.Row += 1;
                    this.Column += 1;
                    break;
                case Direction.Down:
                    this.Row += 1;
                    break;
                case Direction.DownLeft:
                    this.Row += 1;
                    this.Column -= 1;
                    break;
                case Direction.Left:
                    this.Column -= 1;
                    break;
                case Direction.UpLeft:
                    this.Row -= 1;
                    this.Column -= 1;
                    break;
                default:
                    throw new ArgumentException("Unexpected Direction parameter!", this.Direction.ToString());
            }
        }

        public void ChangeToNextClockWiseDirection()
        {
            int indexOfCurrentDirection = Array.IndexOf(allClockWiseDirections, this.Direction);
            int indexOfNextDirection = indexOfCurrentDirection + 1;

            if (indexOfNextDirection >= allClockWiseDirections.Length)
            {
                indexOfNextDirection = 0;
            }

            this.Direction = allClockWiseDirections[indexOfNextDirection];
        }
    }
}
