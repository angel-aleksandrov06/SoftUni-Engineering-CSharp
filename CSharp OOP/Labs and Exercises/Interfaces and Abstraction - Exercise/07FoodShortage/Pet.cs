namespace _07FoodShortage
{
    class Pet : IPet
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }
        public string Id { get; set; } = null;
    }
}
