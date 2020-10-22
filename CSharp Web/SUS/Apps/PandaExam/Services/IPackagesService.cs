namespace PandaExam.Services
{
    using PandaExam.Data;
    using PandaExam.ViewModels.Packages;
    using System.Linq;

    public interface IPackagesService
    {
        void Create(CreateInputModel input);

        IQueryable<Package> GetAllByStatus(PackageStatus status);

        void Deliver(string id);
    }
}
