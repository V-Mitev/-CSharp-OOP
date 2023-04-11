namespace Raiding.Models.Interface
{
    public interface IHero
    {
        string Name { get; }

        int Power { get; }

        string CastAbility();
    }
}