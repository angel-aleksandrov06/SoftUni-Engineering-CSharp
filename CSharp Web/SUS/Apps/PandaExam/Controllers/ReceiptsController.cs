namespace PandaExam.Controllers
{
    using PandaExam.Services;
    using PandaExam.ViewModels.Receipts;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Linq;

    public class ReceiptsController : Controller
    {
        public ReceiptsController(IRecieptsService recieptsService)
        {
            RecieptsService = recieptsService;
        }

        public IRecieptsService RecieptsService { get; }

        public HttpResponse Index()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var reciepts = this.RecieptsService.GetAll().Select(x => new ReceiptViewModel 
            {
                Id = x.Id,
                Fee = x.Fee,
                IssuedOn = x.IssuedOn,
                RecipientName = x.Recipient.Username,
            }).ToList();

            return this.View(reciepts);
        }
    }
}
