using System;
using System.Linq;
using System.Collections.Generic;

namespace Car
{
    public interface IOnBoardComputer
    {
        int TripRealTime { get; }

        int TripDrivingTime { get; }

        int TripDrivenDistance { get; }

        int TotalRealTime { get; }

        int TotalDrivingTime { get; }

        int TotalDrivenDistance { get; }

        double TripAverageSpeed { get; }

        double TotalAverageSpeed { get; }

        int ActualSpeed { get; }

        double ActualConsumptionByTime { get; }

        double ActualConsumptionByDistance { get; }

        double TripAverageConsumptionByTime { get; }

        double TotalAverageConsumptionByTime { get; }

        double TripAverageConsumptionByDistance { get; }

        double TotalAverageConsumptionByDistance { get; }

        int EstimatedRange { get; }

        void ElapseSecond();

        void TripReset();

        void TotalReset();
    }

    class OnBoardComputer : IOnBoardComputer
    {
        private IDrivingProcessor drivingProcessor;
        private IFuelTank fuelTank;

        private List<double> tripConsumptionHistory; // list of trip consumption
        private List<double> totalConsumptionHistory; // list of total consumption
        private List<int> tripSpeedHistory; // list of trip speed
        private List<int> totalSpeedHistory; // list of total speed
        private List<int> tripDistanceHistory; // list of trip distance
        private List<int> totalDistanceHistory; // list of total distance
        private List<double> tripConsumptionByDistanceHistory; // list of trip consumtion by distance
        private List<double> totalConsumptionByDistanceHistory; // list of total consumption by distance
        private List<double> factoryAndTotalConsumptionByTime; // list of consumption by time for estimate range
        

        public OnBoardComputer(IDrivingProcessor drivingProcessor, IFuelTank fuelTank)
        {
            this.drivingProcessor = drivingProcessor;
            this.fuelTank = fuelTank;
            this.tripConsumptionHistory = new List<double>();
            this.totalConsumptionHistory = new List<double>();
            this.tripSpeedHistory = new List<int>();
            this.totalSpeedHistory = new List<int>();
            this.tripDistanceHistory = new List<int>();
            this.totalDistanceHistory = new List<int>();
            this.tripConsumptionByDistanceHistory = new List<double>();
            this.totalConsumptionByDistanceHistory = new List<double>();
            this.factoryAndTotalConsumptionByTime = new List<double>();
            factoryAndTotalConsumptionByTime.AddRange(Enumerable.Repeat(4.8, 100).ToList());
        }

        public int TripRealTime => tripSpeedHistory.Count;
        public int TripDrivingTime => tripSpeedHistory.Count(s => s > 0);
        public int TripDrivenDistance => tripDistanceHistory.Sum();
        public int TotalRealTime => totalSpeedHistory.Count;
        public int TotalDrivingTime => totalSpeedHistory.Count(s => s > 0);
        public int TotalDrivenDistance => totalDistanceHistory.Sum();
        public double TripAverageSpeed => tripSpeedHistory.Sum() / (double)tripSpeedHistory.Count(s => s > 0);
        public double TotalAverageSpeed => totalSpeedHistory.Sum() / (double)totalSpeedHistory.Count(s => s > 0);
        public int ActualSpeed => drivingProcessor.ActualSpeed;
        public double ActualConsumptionByTime => tripConsumptionHistory.Count == 0 ? 0 : tripConsumptionHistory.Last();
        public double ActualConsumptionByDistance => (tripDistanceHistory.Count == 0 || tripDistanceHistory.Last() == 0) ? double.NaN : 100.0 * tripConsumptionHistory.Last() / (tripDistanceHistory.Last() / 3600.0);
        public double TripAverageConsumptionByTime => tripConsumptionHistory.Count > 0 ? tripConsumptionHistory.Sum() / tripConsumptionHistory.Count : 0;
        public double TotalAverageConsumptionByTime => totalConsumptionHistory.Count > 0 ? totalConsumptionHistory.Sum() / totalConsumptionHistory.Count : 0;
        public double TripAverageConsumptionByDistance => tripConsumptionByDistanceHistory.Count > 0 ? tripConsumptionByDistanceHistory.Average() : 0;
        public double TotalAverageConsumptionByDistance => totalConsumptionByDistanceHistory.Count > 0 ? totalConsumptionByDistanceHistory.Average() : 0;
        public int EstimatedRange => (int)Math.Round((100 * fuelTank.FillLevel) / factoryAndTotalConsumptionByTime.Concat(tripConsumptionByDistanceHistory).ToList().TakeLast(100).Average() + 4.8 / 100.0);

        public void ElapseSecond()
        {
            tripSpeedHistory.Add(ActualSpeed);
            totalSpeedHistory.Add(ActualSpeed);

            tripConsumptionHistory.Add(drivingProcessor.ActualConsumption);
            totalConsumptionHistory.Add(drivingProcessor.ActualConsumption);

            tripDistanceHistory.Add(ActualSpeed);
            totalDistanceHistory.Add(ActualSpeed);

            if (!Double.IsNaN(ActualConsumptionByDistance))
            {
                tripConsumptionByDistanceHistory.Add(Math.Round(ActualConsumptionByDistance, 2));
                totalConsumptionByDistanceHistory.Add(Math.Round(ActualConsumptionByDistance, 2));
            }
            else if (drivingProcessor.ActualSpeed != 0)
            {
                tripConsumptionByDistanceHistory.Add(drivingProcessor.ActualConsumption);
                totalConsumptionByDistanceHistory.Add(drivingProcessor.ActualConsumption);
            }
        }

        public void TotalReset()
        {
            totalConsumptionHistory.Clear();
            totalSpeedHistory.Clear();
            totalDistanceHistory.Clear();
            totalConsumptionByDistanceHistory.Clear();
            factoryAndTotalConsumptionByTime.Clear();
        }

        public void TripReset()
        {
            tripConsumptionHistory.Clear();
            tripSpeedHistory.Clear();
            tripDistanceHistory.Clear();
            tripConsumptionByDistanceHistory.Clear();
        }
    }
}