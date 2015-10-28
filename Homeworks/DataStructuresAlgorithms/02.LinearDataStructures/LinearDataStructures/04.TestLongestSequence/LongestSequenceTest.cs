namespace TestLongestSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LongestSequence;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LongestSequenceTest
    {
        private List<int> testNumbers;

        [TestMethod]
        public void ExpectWhenlongestSequenceIsInTheEndToReturnCorrectResult()
        {
            this.testNumbers = new List<int> { 9, 9, 1, 1, 3, 3, 5, 6, 7, 9, 9, 9 };
            var result = LongestSequence.FindLongestSequnceOfEqualNumbers(this.testNumbers);
            string resultAsString = string.Join(", ", result);
            Assert.AreEqual("9, 9, 9", resultAsString);
        }

        [TestMethod]
        public void ExpectWhenlongestSequenceIsInTheBeginingToReturnCorrectResult()
        {
            this.testNumbers = new List<int> { 1, 1, 1, 1, 3, 3, 5, 6, 7, 9, 9, 9 };
            var result = LongestSequence.FindLongestSequnceOfEqualNumbers(this.testNumbers);
            string resultAsString = string.Join(", ", result);
            Assert.AreEqual("1, 1, 1, 1", resultAsString);
        }

        [TestMethod]
        public void ExpectWhenlongestSequenceIsInTheMiddleToReturnCorrectResult()
        {
            this.testNumbers = new List<int> { 9, 9, 1, 1, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9 };
            var result = LongestSequence.FindLongestSequnceOfEqualNumbers(this.testNumbers);
            string resultAsString = string.Join(", ", result);
            Assert.AreEqual("8, 8, 8, 8, 8, 8, 8", resultAsString);
        }

        [TestMethod]
        public void ExpectToReturnFirstLongestSequenceWhenExistMoreThenOne()
        {
            this.testNumbers = new List<int> { 9, 9, 9, 1, 1, 1, 8, 8, 8, 7, 8, 2, 2, 2 };
            var result = LongestSequence.FindLongestSequnceOfEqualNumbers(this.testNumbers);
            string resultAsString = string.Join(", ", result);
            Assert.AreEqual("9, 9, 9", resultAsString);
        }

        [TestMethod]
        public void ExpectToReturnFirstNumberWhenNoHaveLongestSequence()
        {
            this.testNumbers = new List<int> { 1, 4, 5, 8, 1, 4, 5 };
            var result = LongestSequence.FindLongestSequnceOfEqualNumbers(this.testNumbers);
            string resultAsString = string.Join(", ", result);
            Assert.AreEqual("1", resultAsString);
        }

        [TestMethod]
        public void ExpectToReturnWholeListWhenAllNumbersAreEqual()
        {
            this.testNumbers = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            var result = LongestSequence.FindLongestSequnceOfEqualNumbers(this.testNumbers);
            Assert.AreEqual(this.testNumbers.Count, result.Count);
            bool areAllEqual = result.All(num => num == this.testNumbers[0]);
            Assert.IsTrue(areAllEqual);
        }

        [TestMethod]
        public void ExpectToReturnCorrectResultsWithNegativeNumbers()
        {
            this.testNumbers = new List<int> { -5, -0, -3, -4, 0, 0, -4, -4, -4 };
            var result = LongestSequence.FindLongestSequnceOfEqualNumbers(this.testNumbers);
            var resultAsString = string.Join(", ", result);
            Assert.AreEqual("-4, -4, -4", resultAsString);
        }

        [TestMethod]
        public void ExpectToReturnCorrectResultsWhenOnlyZerosAreProvided()
        {
            this.testNumbers = new List<int> { 0, 0, 0, 0, 0, -0, -0, -0, +0, +0, 0, -0, +0, 0 * 0, };
            var result = LongestSequence.FindLongestSequnceOfEqualNumbers(this.testNumbers);
            Assert.AreEqual(this.testNumbers.Count, result.Count);
            bool areAllEqual = result.All(num => num == 0);
            Assert.IsTrue(areAllEqual);
        }

        [TestCleanup]
        private void ClearList()
        {
            this.testNumbers.Clear();
        }
    }
}
