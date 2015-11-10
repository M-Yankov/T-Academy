namespace BugLogger.RestApi.Tests.MyWebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using BugLogger.DataLayer;
    using BugLogger.Repositories;
    using BugLogger.RestApi.App_Start;
    using BugLogger.RestApi.Controllers;
    using BugLogger.RestApi.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Telerik.JustMock;

    [TestClass]
    public class ControllerActionsTests
    {
        private IQueryable<Bug> fakeBugs;
        private IRepository<Bug> repo;

        [TestInitialize]
        public void Init()
        {
            MapperConfig.RegisterMappings(Assembly.Load("BugLogger.RestApi"));
            MyWebApi.IsRegisteredWith(WebApiConfig.Register);

            this.fakeBugs = new List<Bug>()
            {
               new Bug { Id = 1, LogDate = new DateTime(2013, 5, 1), Status = Status.Pending, Text = "Testing Bug #1" },
               new Bug { Id = 2, LogDate = new DateTime(2010, 2, 13), Status = Status.Assigned, Text = "Testing Bug #2" },
               new Bug { Id = 11, LogDate = new DateTime(2003, 2, 22), Status = Status.Fixed, Text = "example data" },
               new Bug { Id = 21, LogDate = new DateTime(2014, 1, 11), Status = Status.Fixed, Text = "Data account not working" },
               new Bug { Id = 22, LogDate = new DateTime(2013, 6, 2), Status = Status.Pending, Text = "SOme tests Failed" },
               new Bug { Id = 23, LogDate = new DateTime(2012, 8, 2), Status = Status.Pending, Text = "No time to learn Telerik academy video lectures" },
               new Bug { Id = 24, LogDate = new DateTime(2012, 7, 18), Status = Status.Assigned, Text = "Make better player on Santase AI Engine" },
               new Bug { Id = 25, LogDate = new DateTime(2011, 3, 21), Status = Status.Assigned, Text = "Done all homeworks" },
               new Bug { Id = 30, LogDate = new DateTime(2009, 7, 2), Status = Status.Pending, Text = "Go frag yourself finally" },
            }
            .AsQueryable();

            this.repo = Mock.Create<IRepository<Bug>>();
            Mock.Arrange(() => this.repo.All()).Returns(this.fakeBugs);
        }

        [TestMethod]
        public void TestActionReturnsCorrectResponseModel()
        {
            MyWebApi
                .Controller<BugsController>()
                .Calling(c => c.GetAll())
                .ShouldReturn()
                .ResultOfType<IQueryable<ResponseBugModel>>();
        }

        [TestMethod]
        public void TestGetsBugByStartDateResutCorrectResponseModel()
        {
            MyWebApi
                .Controller<BugsController>()
                .Calling(x => x.GetBugsByStartDate(new DateTime(2000, 1, 1)))
                .ShouldReturn()
                .Ok();
        }

        [TestMethod]
        public void TestValidStateModelWhenPosting()
        {
            MyWebApi
                .Controller<BugsController>()
                .Calling(
                    c =>
                        c.PostBug(new SaveBugModel
                        {
                            Text = "Adding Test Bug",
                            Status = SaveStatus.Pending,
                            LogDate = new DateTime(2015, 11, 10)
                        }))
                .ShouldHave()
                .ValidModelState();
        }

        [TestMethod]
        public void TestGetBugsFromTypeToReturnCorrectResults()
        {
            MyWebApi
                .Controller<BugsController>()
                .WithResolvedDependencyFor<IRepository<Bug>>(this.repo)
                .Calling(c => c.GetByStatusType("Assigned"))
                .ShouldReturn()
                .ResultOfType<IQueryable<ResponseBugModel>>()
                .Passing(c => c.Count() == 3 && c.All(b => b.Status == "Assigned"));
        }

        [TestMethod]
        public void TestGettingBugsFromTypeWithInvalidParametarToReturnCorrectResults()
        {
            MyWebApi
                .Controller<BugsController>()
                .WithResolvedDependencyFor<IRepository<Bug>>(this.repo)
                .Calling(c => c.GetByStatusType("Invalid"))
                .ShouldReturn()
                .ResultOfType<IQueryable<ResponseBugModel>>()
                .Passing(c => c.Count() == 0);
        }

        [TestMethod]
        public void TestGettingSpecificCountOfBugsToReturnsCorrectResult()
        {
            MyWebApi
                .Controller<BugsController>()
                .WithResolvedDependencyFor<IRepository<Bug>>(this.repo)
                .Calling(c => c.GetCount(6))
                .ShouldReturn()
                .ResultOfType<IQueryable<ResponseBugModel>>()
                .Passing(c => c.Count() == 6);
        }

        [TestMethod]
        public void TestGettingLargeNumberOfBugsToreturnAllFromFakeRepos()
        {
            MyWebApi
                .Controller<BugsController>()
                .WithResolvedDependencyFor<IRepository<Bug>>(this.repo)
                .Calling(c => c.GetCount(16000))
                .ShouldReturn()
                .ResultOfType<IQueryable<ResponseBugModel>>()
                .Passing(c => c.Count() == this.fakeBugs.Count());
        }

        [TestMethod]
        public void TestGettingBugsWithNegativeNumberParameterToReturnNothing()
        {
            MyWebApi
                .Controller<BugsController>()
                .WithResolvedDependencyFor<IRepository<Bug>>(this.repo)
                .Calling(c => c.GetCount(-16000))
                .ShouldReturn()
                .ResultOfType<IQueryable<ResponseBugModel>>()
                .Passing(c => c.Count() == 0);
        }

        [TestMethod]
        public void TestGetBugsAfterSpecifiedDateReturnsCorrectResult()
        {
            var date = new DateTime(2012, 7, 7);
            int countOfBugAfterDate = this.fakeBugs.Count(b => b.LogDate >= date);

            MyWebApi
                .Controller<BugsController>()
                .WithResolvedDependencyFor<IRepository<Bug>>(this.repo)
                .Calling(c => c.GetBugsByStartDate(date))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<ResponseBugModel>>()
                .Passing(c => c.Count == countOfBugAfterDate);
        }

        [TestMethod]
        public void TestGetBugsFiltredInDateRangeExpectCorrectResult()
        {
            var start = new DateTime(2009, 2, 1);
            var end = new DateTime(2012, 5, 5);
            int countOfBugAfterDate = this.fakeBugs.Count(b => start <= b.LogDate && b.LogDate <= end);

            MyWebApi
                .Controller<BugsController>()
                .WithResolvedDependencyFor<IRepository<Bug>>(this.repo)
                .Calling(c => c.GetBugsInRange(start, end))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<ResponseBugModel>>()
                .Passing(c => c.Count == countOfBugAfterDate);
        }

        [TestMethod]
        public void TestPostingANewBugWithOnlyTextParameterProvided()
        {
            var bugToPost = new SaveBugModel();
            bugToPost.Text = "TestLoggin BugData";

            MyWebApi
                .Controller<BugsController>()
                .WithResolvedDependencyFor<IRepository<Bug>>(this.repo)
                .Calling(c => c.PostBug(bugToPost))
                .ShouldReturn()
                .Created()
                .WithResponseModelOfType<ResponseBugModel>()
                .Passing(c => c.Text == bugToPost.Text);
        }

        [TestMethod]
        public void TestPostingANewBugWithFullParametersProvided()
        {
            var bugToPost = new SaveBugModel();
            bugToPost.Text = "AssignedToPesho";
            bugToPost.LogDate = new DateTime(2013, 3, 3);
            bugToPost.Status = SaveStatus.Assigned;

            MyWebApi
                .Controller<BugsController>()
                .Calling(c => c.PostBug(bugToPost))
                .ShouldReturn()
                .Created()
                .WithResponseModelOfType<ResponseBugModel>()
                .Passing(c => 
                {
                    return c.Text == bugToPost.Text &&
                        c.LogDate == bugToPost.LogDate.Value.Day + "." + bugToPost.LogDate.Value.Month + "." + bugToPost.LogDate.Value.Year &&
                        c.Status == "Assigned";
                });
        }
        
        [TestMethod]
        public void TestPostingANewBugWithOutTextParameterProvidedToReturnBadRequest()
        {
            var bugToPost = new SaveBugModel();
            bugToPost.LogDate = DateTime.Now;

            MyWebApi
                .Controller<BugsController>()
                .Calling(c => c.PostBug(bugToPost))
                .ShouldReturn()
                .BadRequest()
                .WithErrorMessage("Text of the bug cannot be null or empty.");
        }

        [TestMethod]
        public void TestPostingActionWithaPassingNullAsParameter()
        {
            MyWebApi
                .Controller<BugsController>()
                .Calling(c => c.PostBug(null))
                .ShouldReturn()
                .BadRequest()
                .WithErrorMessage("No data sent!");
        }

        [TestMethod]
        public void TestChangeBugStatusToBeCorrect()
        {
            var bug = new Bug
            {
                Id = 3,
                LogDate = new DateTime(2013, 3, 3),
                 Status = Status.Assigned,
                 Text = "Demo Bug aka. demon"
            };

            Mock.Arrange(() => this.repo.Update(Arg.IsAny<Bug>())).DoInstead<Bug>(b => bug.Status = b.Status);
            Mock.Arrange(() => this.repo.Find(Arg.IsAny<int>())).Returns(bug);

            MyWebApi
                .Controller<BugsController>()
                .WithResolvedDependencyFor<IRepository<Bug>>(this.repo)
                .Calling(c => c.PutBug(bug.Id, new SaveBugModel { Status = SaveStatus.Fixed, LogDate = new DateTime(2013, 3, 3), Text = "Bug Changed" }))
                .ShouldReturn()
                .Ok();

            Assert.IsTrue(bug.Status == Status.Fixed);
        }
    }
}
