namespace _03WildFarm.Models.Animals
{
    public static class AnimalFactory
    {
        public static Animal Create(params string[] animalArgs)
        {
            string type = animalArgs[0];
            string name = animalArgs[1];
            double weiht = double.Parse(animalArgs[2]);

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(animalArgs[3]);

                return new Hen(name, weiht, wingSize);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(animalArgs[3]);

                return new Owl(name, weiht, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = animalArgs[3];

                return new Mouse(name, weiht, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = animalArgs[3];

                return new Dog(name, weiht, livingRegion);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                return new Cat(name, weiht, livingRegion, breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                return new Tiger(name, weiht, livingRegion, breed);
            }

            return null;
        }
    }
}
