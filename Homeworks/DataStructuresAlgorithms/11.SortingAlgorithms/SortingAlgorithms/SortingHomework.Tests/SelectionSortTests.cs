namespace SortingHomework.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SelectionSortTests
    {
        private SortableCollection<int> collection;
        private SortableCollection<double> doubleCollection;
        [TestMethod]
        public void ExpectSelectionSortToMakeSortIntegersCorrectly()
        {
            this.collection = new SortableCollection<int>(new int[] { 9, -43, 16, 101, 345, 62, -123, 25, -78, 3232, 1312, 132, -51224, 2, 234, 324, 21, -12341, 1231, 31, 31, 1, 23, 1, 3, 12, 3, 13, 12, 3, 1, 41, -3, 1132, -1 });
            this.collection.Sort(new SelectionSorter<int>());

            int[] expectedIntegerResultSorted = new int[] { 9, -43, 16, 101, 345, 62, -123, 25, -78, 3232, 1312, 132, -51224, 2, 234, 324, 21, -12341, 1231, 31, 31, 1, 23, 1, 3, 12, 3, 13, 12, 3, 1, 41, -3, 1132, -1 };
            Array.Sort(expectedIntegerResultSorted);

            CollectionAssert.AreEqual(expectedIntegerResultSorted, this.collection.Items.ToArray());
        }

        [TestMethod]
        public void ExpectToSortReversedIntegersCorrectly()
        {
            var items = new List<int> { 9, -43, 16, 101, 345, 62, -123, 25, -78, 3232, 1312, 132, -51224, 2, 234, 324, 21, -12341, 1231, 31, 31, 1, 23, 1, 3, 12, 3, 13, 12, 3, 1, 41, -3, 1132, -1 };
            items.Reverse();

            this.collection = new SortableCollection<int>(items);
            this.collection.Sort(new SelectionSorter<int>());

            int[] expectedIntegerResultSorted = new int[] { 9, -43, 16, 101, 345, 62, -123, 25, -78, 3232, 1312, 132, -51224, 2, 234, 324, 21, -12341, 1231, 31, 31, 1, 23, 1, 3, 12, 3, 13, 12, 3, 1, 41, -3, 1132, -1 };
            Array.Sort(expectedIntegerResultSorted);

            CollectionAssert.AreEqual(expectedIntegerResultSorted, this.collection.Items.ToArray());
        }

        [TestMethod]
        public void ExpectToSortDoubleCollectionCorrectly()
        {
            var arr  = new double[]
            {
                1.931, 123.141, -123.2334, 
                57.0, -29.732, 004.3, -522, 
                4332.123, 3.333, 3.33, -33.33
            };
            this.doubleCollection = new SortableCollection<double>(arr);
        }

        [TestCleanup]
        public void Clean()
        {
            this.collection = null;
            this.doubleCollection = null;
        }
    }
}