using AquaShop.Models.Decorations.Contracts;


namespace AquaShop.Models
{
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
