namespace Git.ViewModels.Repository
{
    using System;
    using System.Globalization;

    public class RepositoriesAllViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => this.CreatedOn.ToString(CultureInfo.GetCultureInfo("bg-BG"));

        public int CommitsCount { get; set; }

        public string CommitsCountAsString => this.CommitsCount.ToString();
    }
}
