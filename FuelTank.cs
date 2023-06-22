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
        private double fuelLevel;

        public FuelTank(double fuelLevel)
        {
            this.fuelLevel = fuelLevel;
        }

        public double FillLevel
        {
            get
            {
                return fuelLevel;
            }
        }

        public bool IsComplete
        {
            get
            {
                if (fuelLevel == 60)
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
                if (fuelLevel <= 10)
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
        }

        public void Refuel(double liters)
        {
            fuelLevel += liters;
            if (fuelLevel > 60)
            {
                fuelLevel = 60;
            }
        }
    }
}