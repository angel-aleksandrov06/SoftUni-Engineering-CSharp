namespace SULS.Services
{
    using SULS.ViewModels.Problems;
    using System.Collections.Generic;

    public interface IProblemsService
    {
        void Create(string name, ushort points);

        IEnumerable<HomePageProblemViewModel> GetAll();

        string GetNameById(string id);

        public ProblemViewModel GetById(string id);
    }
}
