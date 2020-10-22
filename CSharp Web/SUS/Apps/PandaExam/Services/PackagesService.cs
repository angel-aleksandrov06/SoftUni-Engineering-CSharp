namespace PandaExam.Services
{
    using PandaExam.Data;
    using PandaExam.ViewModels.Packages;
    using System.Linq;

    public class PackagesService : IPackagesService
    {
        private readonly IUsersService usersService;
        private readonly IRecieptsService recieptsService;
        private readonly ApplicationDbContext db;

        public PackagesService(IUsersService usersService, IRecieptsService recieptsService, ApplicationDbContext db)
        {
            this.usersService = usersService;
            this.recieptsService = recieptsService;
            this.db = db;
        }

        public void Create(CreateInputModel input)
        {
            var userId = this.usersService.GetUserIdByUsername(input.RecipientName);

            if (userId == null)
            {
                throw new System.Exception();
            }

            var package = new Package
            {
                Description = input.Description,
                Weigth = input.Weight,
                Status = PackageStatus.Pending,
                ShippingAddress = input.ShippingAddress,
                RecipientId = userId,
            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }

        public void Deliver(string id)
        {
            var package = this.db.Packages.FirstOrDefault(x => x.Id == id);

            if (package == null)
            {
                return;
            }

            package.Status = PackageStatus.Delivered;
            this.db.SaveChanges();

            this.recieptsService.CreateFromPackage(package.Weigth, package.Id, package.RecipientId);
        }

        public IQueryable<Package> GetAllByStatus(PackageStatus status)
        {
            var packages = this.db.Packages.Where(x => x.Status == status);

            return packages;
        }
    }
}
