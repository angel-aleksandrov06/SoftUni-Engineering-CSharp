namespace _07FoodShortage
{
    public interface IPerson : ICitizen
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
