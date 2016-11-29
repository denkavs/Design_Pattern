using System.Collections.Generic;

namespace Patterns_Design.Creation.Builder
{
    public interface IVehicleBuilder
    {
        void BuildFrame();
        void BuildEngine();
        void BuildWheels();
        void BuildDoors();

        Dictionary<string, string> GetObject();
    }
}