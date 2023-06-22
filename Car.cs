using System;

namespace Car
{
    interface ICar
    {
        bool EngineIsRunning { get; }

        void EngineStart();

        void EngineStop();

        void Refuel(double liters);

        void RunningIdle();
    }

    class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;

        private IEngine engine;

        private IFuelTank fuelTank;

        public Car()
        {
            this.fuelTank = new FuelTank(20);
            this.engine = new Engine(this.fuelTank);
            this.fuelTankDisplay = new FuelTankDisplay(this.fuelTank);
        }

        public Car(double fuelLevel)
        {
            if (fuelLevel >= 0 && fuelLevel <= 60)
            {
                this.fuelTank = new FuelTank(fuelLevel);
                this.engine = new Engine(fuelTank);
                this.fuelTankDisplay = new FuelTankDisplay(fuelTank);
            }
            this.fuelTank = new FuelTank(20);
            this.engine = new Engine(fuelTank);
            this.fuelTankDisplay = new FuelTankDisplay(fuelTank);
        }

        public bool EngineIsRunning
        {
            get
            {
                return engine.IsRunning;
            }
        }

        public void EngineStart()
        {
            engine.Start();
        }

        public void EngineStop()
        {
            engine.Stop();
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            engine.Consume(0.0003);
        }
    }
}