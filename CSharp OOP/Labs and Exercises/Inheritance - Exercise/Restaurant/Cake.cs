namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double CakeGramas = 250;
        private const double CakeCalories = 1000;
        private const decimal CakePrice = 5;
        public Cake(string name)
            : base(name, CakePrice, CakeGramas, CakeCalories)
        {
        }
    }
}
