using THermostatEventsApp.Helpers;

namespace THermostatEventsApp.Entitys
{
    public class Thermostat : IThermostat
    {
        private ICoolingMechanism _coolingMechanism = null;
        private IHeatSensor _heatSensor = null;
        private IDevice _device = null;
        private const double WarningLevel = 27;
        private const double EmergencyLevel = 75;
        
        public Thermostat(IDevice device, IHeatSensor heatSensor, ICoolingMechanism coolingMechanism)
        {
            this._device = device;
            this._coolingMechanism = coolingMechanism;
            this._heatSensor = heatSensor;
        }
        
        private void WireUpEventsToEventHandlers()
        {
            _heatSensor.TemperatureReachesWarningLevelEventHandler += HeatSensor_TemperatureReachesWarningLevelEventHandler;
            _heatSensor.TemperatureFallsBolowWarningLevelEventHandler += HeatSensor_TemperatureFallsBelowWarningLevelEventHandler;
            _heatSensor.TemperatureReachesEmergencyLevelEventHandler += HeatSensor_TemperatureReachesEmergencyLevelEventHandler;
        }
        
        private void HeatSensor_TemperatureReachesWarningLevelEventHandler(object sender, TemperatureEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine($"Warning Alert!! (warning Level is between {_device.WarningTemperatureLevel}°C and {_device.EmergencyTemperatureLevel}°C)");
            _coolingMechanism.On();
            Console.ResetColor();
        }
        private void HeatSensor_TemperatureFallsBelowWarningLevelEventHandler(object sender, TemperatureEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"Infarmation Alert!! temperaturo falls below warning level({_device.WarningTemperatureLevel}°C).");
            _coolingMechanism.Off();
            Console.ResetColor();
        }
        private void HeatSensor_TemperatureReachesEmergencyLevelEventHandler(object sender, TemperatureEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"Emergency Alert!! (Emergency Level is {_device.EmergencyTemperatureLevel}°C or above).");
            _device.HanleEmergency();
            Console.ResetColor();
        }

        public void RunThermostat()
        {
            Console.WriteLine("thermostat is running...");
            WireUpEventsToEventHandlers();
            _heatSensor.RunHeadSensor();
        }
    }
}