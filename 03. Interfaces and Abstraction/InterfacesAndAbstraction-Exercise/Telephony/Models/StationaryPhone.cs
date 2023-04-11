namespace Telephony.Models
{
    using Interfaces;

    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(Char.IsDigit))
            {
                return "Invalid number!";
            }

            return $"Dialing... {phoneNumber}";
        }
    }
}