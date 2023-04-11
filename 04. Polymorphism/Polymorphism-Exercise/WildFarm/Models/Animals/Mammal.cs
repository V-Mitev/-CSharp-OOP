namespace WildFarm.Models.Animals
{
    using Interfaces;

    public abstract class Mammal : Animal, IMammal
    {
        public Mammal(string name, double weight, string livingZone) 
            : base(name, weight)
        {
            LivingRegion = livingZone;
        }

        public string LivingRegion {get; private set;}
    }
}