namespace SortingHomework.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var col = new SortableCollection<int>(new[] { -12, 3, 5 - 3, 1, 5, 6 - 2, -6, -22, 0, 123 });

            col.Sort(new QuickSorter<int>());
            var expected = new[] { -12, 3, 5 - 3, 1, 5, 6 - 2, -6, -22, 0, 123 };
            Array.Sort(expected);
            CollectionAssert.AreEqual(expected, col.Items.ToArray());
        }
    }
}
