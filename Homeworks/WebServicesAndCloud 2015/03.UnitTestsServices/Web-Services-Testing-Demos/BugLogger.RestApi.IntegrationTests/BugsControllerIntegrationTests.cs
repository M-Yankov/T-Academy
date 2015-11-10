namespace BugLogger.RestApi.IntegrationTests
{
    using System;
    using System.Linq;
    using System.Net;
    using AutoMapper;
    using BugLogger.DataLayer;
    using BugLogger.Repositories;
    using BugLogger.RestApi.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class BugsControllerIntegrationTests
    {
        private static Random rand = new Random();
        private string inMemoryServerUrl = "http://localhost:12345";

        [TestInitialize]
        public void Init()
        {
            Mapper.CreateMap<Bug, ResponseBugModel>()
                .ForMember(x => x.Status, opts => opts.MapFrom(z => z.Status.ToString()))
                .ForMember(x => x.LogDate, opts => opts.MapFrom(z => z.LogDate.Value.Day + "." + z.LogDate.Value.Month + "." + z.LogDate.Value.Year));

            Mapper.CreateMap<SaveBugModel, Bug>()
                .ForMember(x => x.Status, opts => opts.MapFrom(z => (Status)z.Status))
                .ForMember(x => x.LogDate, opts => opts.MapFrom(z => z.LogDate.Value.Day + "." + z.LogDate.Value.Month + "." + z.LogDate.Value.Year));
        }

        [TestMethod]
        public void GetAll_WhenBugsInDb_ShouldReturnStatus200AndNonEmptyContent()
        {
            IRepository<Bug> repo = Mock.Create<IRepository<Bug>>();

            Bug[] bugs =
            {
                new Bug
                {
                    Id = 1, 
                    LogDate = new DateTime(2013, 5, 5),
                    Status = Status.Pending,
                    Text = "Initial Bug found!"
                },
                new Bug 
                {
                    Id = 2, 
                    LogDate = new DateTime(2011, 1, 2),
                    Status = Status.Fixed,
                    Text = "TestBug"
                },
                new Bug 
                {
                    Id = 22, 
                    LogDate = new DateTime(2011, 1, 2),
                    Status = Status.Fixed,
                    Text = "TestBug"
                }
            };

            Mock.Arrange(() => repo.All())
                .Returns(() => bugs.AsQueryable());

            var server = new InMemoryHttpServer<Bug>(this.inMemoryServerUrl, repo);

            var response = server.CreateGetRequest("/api/bugs");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsValid_ShouldReturn201AndLocationHeader()
        {
            IRepository<Bug> repo = Mock.Create<IRepository<Bug>>();

            Bug bug = this.GetValidBug();

            Mock.Arrange(() => repo.Add(Arg.IsAny<Bug>()))
                    .Returns(() => bug);

            var server = new InMemoryHttpServer<Bug>(this.inMemoryServerUrl, repo);

            var response = server.CreatePostRequest("/api/bugs", bug);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsEmpty_ShouldReturn400()
        {
            IRepository<Bug> repo = Mock.Create<IRepository<Bug>>();

            Bug bug = new Bug()
            {
                Text = string.Empty
            };

            var server = new InMemoryHttpServer<Bug>(this.inMemoryServerUrl, repo);

            var response = server.CreatePostRequest("/api/bugs", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsNull_ShouldReturn400()
        {
            IRepository<Bug> repo = Mock.Create<IRepository<Bug>>();

            Bug bug = new Bug()
            {
                Text = null
            };

            var server = new InMemoryHttpServer<Bug>(this.inMemoryServerUrl, repo);

            var response = server.CreatePostRequest("/api/bugs", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private Bug GetValidBug()
        {
            return new Bug()
            {
                Id = rand.Next(1000, 2000),
                Text = "New Bug #" + rand.Next(1000, 2000),
                Status = (Status)rand.Next(1, 3),
                LogDate = new DateTime(2013, 12, 1)
            };
        }
    }
}