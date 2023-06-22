using System;

namespace Car
{
    interface IFuelTankDisplay
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }
    }

    class FuelTankDisplay : IFuelTankDisplay
    {
        public double FillLevel => throw new NotImplementedException();

        public bool IsOnReserve => throw new NotImplementedException();

        public bool IsComplete => throw new NotImplementedException();
    }
}