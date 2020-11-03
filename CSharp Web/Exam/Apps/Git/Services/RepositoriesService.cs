namespace Git.Services
{
    using Git.Data;
    using Git.ViewModels.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;

        public RepositoriesService(ApplicationDbContext db, IUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public void Create(string name, string repositoryType, string userId)
        {
           bool isPublic;
            if (repositoryType == "Public")
            {
                isPublic = true;
            }
            else
            {
                isPublic = false;
            }

            var repository = new Repository
            {
                Name = name,
                IsPublic = isPublic,
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId,
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoriesAllViewModel> GetAll()
        {
            return this.db.Repositories.Where(x => x.IsPublic).Select(x => new RepositoriesAllViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Owner = x.Owner.Username,
                CreatedOn = x.CreatedOn,
                CommitsCount = x.Commits.Count,
            }).ToList();
        }
    }
}
