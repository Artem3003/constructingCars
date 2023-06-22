using System;

namespace constructionCar
{
    interface IDrivingInformationDisplay
    {
      int ActualSpeed { get; }
    }

    class DrivingInformationDisplay : IDrivingInformationDisplay
    {
        public int ActualSpeed => throw new NotImplementedException();
    }
}