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
        private int maxAcceleration;
        private int actualSpeed;

        public DrivingProcessor(int maxAcceleration)
        {
            this.actualSpeed = 0;
            this.maxAcceleration = maxAcceleration;
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

        public double ActualConsumption => throw new NotImplementedException();

        public void EngineStart()
        {
            throw new NotImplementedException();
        }

        public void EngineStop()
        {
            throw new NotImplementedException();
        }

        public void IncreaseSpeedTo(int speed)
        {
            if (actualSpeed < speed)
            {
                actualSpeed += maxAcceleration;
                if (actualSpeed > speed)
                {
                    actualSpeed = speed;
                }
            } else
            {
                actualSpeed--;
            }
            if (actualSpeed > 250)
            {
                actualSpeed = 250;
            }
        }

        public void ReduceSpeed(int speed)
        {
            if (actualSpeed > 0)
            {
                if (speed == 1)
                {
                    actualSpeed--;
                } else if (actualSpeed - speed < 10)
                {
                    actualSpeed -= (actualSpeed - speed);
                } else if (actualSpeed > speed)
                {
                    actualSpeed -= 10;
                }
            }
        }
    }
}