namespace CarShop.ViewModels.Issues
{
    using System.Collections.Generic;
    public class IssueViewModel
    {
        public string CarId { get; set; }

        public IEnumerable<AllIssuesViewModel> CurrIssue { get; set; }
    }
}
