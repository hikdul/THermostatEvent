using System.ComponentModel;
using THermostatEventsApp.Helpers;

namespace THermostatEventsApp.Entitys
{
    public class HeatSenson : IHeatSensor
    {
        double _warningLevel = 0;
        double _emergencyLevel = 0;
        bool _hasReachedWarningTemperature = false;
        protected EventHandlerList _listEventDelegates = new EventHandlerList();
        // ?: EventHandlerList : leer mas sobre este elemento que se puede utilizar con delegados
            // -- --> https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.eventhandlerlist?view=net-8.0
        
        static readonly object _teperatureReachesWarningLevelKey = new object();
        static readonly object _temperatureFallsBelowWarningLevelKey = new object();
        static readonly object _temperatureReachesEmergencyLevelKey = new object();
        private double[] _teperatureData = null;



        public HeatSenson(double warn, double emergency)
        {
            this._warningLevel = warn;
            this._emergencyLevel = emergency;
            SeedData();
        }

        private void SeedData()
        {
            _teperatureData = new double[]{16,17,16,18,19.5,21,16,13,10,26,35,45,50,51,68,88,90,40,30,10,1.123,55.11};
        }
        
        public void MonitorTemperature()
        {
            foreach (var temp in _teperatureData)
            {
                Console.ResetColor();
                Console.WriteLine($"Moment: {DateTime.Now}, Temperature: {temp}");
                TemperatureEventArgs e = new (){ Temperature = temp, CurrentDateTime = DateTime.Now };

               if(temp >= _emergencyLevel)
               {
                    OnTemperatureReachesEmergencyLevelKey(e);
               }
               else if(temp >= _warningLevel)
               {
                    _hasReachedWarningTemperature = true;
                    OnTemperatureReachesWarningLevel(e);
               }
               else if(temp < _warningLevel && _hasReachedWarningTemperature)
               {
                    _hasReachedWarningTemperature = false;
                    OnTemperatureFallsBelowWarningLevelKey(e);
               }

               // --> Para que duerma un segundo con cada lectura y de la sensacion de que esta leyendo a cada paso
                System.Threading.Thread.Sleep(1000);
            }
        }
        
        protected void OnTemperatureReachesWarningLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> handler =(EventHandler<TemperatureEventArgs>)_listEventDelegates[_teperatureReachesWarningLevelKey];
            if(handler != null)
            {
                handler(this, e);
            }
        }
        protected void OnTemperatureReachesEmergencyLevelKey(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> handler =(EventHandler<TemperatureEventArgs>)_listEventDelegates[_temperatureReachesEmergencyLevelKey];
            if(handler != null)
            {
                handler(this, e);
            }
        }
        protected void OnTemperatureFallsBelowWarningLevelKey(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> handler =(EventHandler<TemperatureEventArgs>)_listEventDelegates[_temperatureFallsBelowWarningLevelKey];
            if(handler != null)
            {
                handler(this, e);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesEmergencyLevelEventHandler
        {
            add
            {
                _listEventDelegates.AddHandler(_temperatureReachesEmergencyLevelKey, value);
            }

            remove
            {
                _listEventDelegates.RemoveHandler(_temperatureReachesEmergencyLevelKey, value);
            }
        }
        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesWarningLevelEventHandler
        {
            add
            {
                _listEventDelegates.AddHandler(_teperatureReachesWarningLevelKey, value);
            }

            remove
            {
                _listEventDelegates.RemoveHandler(_teperatureReachesWarningLevelKey, value);
            }
        }
        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureFallsBolowWarningLevelEventHandler
        {
            add
            {
                _listEventDelegates.AddHandler(_temperatureFallsBelowWarningLevelKey, value);
            }

            remove
            {
                _listEventDelegates.RemoveHandler(_temperatureFallsBelowWarningLevelKey, value);
            }
        }

        public void RunHeadSensor()
        {
            Console.WriteLine("Heat Sensor is Running...");
            MonitorTemperature();
        }
    }
}