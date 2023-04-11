namespace Raiding.Factories
{
    using Interface;
    using Models;
    using Models.Interface;

    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string name, string heroType)
        {
            switch (heroType)
            {
                case "Druid":
                    return new Druid(name);
                case "Rogue":
                    return new Rogue(name);
                case "Paladin":
                    return new Paladin(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}