namespace AquaShop.Models.Fish
{
    using Contracts;

    public class FreshwaterFish : Fish, IFish
    {
        private const int initializeSize = 3;

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            base.Size = initializeSize;
        }

        public override void Eat()
        {
            this.Size += initializeSize;
        }
    }
}
