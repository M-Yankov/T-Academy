
namespace MatixTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Matrix;
    using NUnit.Framework;

    [TestFixture]
    public class SquareMatrixTest
    {
        [Test]
        public void TestMatrixAroundCells()
        {
            int[,] array = new int[,] 
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            SquareMatrix m = new SquareMatrix(3);
            m.Board = array;
            m.Pointer.Row = 1;
            m.Pointer.Column = 1;

            Assert.AreEqual(1, m.UpLeftValue);
            Assert.AreEqual(2, m.UpValue);
            Assert.AreEqual(3, m.UpRightValue);
            Assert.AreEqual(4, m.LeftValue);
            Assert.AreEqual(6, m.RightValue);
            Assert.AreEqual(7, m.DownLeftValue);
            Assert.AreEqual(8, m.DownValue);
            Assert.AreEqual(9, m.DownRightValue);
        }

        [Test]
        public void TestPrintMatrix()
        {
            int[,] array = new int[,] 
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            SquareMatrix m = new SquareMatrix(3);
            m.Board = array;

            string expected = 
@"  1  2  3
  4  5  6
  7  8  9";
            Assert.AreEqual(expected, m.Print());
        }

        [Test]
        public void TestHasEmptyCell()
        {
            int[,] array = new int[,] 
            {
                {1, 2, 3},
                {4, 5, 0},
                {7, 8, 9}
            };

            SquareMatrix m = new SquareMatrix(3);
            m.Board = array;

            Assert.AreEqual(false, m.HasEmptyCellAroundCursor());

            m.Pointer.MoveCursor();

            Assert.AreEqual(true, m.HasEmptyCellAroundCursor());
        }

        [Test]
        public void TestChangeToFirstNonVisitedCell()
        {
            int[,] array = new int[,] 
            {
                {1, 0, 3},
                {4, 5, 2},
                {7, 8, 9}
            };

            bool[,] visited = new bool[,] 
            {
                {true, false, true},
                {true, true, true},
                {true, true, true}
            };

            SquareMatrix m = new SquareMatrix(3);
            m.Board = array;
            m.VisitedCells = visited;
            m.Pointer.Row = 2;
            m.Pointer.Column = 2;

            if (!m.HasEmptyCellAroundCursor())
            {
                m.SetCursorToFirstNonVisitedCell();
            }

            Assert.AreEqual(0, m.Pointer.Row);
            Assert.AreEqual(1, m.Pointer.Column);
        }
    }
}
