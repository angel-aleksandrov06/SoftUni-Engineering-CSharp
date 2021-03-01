namespace CarShop.ViewModels.Issues
{
    public class AllIssuesViewModel
    {
        public string CarId { get; set; }

        public string Description { get; set; }

        public bool IsItFixed { get; set; }

        public string IsItFixedAsString => IsItFixed == true ? "Yes" : "Not Yet";

        public string IssueId { get; set; }
    }
}
