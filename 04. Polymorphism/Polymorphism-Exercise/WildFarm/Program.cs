namespace WildFarm
{
    using Factories.Interfaces;
    using Factories;
    using IO.Interfaces;
    using IO;
    using Core;
    using Core.Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IAnimalFactory animalFactory = new AnimalFactory();
            IFoodFactory foodFactory = new FoodFactory();

            IEngine engine = new Engine(reader, writer, animalFactory, foodFactory);

            engine.Run();
        }
    }
}