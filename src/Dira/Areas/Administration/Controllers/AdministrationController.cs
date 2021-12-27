namespace Dira.Areas.Administration.Controllers;

using Microsoft.AspNetCore.Authorization;

using static WebConstants;

[Authorize(Roles = AdministratorRoleName)]
[Area(AreaName)]
public class AdministrationController : Controller
{
}
