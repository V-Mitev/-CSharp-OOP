namespace Raiding.IO
{
    using Interface;

    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}