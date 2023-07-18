using System;

namespace Car
{
    interface IEngine
    {
        bool IsRunning { get; }

        void Consume(double liters);

        void Start();

        void Stop();
    }

    class Engine : IEngine
    {
        private bool isRunning;
        private IFuelTank fuelTank;

        public Engine(IFuelTank fuelTank)
        {
            this.isRunning = false;
            this.fuelTank = fuelTank;
        }

        public bool IsRunning => isRunning;

        public void Consume(double liters)
        {
            if (isRunning)
            {
                fuelTank.Consume(liters); // consume fuel
                if (fuelTank.FillLevel <= 0) // If fuel = 0, car stops
                {
                    Stop();
                }
            }
        }

        public void Start()
        {
            isRunning = true;
            if (fuelTank.FillLevel == 0) // if fuel = 0, car doesn't drive
            {
                isRunning = false;
            }
        }

        public void Stop()
        {
            isRunning = false;
        }
    }
}