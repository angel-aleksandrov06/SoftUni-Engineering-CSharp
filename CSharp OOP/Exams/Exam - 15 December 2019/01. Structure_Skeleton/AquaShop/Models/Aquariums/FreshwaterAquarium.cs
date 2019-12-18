namespace AquaShop.Models.Aquariums
{
    using Contracts;

    public class FreshwaterAquarium : Aquarium, IAquarium
    {
        private const int initializeCapacity = 50;

        public FreshwaterAquarium(string name) 
            : base(name, initializeCapacity)
        {
        }
    }
}
