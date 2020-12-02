using System;
using System.Linq;

namespace CoolCode.EventSubscriberCollections
{
    public class EngineStartEventArgs : EventArgs
    {
        public string Temperature { get; set; }
        public string OilPressure { get; set; }
    }
}
