namespace Git.Services
{
    using Git.ViewModels.Commit;
    using System.Collections.Generic;

    public interface ICommitsService
    {
        CreateCommitViewModel GetRepositoryInfo(string repositoryId);

        void Create(string description, string repositoryId, string userId);

        IEnumerable<CommitsAllViewModel> GetAll(string userId);

        void Detele(string commitId, string userId);
    }
}
