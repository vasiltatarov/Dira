namespace Dira.Controllers;

public class ProductsController : Controller
{
    private readonly ICategoryService categoryService;

    public ProductsController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    public IActionResult ProductsByCategory(
        int categoryId,
        string categoryName,
        int? subCategoryId = null,
        string? subCategoryName = null)
    {
        ViewData["Title"] = subCategoryName != null
            ? subCategoryName + " - " + categoryName
            : categoryName;

        var subCategories = this.categoryService.GetSubCategoriesByBaseCategoryId(categoryId);

        var model = new ProductsViewModel
        {
            CategoryId = categoryId,
            CategoryName = categoryName,
            SubCategories = subCategories,
        };

        return View(model);
    }
}
