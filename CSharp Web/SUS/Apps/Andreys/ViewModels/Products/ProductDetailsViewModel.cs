namespace Andreys.ViewModels.Products
{
    using Andreys.Data;

    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public string CategoryAsString => this.Category.ToString();

        public Gender Gender { get; set; }

        public string GenderAsString => this.Gender.ToString();
    }
}
