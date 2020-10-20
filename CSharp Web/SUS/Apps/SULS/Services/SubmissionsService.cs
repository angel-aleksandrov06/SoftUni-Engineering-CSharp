namespace SULS.Services
{
    using SULS.Data;
    using System;
    using System.Linq;

    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Random random;

        public SubmissionsService(ApplicationDbContext dbContext, Random random)
        {
            this.dbContext = dbContext;
            this.random = random;
        }

        public void Create(string problemId, string userId, string code)
        {
            var problemMaxPoints = this.dbContext.Problems.Where(x => x.Id == problemId)
                .Select(x => x.Points).FirstOrDefault();

            var submission = new Submission
            {
                Code = code,
                ProblemId = problemId,
                UserId = userId,
                AchievedResult = (ushort)this.random.Next(0, problemMaxPoints + 1),
                CreatedOn = DateTime.UtcNow
            };

            this.dbContext.Submissions.Add(submission);
            this.dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.dbContext.Submissions.Find(id);
            this.dbContext.Submissions.Remove(submission);
            this.dbContext.SaveChanges();
        }
    }
}
