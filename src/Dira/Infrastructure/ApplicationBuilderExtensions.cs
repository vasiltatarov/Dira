namespace Dira.Infrastructure;

using static WebConstants;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var services = serviceScope.ServiceProvider;

        MigrateDatabase(services);

        SeedAdministratorAndRole(services);

        SeedCategories(services);
        SeedProducts(services);

        return app;
    }

    private static void SeedAdministratorAndRole(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

        if (userManager.FindByEmailAsync(AdministratorEmail).Result != null)
        {
            return;
        }

        var user = new IdentityUser
        {
            UserName = "Admin@gmail.com",
            Email = AdministratorEmail,
            EmailConfirmed = true,
        };

        var createUser = userManager.CreateAsync(user, AdministratorPassword).Result;

        if (createUser.Succeeded)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            if (!roleManager.RoleExistsAsync(AdministratorRoleName).Result)
            {
                var role = roleManager.CreateAsync(new IdentityRole(AdministratorRoleName)).Result;
                var userToRole = userManager.AddToRoleAsync(user, AdministratorRoleName).Result;
            }
        }
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
