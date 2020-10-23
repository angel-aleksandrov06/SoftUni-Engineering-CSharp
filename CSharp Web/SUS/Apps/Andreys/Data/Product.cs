namespace Andreys.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}
