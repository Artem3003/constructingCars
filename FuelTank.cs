using System;

namespace Car
{
    interface IFuelTank
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }

        void Consume(double liters);

        void Refuel(double liters);
    }

    class FuelTank : IFuelTank
    {
        private const double tankCap = 60;
        private double fuelLevel;

        public FuelTank(double fuelLevel)
        {
            this.fuelLevel = fuelLevel;
        }

        public double FillLevel
        {
            get
            {
                return this.fuelLevel;
            }
        }

        public bool IsComplete
        {
            get
            {
                if (fuelLevel == tankCap)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsOnReserve
        {
            get
            {
                if (fuelLevel < 5)
                {
                    return true;
                }
                return false;
            }
        }

        public void Consume(double liters)
        {
            if (fuelLevel <= 0)
            {
                fuelLevel = 0;
            }
            fuelLevel -= liters;
            fuelLevel = Math.Round(fuelLevel, 10);
        }

        public void Refuel(double liters)
        {
            fuelLevel += liters;
            if (fuelLevel > tankCap)
            {
                fuelLevel = tankCap;
            }
        }
    }
}