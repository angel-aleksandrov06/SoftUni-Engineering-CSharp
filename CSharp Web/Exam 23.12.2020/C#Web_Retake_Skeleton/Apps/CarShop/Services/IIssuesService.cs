namespace CarShop.Services
{
    using CarShop.ViewModels.Issues;

    public interface IIssuesService
    {
        void Add(AddIssueInputModel input);

        IssueViewModel GetAllByCarId(string id);

        bool Delete(string issueId, string carId);

        bool Fix(string issueId);
    }
}
