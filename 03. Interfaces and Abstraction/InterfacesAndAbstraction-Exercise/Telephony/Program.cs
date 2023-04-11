using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            ICallable callable;

            foreach(var  phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 7)
                {
                    callable = new StationaryPhone();
                }
                else
                {
                    callable = new Smartphone();
                }

                try
                {
                    Console.WriteLine(callable.Call(phoneNumber));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            IBrowsable browsable = new Smartphone();

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(browsable.Browse(url));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}