namespace BullsAndCows.UsersService
{
    using Ninject;
    using Ninject.Web.Common;

    public class Global : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new WcfNinjectModule());
        }
    }
}