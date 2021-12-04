namespace Dira.Services.Categories;

public interface ICategoryService
{
    IEnumerable<CategoryViewModel> GetCategories();
}
