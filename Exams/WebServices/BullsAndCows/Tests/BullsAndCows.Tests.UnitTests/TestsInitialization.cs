namespace BullsAndCows.Tests.UnitTests
{
    using System;
    using BullsAndCows.WebApi;
    using BullsAndCows.WebApi.App_Start;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    
    [TestClass]
    public class TestsInitialization
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            // NinjectWebCommon.Start(); // If throws
            AutoMapperConfig.RegisterMappings("BullsAndCows.WebApi");
            MyWebApi.IsRegisteredWith(WebApiConfig.Register);
        }

        [AssemblyCleanup]
        public static void Clean()
        {
            NinjectWebCommon.Stop();
        }
    }
}
