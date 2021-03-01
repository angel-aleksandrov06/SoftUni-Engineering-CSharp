namespace CarShop.Services
{
    using CarShop.ViewModels.Cars;
    using System.Collections.Generic;

    public interface ICarsService
    {
        void Create(AddCarInputModel input, string userId);

        IEnumerable<ListAllCarsViewModel> GetAll(string userId);
    }
}
