namespace Dira.Infrastructure;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var services = serviceScope.ServiceProvider;

        MigrateDatabase(services);

        SeedTestData(services);

        return app;
    }

    private static void SeedTestData(IServiceProvider services)
    {
        var db = services.GetRequiredService<DiraDbContext>();

        if (!db.Tests.Any())
        {
            db.Tests.AddRange(new Test[]
            {
                new Test { Name = "Test1" },
                new Test { Name = "Test2" },
                new Test { Name = "Test3" },
            });

            db.SaveChanges();
        }
    }

    private static void MigrateDatabase(IServiceProvider services)
    {
        var db = services.GetRequiredService<DiraDbContext>();
        db.Database.Migrate();
    }
}
