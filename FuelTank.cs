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
        public double FillLevel => throw new NotImplementedException();

        public bool IsOnReserve => throw new NotImplementedException();

        public bool IsComplete => throw new NotImplementedException();

        public void Consume(double liters)
        {
            throw new NotImplementedException();
        }

        public void Refuel(double liters)
        {
            throw new NotImplementedException();
        }
    }   
}