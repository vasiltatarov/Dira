namespace Dira.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly DiraDbContext dbContext;

    public CategoryService(DiraDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<CategoryViewModel> GetCategories()
    {
        var categories = this.dbContext
            .Categories
            .Where(x => !x.IsDeleted && x.ParentCategoryId == null)
            .Select(x => new CategoryViewModel
            {
                ImageUrl = x.ImageUrl,
                Name = x.Name,
            })
            .ToList();

        return categories;
    }
}
