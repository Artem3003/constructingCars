using System;

namespace Car
{
    interface ICar
    {
        bool EngineIsRunning { get; }

        void EngineStart();

        void EngineStop();

        void Refuel(double liters);

        void RunningIdle();
    }

    class Car : ICar
    {
        public bool EngineIsRunning => throw new NotImplementedException();

        public void EngineStart()
        {
            throw new NotImplementedException();
        }

        public void EngineStop()
        {
            throw new NotImplementedException();
        }

        public void Refuel(double liters)
        {
            throw new NotImplementedException();
        }

        public void RunningIdle()
        {
            throw new NotImplementedException();
        }
    }
}