namespace PandaExam.Services
{
    using PandaExam.Data;
    using System.Linq;

    public interface IRecieptsService
    {
        void CreateFromPackage(decimal weight, string packageId, string recipientId);

        IQueryable<Receipt> GetAll();
    }
}
