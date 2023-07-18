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

        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
        }

        public void Consume(double liters)
        {
            if (isRunning)
            {
                fuelTank.Consume(liters);
                if (fuelTank.FillLevel <= 0)
                {
                    Stop();
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