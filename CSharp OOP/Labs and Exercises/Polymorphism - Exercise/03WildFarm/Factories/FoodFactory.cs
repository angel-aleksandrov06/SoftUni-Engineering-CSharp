namespace _03WildFarm.Factories
{
    using Models.Foods;

    public static class FoodFactory
    {
        public static Food CreateFood(params string[] foodArgs)
        {
            string type = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            switch (type)
            {
                case nameof(Fruit):
                    return new Fruit(quantity);
                case nameof(Meat):
                    return new Meat(quantity);
                case nameof(Seeds):
                    return new Seeds(quantity);
                case nameof(Vegetable):
                    return new Vegetable(quantity);
                default:
                    return null;
            }
        }
    }
}
