using _04.PizzaCalories;

string[] pizzaInfo = Console.ReadLine().Split();

string pizzaName = pizzaInfo[1];

string[] doughInput = Console.ReadLine().Split();

string doughType = doughInput[1];
string bakingTechnique = doughInput[2];
int grams = int.Parse(doughInput[3]);

try
{
    Dough dough = new Dough(doughType.ToLower(), bakingTechnique.ToLower(), grams);
    Pizza pizza = new Pizza(pizzaName, dough);

    string input = Console.ReadLine();

    while (input != "END")
    {
        string[] toppinginfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string toppingType = toppinginfo[1];
        int weight = int.Parse(toppinginfo[2]);

        Topping topping = new Topping(weight, toppingType);

        pizza.AddTopping(topping);

        input = Console.ReadLine();
    }

    Console.WriteLine(pizza.ToString());
}
catch (ArgumentException ae )
{
    Console.WriteLine(ae.Message);
}