namespace _07FoodShortage
{
    public class Person : IPerson, IBuyer
    {
        public Person(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }

        public int Food { get; set; } = 0;

        public void BuyFood()
        {
            this.Food = this.Food + 10;
        }
    }
}
