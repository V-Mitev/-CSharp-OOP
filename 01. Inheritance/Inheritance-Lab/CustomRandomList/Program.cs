namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("pesho");

            Console.WriteLine(list.RandomString());
        }
    }
}