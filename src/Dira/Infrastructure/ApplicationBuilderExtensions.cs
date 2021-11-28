namespace Dira.Infrastructure;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var services = serviceScope.ServiceProvider;

        MigrateDatabase(services);

        SeedCategories(services);

        return app;
    }

    private static void SeedCategories(IServiceProvider services)
    {
        var db = services.GetRequiredService<DiraDbContext>();

        if (db.Categories.Any())
        {
            return;
        }

        var categories = new Category[]
        {
            new Category { Name = "Дрехи", ImageUrl = "https://worldtrade.bg/wp-content/uploads/2021/02/rows-hangers-with-clothes.jpg"},
            new Category { Name = "Книги", ImageUrl = "https://www.economic.bg/web/files/articles/39740/narrow_image/thumb_834x469_books.jpg"},
            new Category { Name = "Мобилни устройства", ImageUrl = "https://images.freekaamaal.com/post_images/1608704571.png"},
            new Category { Name = "Телевизори", ImageUrl = "https://s13emagst.akamaized.net/products/23325/23324306/images/res_217574d216836bc0a635405bae692dcf.jpg?width=720&height=720&hash=446E096C880A5E8C5C97BADB64645FAA"},
            new Category { Name = "Монитори", ImageUrl = "https://p1.akcdn.net/full/558094131.dell-u4919dw.jpg"},
            new Category { Name = "Лаптопи и компютри", ImageUrl = "https://cdncloudcart.com/402/files/image/6-5f2157f737dcc.jpg"},
        };

        db.Categories.AddRange(categories);
        db.SaveChanges();
    }

    private static void MigrateDatabase(IServiceProvider services)
    {
        var db = services.GetRequiredService<DiraDbContext>();
        db.Database.Migrate();
    }
}
