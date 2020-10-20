namespace SULS.Services
{
    using SULS.Data;
    using SULS.ViewModels.Problems;
    using System.Collections.Generic;
    using System.Linq;

    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext dbContext;

        public ProblemsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(string name, ushort points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points
            };

            this.dbContext.Problems.Add(problem);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<HomePageProblemViewModel> GetAll()
        {
            var problems = this.dbContext.Problems.Select(x => new HomePageProblemViewModel 
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count,
            }).ToList();

            return problems;
        }

        public string GetNameById(string id)
        {
            return this.dbContext.Problems
                .Where(x => x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();
        }

        public ProblemViewModel GetById(string id)
        {
            return this.dbContext.Problems.Where(x => x.Id == id)
                .Select(x => new ProblemViewModel
                {
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s => new SubmissionViewModel
                    {
                        CreatedOn = s.CreatedOn,
                        SubmissionId = s.Id,
                        AchievedResult = s.AchievedResult,
                        Username = s.User.Username,
                        MaxPoints = x.Points
                    })
                }).FirstOrDefault();
        }
    }
}
