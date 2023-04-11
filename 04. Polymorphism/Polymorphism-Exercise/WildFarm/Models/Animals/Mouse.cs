namespace WildFarm.Models.Animals
{
    using Food;

    public class Mouse : Mammal
    {
        private const double MouseWeightMultiplier = 0.1;

        public Mouse(string name, double weight, string livingZone)
            : base(name, weight, livingZone)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit)};

        protected override double WeightMultiplier => MouseWeightMultiplier;

        public override string ProduceSound() => "Squeak";

        public override string ToString()
        => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}