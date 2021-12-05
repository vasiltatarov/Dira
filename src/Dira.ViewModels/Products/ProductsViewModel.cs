namespace Dira.ViewModels.Products;

public class ProductsViewModel
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public IEnumerable<CategoryModelDto> SubCategories { get; set; }

    public IEnumerable<ProductModelDto> Products { get; set; }
}
