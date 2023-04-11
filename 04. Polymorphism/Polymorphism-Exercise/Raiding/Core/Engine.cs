namespace Raiding.Core
{
    using Interface;
    using IO.Interface;
    using Models.Interface;
    using Factories.Interface;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;

        private readonly ICollection<IHero> heroes;

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;

            heroes = new List<IHero>();
        }

        public void Run()
        {
            int count = int.Parse(reader.ReadLine());

            while (count > 0)
            {
                try
                {
                    string heroName = reader.ReadLine();
                    string heroType = reader.ReadLine();

                    IHero hero = heroFactory.CreateHero(heroName, heroType);

                    heroes.Add(hero);

                    count--;
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            int bossPower = int.Parse(reader.ReadLine());

            int heroPower = heroes.Sum(h => h.Power);

            foreach (IHero hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            if (bossPower <= heroPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}