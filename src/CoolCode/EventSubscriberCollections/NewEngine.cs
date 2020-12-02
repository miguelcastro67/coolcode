using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CoolCode.EventSubscriberCollections
{
    public class NewEngine
    {
        #region event member variables

        event EventHandler<EngineStartEventArgs> _TurningOver;
        event EventHandler<EngineStartEventArgs> _TurnedOver;

        #endregion

        #region subscriber collections

        List<EventHandler<EngineStartEventArgs>> _TurningOverSubscribers = new List<EventHandler<EngineStartEventArgs>>();
        List<EventHandler<EngineStartEventArgs>> _TurnedOverSubscribers = new List<EventHandler<EngineStartEventArgs>>();

        #endregion

        #region events

        public event EventHandler<EngineStartEventArgs> TurningOver
        {
            add
            {
                if (!_TurningOverSubscribers.Contains(value))
                {
                    _TurningOver += value;
                    _TurningOverSubscribers.Add(value);
                }
            }
            remove
            {
                _TurningOver -= value;
                _TurningOverSubscribers.Remove(value);
            }
        }

        public event EventHandler<EngineStartEventArgs> TurnedOver
        {
            add
            {
                if (!_TurnedOverSubscribers.Contains(value))
                {
                    _TurnedOver += value;
                    _TurnedOverSubscribers.Add(value);
                }
            }
            remove
            {
                _TurnedOver -= value;
                _TurnedOverSubscribers.Remove(value);
            }
        }

        #endregion

        public void Start()
        {
            EngineStartEventArgs turningOverArgs = new EngineStartEventArgs()
            {
                Temperature = "C",
                OilPressure = "L"
            };

            _TurningOver?.Invoke(this, turningOverArgs);

            // start engine
            Thread.Sleep(2000);

            EngineStartEventArgs turnedOverArgs = new EngineStartEventArgs()
            {
                Temperature = "W",
                OilPressure = "N"
            };

            _TurnedOver?.Invoke(this, turnedOverArgs);
        }
    }
}
