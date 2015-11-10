namespace BugLogger.RestApi.Tests.MyWebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using BugLogger.DataLayer;
    using BugLogger.Repositories;
    using BugLogger.RestApi.App_Start;
    using BugLogger.RestApi.Controllers;
    using BugLogger.RestApi.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using MyTested.WebApi.Exceptions;
    using Telerik.JustMock;

    [TestClass]
    public class BugsControllerTestsHomework
    {
        [TestInitialize]
        public void Configure()
        {
            MapperConfig.RegisterMappings(Assembly.Load("BugLogger.RestApi"));
            MyWebApi.IsRegisteredWith(WebApiConfig.Register);
        }

        [TestMethod]
        public void TestRouteApiBugToCallProperAction()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/bugs")
                .To<BugsController>(c => c.GetAll());
        }

        [TestMethod]
        public void TestRouteWithQueryParametersToCallProperAction()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/bugs?count=2")
                .To<BugsController>(c => c.GetCount(2));
        }

        [TestMethod]
        public void TestRouteWithQueryParametersToCallByStartDataAction()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/bugs?date=2015-1-1")
                .To<BugsController>(c => c.GetBugsByStartDate(new DateTime(2015, 1, 1)));
        }

        [TestMethod]
        public void TestRouteWithQueryParametersToCallRangeDateAction()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/bugs?start=2013-1-1&end=2014-3-3")
                .To<BugsController>(c => c.GetBugsInRange(new DateTime(2013, 1, 1), new DateTime(2014, 3, 3)));
        }

        [TestMethod]
        public void TestRouteWithQueryParametersToGetByTypeAction()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/bugs?type=Pending")
                .To<BugsController>(c => c.GetByStatusType("Pending"));
        }

        [TestMethod]
        public void TestRouteWithInvalidQueryParametersToGetByTypeAction()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/bugs?type=Pesho")
                .To<BugsController>(c => c.GetByStatusType("Pesho"));
        }

        [TestMethod]
        [ExpectedException(typeof(RouteAssertionException))]
        public void TestRouteWithInvalidDatesQueryParametersToThrowAnException()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/bugs?date=Pesho")
                .To<BugsController>(c => c.GetBugsByStartDate(new DateTime()));
        }

        [TestMethod]
        [ExpectedException(typeof(RouteAssertionException))]
        public void TestRouteWithInvalidDateRangeQueryParametersToThrowAnException()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/bugs?date=2015-941-32")
                .To<BugsController>(c => c.GetBugsByStartDate(new DateTime()));
        }

        [TestMethod]
        public void TestRouteToMapGetRequestToBugs()
        {
            MyWebApi
                    .Routes()
                    .ShouldMap(request => request
                        .WithMethod(HttpMethod.Get)
                        .AndAlso()
                        .WithRequestUri("api/bugs"));
        }

        [TestMethod]
        public void TestRouteToMapPostMethodToBugs()
        {
            MyWebApi
                    .Routes()
                    .ShouldMap(request => request
                        .WithMethod(HttpMethod.Post)
                        .AndAlso()
                        .WithRequestUri("api/bugs"));
        }

        [TestMethod]
        public void TestRouteToMapPutMethodToBugsWithId()
        {
            MyWebApi
                    .Routes()
                    .ShouldMap("api/bugs/3")
                    .WithHttpMethod(HttpMethod.Put);
        }

        [TestMethod]
        public void TestRouteToNotMapPutMethodToBugsWithoutId()
        {
            MyWebApi
                    .Routes()
                    .ShouldMap("api/bugs")
                    .WithHttpMethod(HttpMethod.Put);
        }

        [TestMethod]
        public void TestPostShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/bugs")
                .WithHttpMethod(HttpMethod.Post)
                .And()
                .WithJsonContent(@"{""Text"": ""Adding Test Bug"", ""LogDate"":""5.5.2011"", ""Status"": ""Pending""}")
                .To<BugsController>(c => c.PostBug(new SaveBugModel
                {
                    Text = "Adding Test Bug",
                    Status = SaveStatus.Pending,
                    LogDate = new DateTime(2011, 5, 5, 0, 0, 0)
                }));

            //// Why zeros are necessary? In tests above can map date from stringQuery from without pass hours, minutes and seconds
        }
    }
}
