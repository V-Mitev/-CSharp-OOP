using MilitaryElite.Core;
using MilitaryElite.Core.Interfaces;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}