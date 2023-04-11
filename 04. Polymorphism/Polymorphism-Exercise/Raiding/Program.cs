namespace Raiding
{
    using Core;
    using Core.Interface;
    using Factories;
    using Factories.Interface;
    using IO;
    using IO.Interface;

    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroFactory heroFactory = new HeroFactory();

            IEngine engine = new Engine(reader, writer, heroFactory);

            engine.Run();
        }
    }
}