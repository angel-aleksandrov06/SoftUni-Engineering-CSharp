namespace PetStore.ServiceModels.Products.InputModels
{
    using PetStore.Common;
    using PetStore.Models.Enumerations;
    using System.ComponentModel.DataAnnotations;

    public class AddProductInputServiceModel
    {
        [Required]
        [MinLength(GlobalConstants.ProductNameMinLength)]
        [MaxLength(GlobalConstants.ProductNameMinLength)]
        public string Name { get; set; }

        [Range(GlobalConstants.ProductMinPrice, GlobalConstants.ProductMaxPrice)]
        public decimal Price { get; set; }

        public ProductType ProductType { get; set; }
    }
}
