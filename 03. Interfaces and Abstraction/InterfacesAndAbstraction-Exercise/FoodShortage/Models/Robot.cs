namespace FoodShortage.Models
{
    using Interfaces;

    public class Robot : IIdentifiable
    {
        public Robot(string id, string model)
        {
            Id = id;
            Model = model;
        }

        public string Model { get; set; }

        public string Id { get; set; }
    }
}