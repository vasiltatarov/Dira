namespace Dira.Controllers;

public class ProductsController : Controller
{
    private readonly ICategoryService categoryService;

    public ProductsController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    public IActionResult ProductsByCategory(int categoryId, string categoryName)
    {
        // get subcategories by base category id
        // get products by categories

        var subCategories = this.categoryService.GetSubCategoriesByBaseCategoryId(categoryId);

        ViewData["Title"] = categoryName;

        var model = new ProductsViewModel
        {
            SubCategories = subCategories,
        };

        return View(model);
    }
}
