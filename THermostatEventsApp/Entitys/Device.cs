using THermostatEventsApp.Helpers;

namespace THermostatEventsApp.Entitys
{
    public class Device : IDevice
    {
        const double Warning_Level = 27;
        const double Emergency_Level = 75;

        public double WarningTemperatureLevel => Warning_Level;

        public double EmergencyTemperatureLevel => Emergency_Level;

        public void HandleEmergency()
        {
            Console.WriteLine();
            Console.WriteLine("Sending out notifications to emergency services personal...");
            ShutDownDevice();
            Console.WriteLine();
        }

        public void RunDevice()
        {
            Console.WriteLine("Device is running...");

            ICoolingMechanism coolingMechanism = new CoolingMechanism();
            IHeatSensor heatSensor = new HeatSenson(Warning_Level, Emergency_Level);
            IThermostat thermostat = new Thermostat(this, heatSensor, coolingMechanism);

            thermostat.RunThermostat();
        }

        private void ShutDownDevice()
        {
            Console.WriteLine("Shutting down device...");
        }
    }
}
