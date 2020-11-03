namespace Git.ViewModels.Commit
{
    using System;
    using System.Globalization;

    public class CommitsAllViewModel
    {
        public string Id { get; set; }

        public string RepositoryName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => this.CreatedOn.ToString(CultureInfo.GetCultureInfo("bg-BG"));

    }
}
