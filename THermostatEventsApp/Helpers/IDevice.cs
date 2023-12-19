namespace THermostatEventsApp.Helpers
{
    public interface IDevice
    {
        double WarningTemperatureLevel {get;}
        double EmergencyTemperatureLevel {get;}
        void runDevice();
        void HanleEmergency();
    }
}