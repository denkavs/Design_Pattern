using System;
using System.Collections.Generic;

namespace Patterns_Design.Creation.Builder
{
    public class MotoByke:IVehicleBuilder
    {
        Dictionary<string, string> vehicle = new Dictionary<string, string>();

        public void BuildFrame()
        {
            vehicle["frame"] = "MotoFrame";
        }

        public void BuildEngine()
        {
            Console.WriteLine("MotoByke build Engine");
            vehicle["engine"] = "MotoEngine";
        }

        public void BuildWheels()
        {
            Console.WriteLine("MotoByke build Wheels");
            vehicle["wheels"] = "2 wheels";
        }

        public void BuildDoors()
        {
            vehicle["door"] = string.Empty;
        }

        public Dictionary<string, string> GetObject()
        {
            return vehicle;
        }
    }
}