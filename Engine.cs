using System;

namespace Car
{
    interface IEngine
    {
        bool IsRunning { get; }

        void Consume(double liters);

        void Start();

        void Stop();
    }

    class Engine : IEngine
    {
        public bool IsRunning => throw new NotImplementedException();

        public void Consume(double liters)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }

}