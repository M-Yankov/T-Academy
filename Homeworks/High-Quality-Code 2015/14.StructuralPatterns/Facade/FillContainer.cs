namespace Facade
{
    using System;

    public static class FillContainer
    {
        public static void WithAlcohol(Alcohol alchohol, Container container)
        {
            container.FilledWith = alchohol;

            // You can't fill whole container!;
            container.CurrentLiters = container.Liters - ((container.Liters * 10) / 100);
        }
    }
}
