using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Creation.Builder
{
    public class Shop
    {
        private Dictionary<string, string> vehicle;

        // Builder uses a complex series of steps
        public void Construct(IVehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
            vehicle = vehicleBuilder.GetObject();
        }

        public void ShowVehicle()
        {
            if (vehicle != null)
            {
                Console.WriteLine();
                Console.WriteLine("Car parameters:");
                Console.WriteLine(" Frame - {0}", vehicle["frame"]);
                Console.WriteLine(" Engine - {0}", vehicle["engine"]);
                Console.WriteLine(" Wheels - {0}", vehicle["wheels"]);
                Console.WriteLine(" Door - {0}", vehicle["door"]);
                
            }
        }
    }
}
