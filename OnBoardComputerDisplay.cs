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
        private IOnBoardComputer onBoardComputer;
        public OnBoardComputerDisplay(IOnBoardComputer onBoardComputer)
        {
            this.onBoardComputer = onBoardComputer;
        }

        public int TripRealTime => onBoardComputer.TripRealTime;
        public int TripDrivingTime => onBoardComputer.TripDrivingTime;
        public double TripDrivenDistance => Math.Round(onBoardComputer.TripDrivenDistance / 3600.0, 2);
        public int TotalRealTime => onBoardComputer.TotalRealTime;
        public int TotalDrivingTime => onBoardComputer.TotalDrivingTime;
        public double TotalDrivenDistance => Math.Round(onBoardComputer.TotalDrivenDistance / 3600.0, 2);
        public int ActualSpeed => onBoardComputer.ActualSpeed;
        public double TripAverageSpeed => Math.Round(onBoardComputer.TripAverageSpeed, 1);
        public double TotalAverageSpeed => Math.Round(onBoardComputer.TotalAverageSpeed, 1);
        public double ActualConsumptionByTime => Math.Round(onBoardComputer.ActualConsumptionByTime, 5);
        public double ActualConsumptionByDistance => Math.Round(onBoardComputer.ActualConsumptionByDistance, 1);
        public double TripAverageConsumptionByTime => Math.Round(onBoardComputer.TripAverageConsumptionByTime, 5);
        public double TotalAverageConsumptionByTime => Math.Round(onBoardComputer.TotalAverageConsumptionByTime, 5);
        public double TripAverageConsumptionByDistance => Math.Round(onBoardComputer.TripAverageConsumptionByDistance, 1);
        public double TotalAverageConsumptionByDistance => Math.Round(onBoardComputer.TotalAverageConsumptionByDistance, 1);
        public int EstimatedRange => onBoardComputer.EstimatedRange;

        public void TotalReset()
        {
            onBoardComputer.TotalReset();
        }

        public void TripReset()
        {
            onBoardComputer.TripReset();
        }
    }
}