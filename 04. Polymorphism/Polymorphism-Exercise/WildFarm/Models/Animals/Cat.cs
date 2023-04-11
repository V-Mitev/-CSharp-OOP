namespace WildFarm.Models.Animals
{
    using Food;

    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.3;

        public Cat(string name, double weight, string livingZone, string breed) 
            : base(name, weight, livingZone, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
         => new HashSet<Type>() { typeof(Vegetable), typeof(Meat) };

        protected override double WeightMultiplier
        => CatWeightMultiplier;

        public override string ProduceSound() => "Meow";
    }
}