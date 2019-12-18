namespace AquaShop.Models.Fish
{
    using Contracts;

    public class SaltwaterFish : Fish, IFish
    {
        private const int initializeSize = 5;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            base.Size = initializeSize;
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
