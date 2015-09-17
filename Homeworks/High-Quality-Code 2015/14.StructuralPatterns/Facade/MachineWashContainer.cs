
namespace Facade
{
    using System;
    using System.Linq;

    public static class MachineWashContainer
    {
        public static void WashContainer(Container containerForAlcohol)
        {
            containerForAlcohol.CurrentLiters = 0;
        }
    }
}
