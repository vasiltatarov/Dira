namespace Dira.Controllers;

public class ProductsController : Controller
{
    private readonly ICategoryService categoryService;
    private readonly IProductService productService;

    public ProductsController(ICategoryService categoryService, IProductService productService)
    {
        this.categoryService = categoryService;
        this.productService = productService;
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

        var products = subCategoryId == null
            ? this.productService.GetProductsByCategoryId(categoryId)
            : this.productService.GetProductsBySubCategoryId(subCategoryId.Value).ToList();

        var model = new ProductsViewModel
        {
            CategoryId = categoryId,
            CategoryName = categoryName,
            SubCategories = subCategories,
            Products = products,
        };

        return View(model);
    }
}
