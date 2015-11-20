namespace BullsAndCows.UsersService
{
    using System.Data.Entity;
    using BullsAndCows.Data;
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    public class WcfNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //// IKernel kernel = new StandardKernel(); // Will throw! Bind exact
            //// kernel.Bind(b => b.From("BullsAndCows.Data").SelectAllClasses().BindDefaultInterfaces());
            this.Kernel.Bind(b => b.From("BullsAndCows.Data").SelectAllClasses().BindDefaultInterfaces());
            this.Kernel.Bind<DbContext>().To<BullsAndCowsDbContext>();
        }
    }
}