namespace PandaExam.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class ReceiptsController : Controller
    {
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
