namespace Dira.Services.Products;

public class ProductService : IProductService
{
    private readonly DiraDbContext dbContext;

    public ProductService(DiraDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<ProductModelDto> GetProductsByCategoryId(int id)
    {
        var subCategoriesIds = this.dbContext
            .Categories
            .Where(x => !x.IsDeleted && x.ParentCategoryId == id)
            .Select(x => x.Id)
            .ToList();

        var products = this.dbContext
            .Products
            .Where(x => !x.IsDeleted && subCategoriesIds.Contains(x.CategoryId))
            .Select(x => new ProductModelDto
            {
                Name = x.Name,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
            })
            .ToList();

        return products;
    }

    public IEnumerable<ProductModelDto> GetProductsBySubCategoryId(int id)
    {
        var products = this.dbContext
            .Products
            .Where(x => !x.IsDeleted && x.CategoryId == id)
            .Select(x => new ProductModelDto
            {
                Name = x.Name,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
            })
            .ToList();

        return products;
    }
}
