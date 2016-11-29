using System;
using System.Collections.Generic;

namespace Patterns_Design.Creation.Builder
{
    public class VeloByke:IVehicleBuilder
    {
        Dictionary<string, string>  vehicle = new Dictionary<string, string>();
        public void BuildFrame()
        {
            Console.WriteLine("VeloByke build Frame");
            vehicle["frame"] = "VeloFrame";
        }

        public void BuildEngine()
        {
            vehicle["engine"] = string.Empty;
        }

        public void BuildWheels()
        {
            Console.WriteLine("VeloByke build Wheels");
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