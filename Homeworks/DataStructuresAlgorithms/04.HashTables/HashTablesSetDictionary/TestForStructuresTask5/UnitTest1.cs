namespace TestForStructuresTask5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HashedSetStructure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        private HashedSet<int> hashedSet;

        [TestInitialize]
        public void Init()
        {
            this.hashedSet = new HashedSet<int>();
        }

        [TestMethod]
        public void TestAddingDucplicateValuesToBeAddedOnce()
        {
            this.hashedSet.Add(2);
            this.hashedSet.Add(2);

            Assert.AreEqual(1, this.hashedSet.Count);
        }

        [TestMethod]
        public void TestAddingDucplicateValuesToBeAddedOnceAdvaced()
        {
            int length = 50;
            int expectedResult = 4;

            for (int i = 0; i < length; i++)
            {
                this.hashedSet.Add(i % expectedResult);
            }

            Assert.AreEqual(4, this.hashedSet.Count);
        }

        [TestMethod]
        public void TestDinfMethodToReturnCorrectResult()
        {
            this.hashedSet.Add(2);
            this.hashedSet.Add(22);
            this.hashedSet.Add(-32);
            this.hashedSet.Add(-42);
            this.hashedSet.Add(25);

            int result = this.hashedSet.Find(-42);

            Assert.AreEqual(-42, result);
        }

        [TestMethod]
        public void TestInitialSizeToBeZero()
        {
            HashedSet<string> testHashSet = new HashedSet<string>(100);

            Assert.AreEqual(0, testHashSet.Count);
        }

        [TestMethod]
        public void TestRemoveMethodToNotDecrementCounterWhenNoElementsInTheSet()
        {
            this.hashedSet.Remove(2);

            Assert.AreEqual(0, this.hashedSet.Count);
        }

        [TestMethod]
        public void TestRemoveMethodToRemoveCorrectElement()
        {
            this.hashedSet.Add(-362);
            this.hashedSet.Remove(-362);

            Assert.AreEqual(0, this.hashedSet.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveMethodToRemoveCorrectElementWithSearch()
        {
            this.hashedSet.Add(-362);
            this.hashedSet.Remove(-362);
            int result = this.hashedSet.Find(-362);

            Assert.AreEqual(0, this.hashedSet.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFindMethodToThrowWhenNotFound()
        {
            this.hashedSet.Add(123);
            this.hashedSet.Add(36223);
            this.hashedSet.Add(362);
            int result = this.hashedSet.Find(-362);

            Assert.AreEqual(0, this.hashedSet.Count);
        }

        [TestMethod]
        public void TestFindMethodToReturnCorrectValue()
        {
            int expected = 362;
            this.hashedSet.Add(123);
            this.hashedSet.Add(36223);
            this.hashedSet.Add(expected);
            int result = this.hashedSet.Find(expected);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestUnionMethodWithIntegers()
        {
            HashedSet<int> odds = new HashedSet<int>();
            odds.Add(1);
            odds.Add(3);
            odds.Add(5);

            HashedSet<int> evens = new HashedSet<int>();
            evens.Add(2);
            evens.Add(4);
            evens.Add(6);

            odds.Union(evens);

            Assert.AreEqual(6, odds.Count);

            for (int i = 1; i < odds.Count; i++)
            {
                int result = odds.Find(i);
                Assert.AreEqual(i, result);
            }
        }

        [TestMethod]
        public void TestUnionMethodWithIntegersButEmptySets()
        {
            HashedSet<int> first = new HashedSet<int>();
            HashedSet<int> second = new HashedSet<int>();

            first.Union(second);

            Assert.AreEqual(0, first.Count);
        }

        [TestMethod]
        public void TestIntersectMethodToReturnCorrectResults()
        {
            int matchedValue1 = 18;
            int matchedValue2 = -5;

            HashedSet<int> first = new HashedSet<int>();
            first.Add(3);
            first.Add(matchedValue2);
            first.Add(matchedValue1);
            first.Add(14);

            HashedSet<int> second = new HashedSet<int>();
            second.Add(20);
            second.Add(22);
            second.Add(matchedValue1);
            second.Add(290);
            second.Add(matchedValue2);
            second.Add(300);

            first.Intersect(second);

            Assert.AreEqual(2, first.Count);

            var testResult = first.Find(matchedValue1);
            Assert.AreEqual(matchedValue1, testResult);

            testResult = first.Find(matchedValue2);
            Assert.AreEqual(matchedValue2, testResult);
        }

        [TestMethod]
        public void TestIntersectMethodToReturnCorrectResultsWithStrings()
        {
            string matchedValue1 = "Java";
            string matchedValue2 = "CSharp";

            HashedSet<string> first = new HashedSet<string>();
            first.Add("3");
            first.Add(matchedValue2);
            first.Add(matchedValue1);
            first.Add("test");

            HashedSet<string> second = new HashedSet<string>();
            second.Add("testMethod");
            second.Add("TestClass");
            second.Add(matchedValue1);
            second.Add("TestData");
            second.Add(matchedValue2);
            second.Add(" ");

            first.Intersect(second);

            Assert.AreEqual(2, first.Count);

            var testResult = first.Find(matchedValue1);
            Assert.AreEqual(matchedValue1, testResult);

            testResult = first.Find(matchedValue2);
            Assert.AreEqual(matchedValue2, testResult);
        }

        [TestMethod]
        public void TestIntersectMethodWhenThereAreNoMathes()
        {
            HashedSet<string> first = new HashedSet<string>();
            first.Add("3");
            first.Add("PHP");
            first.Add("Python");
            first.Add("test");

            HashedSet<string> second = new HashedSet<string>();
            second.Add("testMethod");
            second.Add("TestClass");
            second.Add("Ruby On Rails");
            second.Add("TestData");
            second.Add("Cloud");
            second.Add(" ");

            first.Intersect(second);

            Assert.AreEqual(0, first.Count);
        }

        [TestMethod]
        public void TestClearMethodToClearAllElements()
        {
            HashedSet<string> first = new HashedSet<string>();
            first.Add("TestIntro");
            first.Add("PHP");
            first.Add("Java");

            first.Clear();

            Assert.AreEqual(0, first.Count);
        }
    }
}
