namespace SortingHomework.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void ExpectToFindValue()
        {
            var col = new SortableCollection<int>(new[] { -12, 3, 5 - 3, 1, 5, 6 - 2, -6, -22, 0, 123 });

            col.Sort(new MergeSorter<int>());
            var searchvalue = -12;
            Assert.IsTrue(col.BinarySearch(searchvalue));
        }
    }
}