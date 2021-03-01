namespace CarShop.Services
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.ViewModels.Issues;
    using System.Linq;

    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext db;

        public IssuesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(AddIssueInputModel input)
        {
            var issue = new Issue
            {
                CarId = input.carId,
                IsFixed = false,
                Description = input.Description
            };

            this.db.Issues.Add(issue);
            this.db.SaveChanges();
        }

        public bool Delete(string issueId, string carId)
        {
            var issue = this.db.Issues.FirstOrDefault(x => x.Id == issueId);

            if (issue == null)
            {
                return false;
            }

            this.db.Issues.Remove(issue);
            this.db.SaveChanges();

            return true;
        }

        public bool Fix(string issueId)
        {
            var issue = this.db.Issues.FirstOrDefault(x => x.Id == issueId);

            if (issue == null)
            {
                return false;
            }

            issue.IsFixed = true;

            this.db.SaveChanges();

            return true;
        }

        public IssueViewModel GetAllByCarId(string id)
        {
            return this.db.Cars.Where(x => x.Id == id).Select(x => new IssueViewModel
            {
                CarId = x.Id,
                CurrIssue = x.Issues.Select(z => new AllIssuesViewModel
                {
                    CarId = x.Id,
                    Description = z.Description,
                    IsItFixed = z.IsFixed,
                    IssueId = z.Id
                }).ToList()
            }).FirstOrDefault();
        }
    }
}
