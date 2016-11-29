using System;
using System.Collections.Generic;

namespace Patterns_Design.Creation.Builder
{
    public class CarBuilder:IVehicleBuilder
    {
        Dictionary<string, string> vehicle = new Dictionary<string, string>();

        public void BuildFrame()
        {
            Console.WriteLine("Car build Frame");
            vehicle["frame"] = "CarFrame";
        }

        public void BuildEngine()
        {
            Console.WriteLine("Car build Engine");
            vehicle["engine"] = "CarEngine";
        }

        public void BuildWheels()
        {
            Console.WriteLine("Car build Wheels");
            vehicle["wheels"] = "4 wheels";
        }

        public void BuildDoors()
        {
            Console.WriteLine("Car build Doors");
            vehicle["door"] = "4 doors";
        }

        public Dictionary<string, string> GetObject()
        {
            return vehicle;
        }
    }
}