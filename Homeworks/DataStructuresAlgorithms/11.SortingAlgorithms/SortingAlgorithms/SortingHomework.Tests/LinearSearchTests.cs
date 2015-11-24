namespace SortingHomework.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinearSearchTests
    {
        [TestMethod]
        public void TestShouldFindValue()
        {
            var col = new SortableCollection<int>(new[] { -12, 3, 5 - 3, 1, 5, 6 - 2, -6, -22, 0, 123 });

            col.Sort(new MergeSorter<int>());
            var searchvalue = 5;
            Assert.IsTrue(col.LinearSearch(searchvalue));
        }

        [TestMethod]
        public void TestShouldnotFindValue()
        {
            var col = new SortableCollection<int>(new[] { -12, 3, 5 - 3, 1, 5, 6 - 2, -6, -22, 0, 123 });

            col.Sort(new MergeSorter<int>());
            Assert.IsFalse(col.LinearSearch(99));
        }
    }
}