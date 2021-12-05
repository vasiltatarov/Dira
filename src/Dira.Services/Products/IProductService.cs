namespace Dira.Services.Products;

public interface IProductService
{
    IEnumerable<ProductModelDto> GetProductsByCategoryId(int id);

    IEnumerable<ProductModelDto> GetProductsBySubCategoryId(int id);
}
