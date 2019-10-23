namespace HealthyHeaven
{
    public class Vegetable
    {
        private string name;
        private int calories;

        public Vegetable(string name, int calories)
        {
            Name = name;
            Calories = calories;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Calories
        {
            get { return calories; }
            set { calories = value; }
        }
        public override string ToString()
        {
            return $" - {this.Name} have {this.Calories} calories";
        }
    }
}
