namespace AquaShop.Models.Aquariums
{
    using Contracts;

    public class SaltwaterAquarium : Aquarium, IAquarium
    {
        private const int initializeCapacity = 25;

        public SaltwaterAquarium(string name) 
            : base(name, initializeCapacity)
        {
        }
    }
}
