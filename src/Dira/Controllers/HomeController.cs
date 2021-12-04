namespace Dira.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryService categoryService;

    public HomeController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var categories = this.categoryService.GetCategories();

        var model = new IndexViewModel
        {
            Title = "Dira Online Shop!",
            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            Categories = categories,
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
