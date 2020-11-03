namespace Git.Services
{
    using Git.Data;
    using Git.ViewModels.Commit;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string description, string repositoryId, string userId)
        {
            var commit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
                RepositoryId = repositoryId,
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }

        public void Detele(string commitId, string userId)
        {
            var commitToDelete = this.db.Commits.Where(x => x.Id == commitId && x.CreatorId == userId).FirstOrDefault();
            if (commitToDelete == null)
            {
                return;
            }
            this.db.Commits.Remove(commitToDelete);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitsAllViewModel> GetAll(string userId)
        {
            var commits = this.db.Commits.Where(x => x.CreatorId == userId).Select(x => new CommitsAllViewModel
            {
                CreatedOn = x.CreatedOn,
                Id = x.Id,
                Description = x.Description,
                RepositoryName = x.Repository.Name
            }).ToList();

            return commits;
        }

        public CreateCommitViewModel GetRepositoryInfo(string repositoryId)
        {
            var repositoryIfno = this.db.Repositories.Where(x => x.Id == repositoryId).Select(x => new CreateCommitViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault();

            return repositoryIfno;
        }
    }
}
