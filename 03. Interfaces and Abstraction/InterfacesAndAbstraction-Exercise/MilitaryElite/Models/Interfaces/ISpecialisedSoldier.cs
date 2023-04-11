namespace MilitaryElite.Models.Interfaces
{
    using Enums;

    public interface ISpecialisedSoldier : ISoldier
    {
        Corps Corps { get; }
    }
}