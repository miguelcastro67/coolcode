using System;
using System.Linq;
using System.Threading;

namespace CoolCode.EventSubscriberCollections
{
    public class OldEngine
    {
        public event EventHandler<EngineStartEventArgs> TurningOver;
        public event EventHandler<EngineStartEventArgs> TurnedOver;

        public void Start()
        {
            EngineStartEventArgs turningOverArgs = new EngineStartEventArgs()
            {
                Temperature = "C",
                OilPressure = "L"
            };

            TurningOver?.Invoke(this, turningOverArgs);

            // start engine
            Thread.Sleep(2000);

            EngineStartEventArgs turnedOverArgs = new EngineStartEventArgs()
            {
                Temperature = "W",
                OilPressure = "N"
            };

            TurnedOver?.Invoke(this, turnedOverArgs);
        }
    }
}
