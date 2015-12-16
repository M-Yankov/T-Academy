namespace Company.WebApi.WcfClient
{
    using System;
    using System.ServiceModel.Activation;
    using System.Web.Routing;
    using Ninject;
    using Ninject.Extensions.Wcf;
    using Ninject.Web.Common;

    public class Global : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            RouteTable.Routes.Add(new ServiceRoute(string.Empty, new NinjectServiceHostFactory(), typeof(UsersService)));
            base.OnApplicationStarted();
        }

        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new WcfNinjectModule());
        }
    }
}
