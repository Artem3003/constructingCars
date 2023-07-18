using System;

namespace Car
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitTests unitTests = new UnitTests();
            
            unitTests.TestMotorStartAndStop();
            unitTests.TestFuelConsumptionOnIdle();            
            unitTests.TestFuelTankDisplayIsComplete();
            unitTests.TestFuelTankDisplayIsOnReserve();
            unitTests.TestRefuel();
            unitTests.TestStartSpeed();
            unitTests.TestFreeWheelSpeed();
            unitTests.TestAccelerateBy10();
            unitTests.TestBraking();
            unitTests.TestConsumptionSpeedUpTo30();
            unitTests.TestRealAndDrivingTimeBeforeStarting();
            unitTests.TestRealAndDrivingTimeAfterDriving();
            unitTests.TestActualSpeedBeforeDriving();
            unitTests.TestAverageSpeed1();
            unitTests.TestAverageSpeedAfterTripReset();
            unitTests.TestActualConsumptionEngineStart();
            unitTests.TestActualConsumptionRunningIdle();        
            unitTests.TestActualConsumptionAccelerateTo100();
            unitTests.TestActualConsumptionFreeWheel();
            unitTests.TestAverageConsumptionsAfterEngineStart();
            unitTests.TestAverageConsumptionsAfterAccelerating();
            unitTests.TestAverageConsumptionsAfterBraking();
            unitTests.TestDrivenDistancesAfterEngineStart();
            unitTests.TestDrivenDistancesAfterAccelerating();
            unitTests.TestEstimatedRangeAfterDrivingOptimumSpeedForMoreThan100Seconds();        }       
    }
}