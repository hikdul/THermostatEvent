using THermostatEventsApp.Helpers;

namespace THermostatEventsApp.Entitys
{
    public class CoolingMechanism : ICoolingMechanism
    {
        public void Off()
        {
            Console.WriteLine();
            Console.WriteLine("Switching cooling mechanism off...");
            Console.WriteLine();
        }

        public void On()
        {
            Console.WriteLine();
            Console.WriteLine("Cooling mechanism is on...");
            Console.WriteLine();
        }
    }
}
