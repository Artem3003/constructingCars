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
            this.fuelTank = new FuelTank(20);
            this.engine = new Engine(this.fuelTank);
            this.fuelTankDisplay = new FuelTankDisplay(this.fuelTank);
            this.drivingProcessor = new DrivingProcessor(engine, 10);
            this.drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            this.onBoardComputer = new OnBoardComputer(drivingProcessor, fuelTank);
            this.onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
        }

        public Car(double fuelLevel)
        {
            FuelLevelCheck(fuelLevel);
            this.engine = new Engine(fuelTank);
            this.fuelTankDisplay = new FuelTankDisplay(fuelTank);
            this.drivingProcessor = new DrivingProcessor(engine, 10);
            this.drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            this.onBoardComputer = new OnBoardComputer(drivingProcessor, fuelTank);
            this.onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
        }

        public Car(double fuelLevel, int maxAcceleration)
        {
            FuelLevelCheck(fuelLevel);
            this.engine = new Engine(fuelTank);
            this.fuelTankDisplay = new FuelTankDisplay(fuelTank);
            this.drivingProcessor = new DrivingProcessor(engine, maxAcceleration);
            this.drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            this.onBoardComputer = new OnBoardComputer(drivingProcessor, fuelTank);
            this.onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
        }

        public bool EngineIsRunning => engine.IsRunning;

        public void Accelerate(int speed)
        {
            if (EngineIsRunning)
            {
                drivingProcessor.IncreaseSpeedTo(speed);
                onBoardComputer.ElapseSecond(); // change info in on-board computer
            }
        }

        public void BrakeBy(int speed)
        {
            if (EngineIsRunning)
            {
                drivingProcessor.ReduceSpeed(speed);
                onBoardComputer.ElapseSecond(); // change info in on-board computer
            }
        }

        public void EngineStart()
        {
            if (!EngineIsRunning)
            {
                engine.Start();
                drivingProcessor.EngineStart(); // make actual consumption 0
                onBoardComputer.ElapseSecond(); // change info in on-board computer
            }
        }

        public void EngineStop()
        {
            if (EngineIsRunning)
            {
                engine.Stop();
                drivingProcessor.EngineStop(); // make actual consumption 0
                onBoardComputer.ElapseSecond(); // change info in on-board computer
                onBoardComputer.TripReset();
            }
        }

        public void FreeWheel()
        {
            if (EngineIsRunning)
            {
                if (drivingProcessor.ActualSpeed > 0)
                {
                    drivingProcessor.ReduceSpeed(1); // make actual consumption 0
                    onBoardComputer.ElapseSecond(); // change info in on-board computer
                } else
                {
                    RunningIdle();
                }
            }
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            if (EngineIsRunning)
            {
                drivingProcessor.ReduceSpeed(0); // make actual consumption 0.0003
                onBoardComputer.ElapseSecond(); // change info in on-board computer
            }
        }
        
        // check the correct fuel level
        private void FuelLevelCheck(double fuelLevel)
        {
            switch (fuelLevel)
            {
                case < 0:
                    this.fuelTank = new FuelTank(0);
                    break;
                case > 60:
                    this.fuelTank = new FuelTank(60);
                    break;
                default:
                    this.fuelTank = new FuelTank(fuelLevel); 
                    break;
            }
        }
    }
}