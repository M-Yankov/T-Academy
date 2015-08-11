namespace MatixTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Matrix;

    [TestFixture]
    public class CursorTest
    {
        [Test]
        public void TestNextMovesCursor()
        {
            Cursor pointer = new Cursor();
            pointer.MoveCursor();
            pointer.MoveCursor();
            pointer.Direction = Direction.Down;

            pointer.MoveCursor();
            pointer.MoveCursor();
            Assert.AreEqual(4, pointer.Row);
            Assert.AreEqual(2, pointer.Column);
            Assert.AreEqual(Direction.Down, pointer.Direction);
        }

        [Test]
        public void TestChangedirection()
        {
            Cursor point = new Cursor();
            for (int i = 0; i < 8; i++)
            {
                point.ChangeToNextClockWiseDirection();
            }

            Assert.AreEqual(Direction.DownRight, point.Direction);
        }
    }
}
