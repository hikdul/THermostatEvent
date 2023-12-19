using THermostatEventsApp.Helpers;

namespace THermostatEventsApp.Entitys
{
    public class CoolingMechanism : ICoolingMechanism
    {
        public void Off()
        {
            Console.WriteLine();
            action("OFF");
            Console.WriteLine();
        }

        public void On()
        {
            Console.WriteLine();
            action("ON");
            Console.WriteLine();
        }
        
        void action(string act)
        {

            Console.WriteLine($" >> Swetching cooling mechanism {act} << ");
        }
    }
}