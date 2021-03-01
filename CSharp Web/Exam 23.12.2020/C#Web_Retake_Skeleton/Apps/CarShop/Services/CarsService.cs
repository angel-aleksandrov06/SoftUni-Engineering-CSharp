namespace CarShop.Services
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.ViewModels.Cars;
    using System.Collections.Generic;
    using System.Linq;

    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;

        public CarsService(
            ApplicationDbContext db, 
            IUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public void Create(AddCarInputModel input, string userId)
        {
            var car = new Car
            {
                Model = input.Model,
                OwnerId = userId,
                PictureUrl = input.Image,
                PlateNumber = input.PlateNumber,
                Year = int.Parse(input.Year)
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public IEnumerable<ListAllCarsViewModel> GetAll(string userId)
        {
            var isUserMechanic = this.usersService.IsUserMechanic(userId);

            if (isUserMechanic)
            {
                return this.db.Cars
                    .Where(x => x.Issues.Count(y => y.IsFixed == false) > 0)
                    .Select(x => new ListAllCarsViewModel
                    {
                        Id = x.Id,
                        Model = x.Model,
                        ImageUrl = x.PictureUrl,
                        PlateNumber = x.PlateNumber,
                        Year = x.Year.ToString(),
                        FixedIssues = x.Issues.Count(y => y.IsFixed == true).ToString(),
                        UnFixedIssues = x.Issues.Count(y => y.IsFixed == false).ToString(),
                    }).ToList();
            }
            else
            {
                var cars = this.db.Cars
                    .Where(x => x.OwnerId == userId)
                    .Select(x => new ListAllCarsViewModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    ImageUrl = x.PictureUrl,
                    PlateNumber = x.PlateNumber,
                    Year = x.Year.ToString(),
                    FixedIssues = x.Issues.Count(y => y.IsFixed == true).ToString(),
                    UnFixedIssues = x.Issues.Count(y => y.IsFixed == false).ToString(),
                }).ToList();

                return cars;
            }
        }
    }
}
