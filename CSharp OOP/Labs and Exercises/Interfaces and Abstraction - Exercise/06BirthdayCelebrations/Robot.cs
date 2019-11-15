namespace _06BirthdayCelebrations
{
    using System;

    public class Robot : IRobot
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }

        public string Id { get; set; }
        public string Birthdate { get; set; } = null;
    }
}
