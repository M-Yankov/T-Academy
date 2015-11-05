namespace TestsOfStructures
{
    using System;
    using KeyValuePairStructure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PairHashTableTests
    {
        private HashTable<string, int> hashTable;

        [TestInitialize]
        public void Initizlize()
        {
            this.hashTable = new HashTable<string, int>();
        }

        [TestMethod]
        public void TestWhenInstanciateObjectNotToThrow()
        {
            HashTable<string, int> result = new HashTable<string, int>(30);
            Assert.AreEqual(0, result.Count);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddMethodToThrowException()
        {
            this.hashTable.Add("Ivan", 2);
            this.hashTable.Add("Ivan", 2);
            this.hashTable.Add("Ivan", 2);

            Assert.AreEqual(1, this.hashTable.Count);
        }

        [TestMethod]
        public void TestAddingElementsInTheTableToWorkCorrect()
        {
            int length = 10;
            for (int i = 0; i < length; i++)
            {
                this.hashTable.Add((i * i) + "sir Ivan" + i, i * 2);
            }

            Assert.AreEqual(length, this.hashTable.Count);
        }

        [TestMethod]
        public void TestFindMethodToReturnCorrectValues()
        {
            string key = "Java Script";
            int value = 2;

            this.hashTable.Add(key + "fake", value * 2);
            this.hashTable.Add("fake" + key, value);
            this.hashTable.Add(key, value);
            this.hashTable.Add(" " + key, value + 1);
            this.hashTable.Add(key + " ", value - 1);

            int result = this.hashTable.Find(key);
            Assert.AreEqual(value, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFinfMethodToThrowWhenTableIsEmpty()
        {
            string key = "Java Script";
            int result = this.hashTable.Find(key);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFinfMethodToThrowWhenTableIsNotEmptyButKeyCannotBeFound()
        {
            string key = "Java Script";

            for (int i = 0; i < 120; i++)
            {
                this.hashTable.Add((i * i) + key + i, i * 2);
            }

            int result = this.hashTable.Find(key);
        }

        [TestMethod]
        public void TestRemoveMethodToRemoveValue()
        {
            string key = "Python";
            int length = 60;

            for (int i = 0; i < length; i++)
            {
                this.hashTable.Add((i * i) + key + " " + i, i * 2);
            }

            this.hashTable.Remove("4" + key + " 2");

            Assert.AreEqual(length - 1, this.hashTable.Count);
        }

        [TestMethod]
        public void TestRemoveMethodNotToThrowWhenTableIsEmpty()
        {
            this.hashTable.Remove("Invalid Key");
        }

        [TestMethod]
        public void TestClearMethodToSetAllElemntsInDataToNull()
        {
            string key = "Python";
            int length = 60;

            for (int i = 0; i < length; i++)
            {
                this.hashTable.Add((i * i) + key + " " + i, i * 2);
            }

            this.hashTable.Clear();

            int counter = 0;

            //// If there are one element that is not null, program flow will enter in the foreach loop
            foreach (var item in this.hashTable)
            {
                counter++;
            }

            Assert.AreEqual(0, counter);
            Assert.AreEqual(0, this.hashTable.Count);
        }

        [TestMethod]
        public void TestIndexOfTableToReturnCorrectPair()
        {
            this.hashTable.Add("TestScript", 3);
            this.hashTable.Add("TestCode", 35);
            this.hashTable.Add("TestFile", -6);

            var testFilePair = this.hashTable["TestFile"];
            var testCodePair = this.hashTable["TestCode"];
            var testScriptPair = this.hashTable["TestScript"];

            Assert.AreEqual(testScriptPair.Value, 3);
            Assert.AreEqual(testCodePair.Value, 35);
            Assert.AreEqual(testFilePair.Value, -6);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIndexOfToThrowExceptionWhenKeyNotExistInEmptyTable()
        {
            var testFilePair = this.hashTable["Invalid Key"];
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIndexOfToThrowExceptionWhenKeyNotExistInTableWithSomeData()
        {
            this.hashTable.Add("test1", 2);
            this.hashTable.Add("test2", 2);
            this.hashTable.Add("test4", 2);
            var testFilePair = this.hashTable["Invalid Key"];
        }

        [TestMethod]
        public void TestIteratingElementsInTheHashTableWithForeach()
        {
            int value = 23;
            this.hashTable.Add("TestIterator", value);
            this.hashTable.Add("IteratorForAPFTesting", value);
            this.hashTable.Add("TestIterator123", value);
            this.hashTable.Add("IteratorForASDFsfTesting", value);
            this.hashTable.Add("TestIteratorNOnO", value);
            this.hashTable.Add("IteratorForTesting", value);

            int counter = 0;
            foreach (var item in this.hashTable)
            {
                Assert.AreEqual(value, item.Value);
                counter++;
            }

            Assert.AreEqual(6, counter);
        }

        [TestMethod]
        public void TestKeysOfHashTableToContainsCorrectValues()
        {
            this.hashTable.Add("test1", 2);
            this.hashTable.Add("test2", 2);
            this.hashTable.Add("test3", 2);

            Assert.AreEqual(3, this.hashTable.Keys.Count);
            Assert.IsTrue(this.hashTable.Keys.Contains("test1"));
            Assert.IsTrue(this.hashTable.Keys.Contains("test2"));
            Assert.IsTrue(this.hashTable.Keys.Contains("test3"));
            Assert.IsFalse(this.hashTable.Keys.Contains("invalid"));
        }

        [TestMethod]
        public void TestKeysToBeEmptyWhenNoElementAdded()
        {
            Assert.AreEqual(0, this.hashTable.Keys.Count);
        }
    }
}
