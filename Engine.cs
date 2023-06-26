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
        private bool isRunning = false;
        private IFuelTank fuelTank;

        public Engine(IFuelTank fuelTank)
        {
            this.fuelTank = fuelTank;
        }

        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
        }

        public void Consume(double liters)
        {
            if (isRunning)
            {
                fuelTank.Consume(liters);
                if (fuelTank.FillLevel < 0)
                {
                    isRunning = false;
                }
            }
        }

        public void Start()
        {
            isRunning = true;
            if (fuelTank.FillLevel == 0)
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