using THermostatEventsApp.Entitys;
using THermostatEventsApp.Helpers;

namespace THermostatEventsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start device...");
            Console.ReadKey();
            
            IDevice device = new Device();
            
            device.RunDevice();
            
            Console.ReadKey();

        }
        
    }
}