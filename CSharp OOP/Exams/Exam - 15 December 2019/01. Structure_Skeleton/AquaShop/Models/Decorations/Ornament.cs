namespace AquaShop.Models
{
    using Decorations.Contracts;

    public class Ornament : Decoration, IDecoration
    {
        private const int InitializeComfort = 1;
        private const decimal InitializePrice = 5;

        public Ornament() 
            : base(InitializeComfort, InitializePrice)
        {
        }
    }
}
