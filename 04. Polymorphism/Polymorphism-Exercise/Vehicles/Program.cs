using Vehicles.IO.Interfaces;
using Vehicles.IO;
using Vehicles.Factories.Interfaces;
using Vehicles.Core;
using Vehicles.Factories;
using Vehicles.Core.Interfaces;

namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VehicleFactory();

            IEngine engine = new Engine(reader, writer, vehicleFactory);

            engine.Run();
        }
    }
}