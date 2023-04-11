namespace WildFarm.Models.Animals
{
    using Food;

    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1;

        public Tiger(string name, double weight, string livingZone, string breed) 
            : base(name, weight, livingZone, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplier => TigerWeightMultiplier;

        public override string ProduceSound() => "ROAR!!!";
    }
}