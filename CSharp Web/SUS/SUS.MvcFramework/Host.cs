namespace SUS.MvcFramework
{
    using SUS.HTTP;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public static class Host
    {
        public static async Task CreateHostAsync(List<Route> routeTable, int port = 80)
        {
            IHttpServer server = new HttpServer(routeTable);

            Process.Start(@"C:\Program Files (x86)\BraveSoftware\Brave-Browser\Application\brave.exe", "http://localhost");
            await server.StartAsync(port);
        }
    }
}
