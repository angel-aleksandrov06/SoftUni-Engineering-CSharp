namespace Git.Services
{
    using Git.ViewModels.Repository;
    using System.Collections.Generic;

    public interface IRepositoriesService
    {
        IEnumerable<RepositoriesAllViewModel> GetAll();
        void Create(string name, string repositoryType, string getUserId);
    }
}
