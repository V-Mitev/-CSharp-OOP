namespace BirthdayCelebrations
{
    using Models;
    using Models.Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthdate> birthdates = new();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Pet")
                {
                    IBirthdate pet = new Pet(tokens[1], tokens[2]);

                    birthdates.Add(pet);
                }
                else if(tokens.Length == 5)
                {
                    IBirthdate citizen = new Citizen(tokens[1], int.Parse(tokens[2]),
                        tokens[3], tokens[4]);

                    birthdates.Add(citizen);
                }
            }

            string invalidIdSuffix = Console.ReadLine();

            foreach (var birthdate in birthdates)
            {
                if (birthdate.Birthdate.EndsWith(invalidIdSuffix))
                {
                    Console.WriteLine(birthdate.Birthdate);
                }
            }
        }
    }
}