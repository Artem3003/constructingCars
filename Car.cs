using System;

namespace Car
{
    interface ICar
    {
        bool EngineIsRunning { get; }

        void BrakeBy(int speed);

        void Accelerate(int speed);

        void EngineStart();

        void EngineStop();

        void FreeWheel();

        void Refuel(double liters);

        void RunningIdle();
    }

    class Car : ICar
    {
        public IDrivingInformationDisplay drivingInformationDisplay;
        public IFuelTankDisplay fuelTankDisplay;

        public IOnBoardComputerDisplay onBoardComputerDisplay;
        private IDrivingProcessor drivingProcessor;
        private IEngine engine;
        private IFuelTank fuelTank;
        
        private IOnBoardComputer onBoardComputer;

        public Car()
        {
            this.fuelTank = new FuelTank(0);
            this.engine = new Engine(this.fuelTank);
            this.fuelTankDisplay = new FuelTankDisplay(this.fuelTank);
            this.drivingProcessor = new DrivingProcessor(10);
            this.drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
        }

        public Car(double fuelLevel)
        {
            FuelLevelCheck(fuelLevel);
            this.engine = new Engine(fuelTank);
            this.fuelTankDisplay = new FuelTankDisplay(fuelTank);
            this.drivingProcessor = new DrivingProcessor(10);
            this.drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
        }

        public Car(double fuelLevel, int maxAcceleration)
        {
            FuelLevelCheck(fuelLevel);
            this.engine = new Engine(fuelTank);
            this.fuelTankDisplay = new FuelTankDisplay(fuelTank);
            this.drivingProcessor = new DrivingProcessor(maxAcceleration);
            this.drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
        }

        public bool EngineIsRunning
        {
            get
            {
                return engine.IsRunning;
            }
        }

        public void Accelerate(int speed)
        {
            if (engine.IsRunning)
            {
                drivingProcessor.IncreaseSpeedTo(speed);
                engine.Consume(FuelConsuption(drivingInformationDisplay.ActualSpeed));
            }
        }

        public void BrakeBy(int speed)
        {
            drivingProcessor.ReduceSpeed(speed);
        }

        public void EngineStart()
        {
            engine.Start();
        }

        public void EngineStop()
        {
            engine.Stop();
        }

        public void FreeWheel()
        {
            if (drivingProcessor.ActualSpeed > 0)
            {
                drivingProcessor.ReduceSpeed(1);
            } else
            {
                RunningIdle();
            }
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            engine.Consume(0.0003);
        }

        // enter consumption for a driving car (liter/second)
        private double FuelConsuption(int actualSpeed)
        {
            if (actualSpeed == 0)
            {
                return 0;
            }
            if (actualSpeed > 0 && actualSpeed < 61)
            {
                return 0.0020;
            }
            if (actualSpeed > 60 && actualSpeed < 101)
            {
                return 0.0014;
            }
            if (actualSpeed > 100 && actualSpeed < 141)
            {
                return 0.0020;
            }
            if (actualSpeed > 140 && actualSpeed < 201)
            {
                return 0.0025;
            }
            if (actualSpeed > 200 && actualSpeed < 251)
            {
                return 0.0030;
            }
            throw new ArgumentException("Your speed is defunct");
        }
        
        private void FuelLevelCheck(double fuelLevel)
        {
            if (fuelLevel >= 0 && fuelLevel <= 60)
            {
                this.fuelTank = new FuelTank(fuelLevel);        
            } else if (fuelLevel < 0)
            {
                this.fuelTank = new FuelTank(0);
            } else if (fuelLevel > 60)
            {
                this.fuelTank = new FuelTank(60);
            }
        }
    }
}