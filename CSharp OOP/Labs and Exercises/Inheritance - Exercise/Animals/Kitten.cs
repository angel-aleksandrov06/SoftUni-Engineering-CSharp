namespace Animals
{
    public class Kitten : Cat
    {
        private const string DefautGender = "female";
        public Kitten(string name, int age)
            : base(name, age, DefautGender)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
