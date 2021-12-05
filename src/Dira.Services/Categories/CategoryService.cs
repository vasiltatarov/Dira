namespace Dira.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly DiraDbContext dbContext;

    public CategoryService(DiraDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<CategoryModelDto> GetCategories()
    {
        var categories = this.dbContext
            .Categories
            .Where(x => !x.IsDeleted && x.ParentCategoryId == null)
            .Select(x => new CategoryModelDto
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
            })
            .ToList();

        return categories;
    }

    public IEnumerable<CategoryModelDto> GetSubCategoriesByBaseCategoryId(int id)
    {
        var subCategories = this.dbContext
            .Categories
            .Where(x => !x.IsDeleted && x.ParentCategoryId == id)
            .Select(x => new CategoryModelDto
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
            })
            .ToList();

        return subCategories;
    }
}
