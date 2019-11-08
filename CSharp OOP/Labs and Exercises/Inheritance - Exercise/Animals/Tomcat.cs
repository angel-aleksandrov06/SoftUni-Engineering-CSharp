namespace Animals
{
    public class Tomcat : Cat
    {
        private const string DefautGender = "male";

        public Tomcat(string name, int age)
            : base(name, age, DefautGender)
        {
        }
        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
