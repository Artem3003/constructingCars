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
        private IFuelTank fuelTank;
        public FuelTankDisplay(IFuelTank fuelTank)
        {
            this.fuelTank = fuelTank;
        }
        public double FillLevel
        {
            get
            {
                return Math.Round(fuelTank.FillLevel, 2);
            }
        }

        public bool IsOnReserve => fuelTank.IsOnReserve;

        public bool IsComplete => fuelTank.IsComplete;
    }
}