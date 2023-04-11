namespace Telephony.Models
{
    using Interfaces;

    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(Char.IsDigit))
            {
                return "Invalid number!";
            }

            return $"Calling... {phoneNumber}";
        }

        public string Browse(string url)
        {
            if (!url.All(c => !Char.IsDigit(c)))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }
    }
}