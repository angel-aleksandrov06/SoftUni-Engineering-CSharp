namespace PetStore.Services.Interfaces
{
    using PetStore.ServiceModels.Products.InputModels;
    using PetStore.ServiceModels.Products.OutputModels;
    using System.Collections.Generic;

    public interface IProductService
    {
        void AddProduct(AddProductInputServiceModel model);

        ICollection<ListAllProductsServiceModel> GetAll();

        ICollection<ListAllProductsByProductTypeServiceModel> ListAllProductType(string type);

        ICollection<ListAllProductsByNameServiceModel> SearchByName(string searchStr, bool caseSensitive);

        bool RemoveById(string id);

        bool RemoveByName(string name);

    }
}
