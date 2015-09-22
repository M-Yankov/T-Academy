namespace Mediator
{
    using System;

    public abstract class BaseMediator
    {
        public abstract void AddToControlCenter(AirCraftMachine plane);

        public abstract void Communicate(AirCraftMachine plane, int x, int y);

        public abstract void AllowToLand(AirCraftMachine plane);

    }
}
