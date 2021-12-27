namespace Dira.Areas.Administration.Controllers;

public class HomeController : AdministrationController
{
    public IActionResult Index()
    {
        return View();
    }
}
