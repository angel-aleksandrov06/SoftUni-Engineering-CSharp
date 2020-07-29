namespace PetStore.ServiceModels.Products.InputModels
{
    using PetStore.Common;
    using System.ComponentModel.DataAnnotations;

    public class EditProductInputServiceModel
    {
        [Required]
        [MinLength(GlobalConstants.ProductNameMinLength)]
        [MaxLength(GlobalConstants.ProductNameMinLength)]
        public string Name { get; set; }

        [Range(GlobalConstants.ProductMinPrice, GlobalConstants.ProductMaxPrice)]
        public decimal Price { get; set; }

        public string ProductType { get; set; }
    }
}
