using System;

namespace Car
{
    interface IDrivingInformationDisplay
    {
      int ActualSpeed { get; }
    }

    class DrivingInformationDisplay : IDrivingInformationDisplay
    {
        IDrivingProcessor drivingProcessor;
        public DrivingInformationDisplay(IDrivingProcessor drivingProcessor) 
        {
            this.drivingProcessor = drivingProcessor;
        }

        public int ActualSpeed
        {
            get
            {
              return drivingProcessor.ActualSpeed;
            }
        }
    }
}