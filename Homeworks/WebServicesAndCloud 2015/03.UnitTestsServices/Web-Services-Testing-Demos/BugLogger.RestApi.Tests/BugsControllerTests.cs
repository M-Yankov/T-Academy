namespace BugLogger.RestApi.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Hosting;
    using System.Web.Http.Routing;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BugLogger.DataLayer;
    using BugLogger.Repositories;
    using BugLogger.RestApi.Controllers;
    using BugLogger.RestApi.Models;
    using BugLogger.RestApi.Tests.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class BugsControllerTests
    {
        [TestInitialize]
        public void Init()
        {
            Mapper.CreateMap<Bug, ResponseBugModel>()
                .ForMember(x => x.Status, opts => opts.MapFrom(z => z.Status.ToString()))
                .ForMember(x => x.LogDate, opts => opts.MapFrom(z => z.LogDate.Value.Day + "." + z.LogDate.Value.Month + "." + z.LogDate.Value.Year));

            Mapper.CreateMap<SaveBugModel, Bug>()
                .ForMember(x => x.Status, opts => opts.MapFrom(z => (Status)z.Status))
                .ForMember(x => x.LogDate, opts => opts.MapFrom(z => z.LogDate.Value.Day  + "." + z.LogDate.Value.Month + "." + z.LogDate.Value.Year));
        }

        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection()
        {
            FakeRepository<Bug> fakeRepo = new FakeRepository<Bug>();

            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Id = 1,
                    Text = "TEST NEW BUG 1",
                    LogDate = new DateTime(2009, 11, 13),
                    Status = Status.Assigned
                },
                new Bug()
                {
                    Id = 23,
                    Text = "TEST NEW BUG 2",
                    LogDate = new DateTime(2010, 1, 25),
                    Status = Status.Pending
                },
                new Bug()
                {
                    Id = 21,
                    Text = "TEST NEW BUG 3",
                    LogDate = new DateTime(2012, 5, 5),
                    Status = Status.Pending
                }
            };

            fakeRepo.Entities = bugs;

            var controller = new BugsController(fakeRepo as IRepository<Bug>);
            fakeRepo.All();
            var result = controller.GetAll().ToList<ResponseBugModel>();

            var expected = bugs.AsQueryable().ProjectTo<ResponseBugModel>().ToList<ResponseBugModel>(); 

            //// To work override Equals on Response Model!
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsValid_ShouldBeAddedToRepoWithLogDateAndStatusPending()
        {
            var repo = new FakeRepository<Bug>();
            repo.IsSaveCalled = false;
            repo.Entities = new List<Bug>();
            var bug = new SaveBugModel()
            {
                Text = "NEW TEST BUG"
            };
            var controller = new BugsController(repo);
            this.SetupController(controller);

            controller.PostBug(bug);

            Assert.AreEqual(repo.Entities.Count, 1);
            var bugInDb = repo.Entities.First();
            Assert.AreEqual(bug.Text, bugInDb.Text);
            Assert.IsNotNull(bugInDb.LogDate);
            Assert.AreEqual(Status.Pending, bugInDb.Status);
            Assert.IsTrue(repo.IsSaveCalled);
        }

        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection_WithMocks()
        {
            var repo = Mock.Create<IRepository<Bug>>();

            Bug[] bugs =
            {
                new Bug() { Id = 200, Text = "Bug1", Status = Status.Pending, LogDate = new DateTime(2011, 6, 5) },
                new Bug() { Id = 21, Text = "Bug2", Status = Status.Pending, LogDate = new DateTime(2013, 6, 2) }
            };

            Mock.Arrange(() => repo.All())
                .Returns(() => bugs.AsQueryable());

            var controller = new BugsController(repo);
            var result = controller.GetAll().ToArray<ResponseBugModel>();

            var expected = bugs.AsQueryable().ProjectTo<ResponseBugModel>().ToArray();
            CollectionAssert.AreEquivalent(expected, result);
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            //// Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            //// Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            //// Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "bugs" }
                    });
        }
    }
}