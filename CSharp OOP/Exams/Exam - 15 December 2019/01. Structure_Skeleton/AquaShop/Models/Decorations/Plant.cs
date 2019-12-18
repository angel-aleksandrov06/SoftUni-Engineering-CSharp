namespace AquaShop.Models
{
    using Decorations.Contracts;

    public class Plant : Decoration, IDecoration
    {
        private const int InitializeComfort = 5;
        private const decimal InitializePrice = 10;

        public Plant()
            : base(InitializeComfort, InitializePrice)
        {
        }
    }
}
