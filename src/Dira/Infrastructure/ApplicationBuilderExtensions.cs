namespace Dira.Infrastructure;

using Dira.Infrastructure.Seeder;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var services = serviceScope.ServiceProvider;

        MigrateDatabase(services);

        SeedCategories(services);

        SeedProducts(services);

        return app;
    }

    private static void SeedProducts(IServiceProvider services)
    {
        var db = services.GetRequiredService<DiraDbContext>();

        if (db.Products.Any())
        {
            return;
        }

        var productSeeder = new ProductsSeeder();
        var products = productSeeder.GetProducts();

        db.Products.AddRange(products);
        db.SaveChanges();
    }

    private static void SeedCategories(IServiceProvider services)
    {
        var db = services.GetRequiredService<DiraDbContext>();

        if (db.Categories.Any())
        {
            return;
        }

        var categorySeeder = new CategoriesSeeder();
        var categories = categorySeeder.GetCategories();
        var subcategories = categorySeeder.GetSubCategories();

        db.Categories.AddRange(categories);
        db.Categories.AddRange(subcategories);

        db.SaveChanges();
    }

    private static void MigrateDatabase(IServiceProvider services)
    {
        var db = services.GetRequiredService<DiraDbContext>();
        db.Database.Migrate();
    }
}
