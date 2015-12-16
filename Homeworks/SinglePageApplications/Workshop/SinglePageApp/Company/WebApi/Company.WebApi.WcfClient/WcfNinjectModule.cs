namespace Company.WebApi.WcfClient
{
    using System.Data.Entity;
    
    using Company.Data;
    using Company.Data.Units;

    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    public class WcfNinjectModule : NinjectModule
    {
        public override void Load()
        {
            // TODO: Replace Name project
            // Suggest: extract in common project that hold constants.
            this.Kernel.Bind(x => x.From("Company.Data").SelectAllClasses().BindDefaultInterfaces());
            this.Kernel.Bind<DbContext>().To<DefaultDbContext>();
        }
    }
}