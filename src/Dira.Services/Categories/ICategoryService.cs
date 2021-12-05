namespace Dira.Services.Categories;

public interface ICategoryService
{
    IEnumerable<CategoryModelDto> GetCategories();
}
