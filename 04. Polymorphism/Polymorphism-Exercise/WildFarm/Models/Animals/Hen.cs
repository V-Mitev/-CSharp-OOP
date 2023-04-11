namespace WildFarm.Models.Animals
{
    using Food;

    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type>() { typeof(Meat), typeof(Seeds), typeof(Vegetable), typeof(Fruit) };

        protected override double WeightMultiplier => HenWeightMultiplier;

        public override string ProduceSound() => "Cluck";
    }
}