using System;

namespace constructionCar
{
    public interface IDrivingProcessor
    {
      int ActualSpeed { get; }

      void IncreaseSpeedTo(int speed);

      void ReduceSpeed(int speed);
    }

    class DrivingProcessor : IDrivingProcessor
    {
        public int ActualSpeed => throw new NotImplementedException();

        public void IncreaseSpeedTo(int speed)
        {
            throw new NotImplementedException();
        }

        public void ReduceSpeed(int speed)
        {
            throw new NotImplementedException();
        }
    }
}