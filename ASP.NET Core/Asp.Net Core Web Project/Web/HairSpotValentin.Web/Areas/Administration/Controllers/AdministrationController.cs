namespace HairSpotValentin.Web.Areas.Administration.Controllers
{
    using HairSpotValentin.Common;
    using HairSpotValentin.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
