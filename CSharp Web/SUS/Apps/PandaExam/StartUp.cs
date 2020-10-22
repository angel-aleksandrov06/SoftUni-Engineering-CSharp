namespace PandaExam
{
    using Microsoft.EntityFrameworkCore;
    using PandaExam.Data;
    using PandaExam.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Collections.Generic;

    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            //serviceCollection.Add<IProblemsService, ProblemsService>();
            //serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }
    }
}
