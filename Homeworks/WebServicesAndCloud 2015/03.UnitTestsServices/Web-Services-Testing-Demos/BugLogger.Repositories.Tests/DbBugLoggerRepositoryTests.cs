namespace BugLogger.Repositories.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Transactions;
    using BugLogger.DataLayer;
    using BugLogger.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DbBugLoggerRepositoryTests
    {
        private static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Find_WhenObjectIsInDb_ShouldReturnObject()
        {
            //// arrange
            var bug = this.GetValidTestBug();

            var dbContext = new BugLoggerDbContext();
            var repo = new DbBugsRepository(dbContext);

            dbContext.Bugs.Add(bug);
            dbContext.SaveChanges();

            //// act
            var bugInDb = repo.Find(bug.Id);

            //// asesrt
            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        [TestMethod]
        public void AddBug_WhenBugIsValid_ShouldAddToDb()
        {
            //// arrange -> prapare the objects
            var bug = this.GetValidTestBug();

            var dbContext = new BugLoggerDbContext();
            var repo = new DbBugsRepository(dbContext);

            //// act -> test the objects

            repo.Add(bug);
            repo.Save();

            //// assert -> validate the result
            var bugInDb = dbContext.Bugs.Find(bug.Id);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }
  
        private Bug GetValidTestBug()
        {
            var bug = new Bug()
            {
                Text = "Test New bug",
                LogDate = DateTime.Now,
                Status = Status.Pending
            };
            return bug;
        }
    }
}
