using THermostatEventsApp.Entitys;
using THermostatEventsApp.Helpers;

namespace THermostatEventsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ==> Start App <==");
            Console.WriteLine("Press Any key to start device...");
            Console.ReadKey();
            
            IDevice device = new Device();
            
            device.runDevice();

        }
        
    }
}