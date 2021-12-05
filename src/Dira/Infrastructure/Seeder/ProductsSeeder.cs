namespace Dira.Infrastructure.Seeder;

public class ProductsSeeder
{
    public IEnumerable<Product> GetProducts()
    {
        var products = new Product[]
        {
            // Seed Phones
            new Product { Name = "Iphone 13 Pro Max", Price = 2599, ImageUrl = "https://p1.akcdn.net/full/859255707.apple-iphone-13-pro-max-128gb.jpg", CategoryId = 14 },
            new Product { Name = "Iphone 13 Pro", Price = 2299, ImageUrl = "https://p1.akcdn.net/full/859255707.apple-iphone-13-pro-max-128gb.jpg", CategoryId = 14 },
            new Product { Name = "Iphone 12 Pro Max", Price = 2000, ImageUrl = "https://p1.akcdn.net/full/731721867.apple-iphone-12-pro-max-128gb.jpg", CategoryId = 14 },
            new Product { Name = "Iphone 12 Pro", Price = 1890, ImageUrl = "https://p1.akcdn.net/full/731721867.apple-iphone-12-pro-max-128gb.jpg", CategoryId = 14 },
            new Product { Name = "Huawei mate 20 pro", Price = 1099, ImageUrl = "https://www.ping.bg/uploads/com_article/gallery/52e163c6ae6066f10d4f1a88eb436d0243db058b.jpg", CategoryId = 15 },
            new Product { Name = "Huawei p40 Pro", Price = 1299, ImageUrl = "https://consumer.huawei.com/content/dam/huawei-cbg-site/common/mkt/list-image/phones/p40-pro/p40-pro-gold.png", CategoryId = 15 },
            new Product { Name = "Huawei p40 Lite", Price = 899, ImageUrl = "https://s13emagst.akamaized.net/products/28810/28809249/images/res_e4b365f205cdc783895fd6112865ee0e.jpg", CategoryId = 15 },
            new Product { Name = "LG 55un74003lb", Price = 899, ImageUrl = "https://p1.akcdn.net/full/686462448.lg-55un74003lb.jpg", CategoryId = 19 },
        };

        return products;
    }
}
