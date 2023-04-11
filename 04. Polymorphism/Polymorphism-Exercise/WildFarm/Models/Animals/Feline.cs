namespace WildFarm.Models.Animals
{
    using Interfaces;

    public abstract class Feline : Mammal, IFeline
    {
        public Feline(string name, double weight, string livingZone, string breed) 
            : base(name, weight, livingZone)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
       => base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}