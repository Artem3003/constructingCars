using System;

namespace Car
{
    interface IDrivingProcessor
    {
        double ActualConsumption { get; }
        int ActualSpeed { get; }
        
        void EngineStart();

        void EngineStop();
        void IncreaseSpeedTo(int speed);

        void ReduceSpeed(int speed);
    }

    class DrivingProcessor : IDrivingProcessor
    {
        private const int maxSpeed = 250;
        private const int maxBraking = 10; 
        
        private IEngine engine;
        private int maxAcceleration;
        private int actualSpeed;
        private double actualConsumption;

        public DrivingProcessor(IEngine engine, int maxAcceleration)
        {
            this.engine = engine;
            // this.actualSpeed = 0;
            this.maxAcceleration = maxAcceleration;
            this.actualConsumption = 0;

            if (maxAcceleration > 20)
            {
                this.maxAcceleration = 20;
            }
            if (maxAcceleration < 5)
            {
                this.maxAcceleration = 5;
            }
        }

        public int ActualSpeed
        {
            get
            {
              return this.actualSpeed;
            }
        }

        public double ActualConsumption => actualConsumption;

        public void EngineStart()
        {
            actualConsumption = 0; 
        }

        public void EngineStop()
        {
            actualConsumption = 0;
        }

        public void IncreaseSpeedTo(int speed)
        {
            if (!engine.IsRunning)
            {
                return;
            }

            if (speed < actualSpeed)
            {
                actualSpeed--;
            }

            if (actualSpeed < speed)
            {
                actualSpeed = Math.Min(speed, actualSpeed + maxAcceleration);
            }
            
            if (actualSpeed > maxSpeed)
            {
                actualSpeed = maxSpeed;
            }
            actualConsumption = FuelConsuption(ActualSpeed);
            engine.Consume(actualConsumption);
        }

        public void ReduceSpeed(int speed)
        {
            if (!engine.IsRunning)
            {
                return;
            }

            actualSpeed -= Math.Min(speed, maxBraking);

            if (speed == 1)
            {
                actualConsumption = 0;
            }

            if (actualSpeed <= 0)
            {
                actualSpeed = 0;
                actualConsumption = 0.0003;
                engine.Consume(ActualConsumption);
            } else
            {
                actualConsumption = 0;
            }
        }

        // enter consumption for a driving car (liter/second)
        private double FuelConsuption(int actualSpeed)
        {
            switch (actualSpeed)
            {
                case <= 60:
                    return 0.0020;
                case <= 100:
                    return 0.0014;
                case <=140:
                    return 0.0020;
                case <= 200:
                    return 0.0025;
                case <= 250:
                    return 0.0030;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}