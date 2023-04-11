namespace Raiding.Factories.Interface
{
    using Models.Interface;

    public interface IHeroFactory
    {
        IHero CreateHero(string name, string heroType);
    }
}