using System;

namespace Car
{
    public interface IOnBoardComputerDisplay
    {
        int TripRealTime { get; }
    
        int TripDrivingTime { get; }
    
        double TripDrivenDistance { get; }
    
        int TotalRealTime { get; }
    
        int TotalDrivingTime { get; }
    
        double TotalDrivenDistance { get; }
    
        int ActualSpeed { get; }
    
        double TripAverageSpeed { get; }
    
        double TotalAverageSpeed { get; }
    
        double ActualConsumptionByTime { get; }
    
        double ActualConsumptionByDistance { get; }
    
        double TripAverageConsumptionByTime { get; }
    
        double TotalAverageConsumptionByTime { get; }
    
        double TripAverageConsumptionByDistance { get; }
    
        double TotalAverageConsumptionByDistance { get; }
    
        int EstimatedRange { get; }
    
        void TripReset();
    
        void TotalReset();
    }

    class OnBoardComputerDisplay : IOnBoardComputerDisplay
    {
        public int TripRealTime => throw new NotImplementedException();

        public int TripDrivingTime => throw new NotImplementedException();

        public double TripDrivenDistance => throw new NotImplementedException();

        public int TotalRealTime => throw new NotImplementedException();

        public int TotalDrivingTime => throw new NotImplementedException();

        public double TotalDrivenDistance => throw new NotImplementedException();

        public int ActualSpeed => throw new NotImplementedException();

        public double TripAverageSpeed => throw new NotImplementedException();

        public double TotalAverageSpeed => throw new NotImplementedException();

        public double ActualConsumptionByTime => throw new NotImplementedException();

        public double ActualConsumptionByDistance => throw new NotImplementedException();

        public double TripAverageConsumptionByTime => throw new NotImplementedException();

        public double TotalAverageConsumptionByTime => throw new NotImplementedException();

        public double TripAverageConsumptionByDistance => throw new NotImplementedException();

        public double TotalAverageConsumptionByDistance => throw new NotImplementedException();

        public int EstimatedRange => throw new NotImplementedException();

        public void TotalReset()
        {
            throw new NotImplementedException();
        }

        public void TripReset()
        {
            throw new NotImplementedException();
        }
    }
}