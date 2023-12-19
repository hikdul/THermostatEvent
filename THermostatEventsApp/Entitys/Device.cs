using THermostatEventsApp.Helpers;

namespace THermostatEventsApp.Entitys
{
    public class Device : IDevice
    {
        const double WARNING_LEVEL = 27;
        const double EMERGENCY_LEVEL = 75;

        public double WarningTemperatureLevel => WARNING_LEVEL;

        public double EmergencyTemperatureLevel => EMERGENCY_LEVEL;

        public void HanleEmergency()
        {
            Console.WriteLine();
            Console.WriteLine("Sending out notifications to emergency services personal...");
            shutDownDevice();
            Console.WriteLine();
        }
        
        public void runDevice()
        {
            Console.WriteLine("Device is rinnig...");
            ICoolingMechanism coolingMechanism = new CoolingMechanism();
            IHeatSensor heatSensor = new HeatSenson(WARNING_LEVEL, EMERGENCY_LEVEL);
        }
        
        private void shutDownDevice()
        {
            Console.WriteLine("Shuting now this device");
        }
    }
}