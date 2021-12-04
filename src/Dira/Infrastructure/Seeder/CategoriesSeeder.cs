namespace Dira.Infrastructure.Seeder;

public class CategoriesSeeder
{
    public IEnumerable<Category> GetCategories()
    {
        var categories = new Category[]
        {
            new Category { Name = "Дрехи", ImageUrl = "https://worldtrade.bg/wp-content/uploads/2021/02/rows-hangers-with-clothes.jpg"},
            new Category { Name = "Книги", ImageUrl = "https://www.economic.bg/web/files/articles/39740/narrow_image/thumb_834x469_books.jpg"},
            new Category { Name = "Мобилни устройства", ImageUrl = "https://images.freekaamaal.com/post_images/1608704571.png"},
            new Category { Name = "Телевизори", ImageUrl = "https://s13emagst.akamaized.net/products/23325/23324306/images/res_217574d216836bc0a635405bae692dcf.jpg?width=720&height=720&hash=446E096C880A5E8C5C97BADB64645FAA"},
            new Category { Name = "Монитори", ImageUrl = "https://p1.akcdn.net/full/558094131.dell-u4919dw.jpg"},
            new Category { Name = "Лаптопи и компютри", ImageUrl = "https://cdncloudcart.com/402/files/image/6-5f2157f737dcc.jpg"},
        };

        return categories;
    }

    public IEnumerable<Category> GetSubCategories()
    {
        var subcategories = new Category[]
        {
            // seed laptop brands
            new Category { Name = "HP", ImageUrl = "https://sitemedia.bg/sites/default/files/field/image/HP_logo_2012.svg_.png", ParentCategoryId = 6 },
            new Category { Name = "Asus", ParentCategoryId = 6 },
            new Category { Name = "Acer", ParentCategoryId = 6 },
            // seed mobile brands
            new Category { Name = "Iphone", ImageUrl = "https://s13emagst.akamaized.net/products/40685/40684425/images/res_b748837bd7a5da11557c241136279b58.jpg", ParentCategoryId = 3 },
            new Category { Name = "Huawei", ParentCategoryId = 3 },
            new Category { Name = "Xiaomi", ParentCategoryId = 3 },
            new Category { Name = "Samsung", ParentCategoryId = 3 },
            // seed TV brands
            new Category { Name = "Samsung", ImageUrl = "https://s13emagst.akamaized.net/products/40685/40684425/images/res_b748837bd7a5da11557c241136279b58.jpg", ParentCategoryId = 4 },
            new Category { Name = "LG", ParentCategoryId = 4 },
            new Category { Name = "Sony", ParentCategoryId = 4 },
            new Category { Name = "Philips", ParentCategoryId = 4 },
        };

        return subcategories;
    }
}
