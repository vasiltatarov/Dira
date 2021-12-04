namespace Dira.Infrastructure;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<ICategoryService, CategoryService>();

        return services;
    }
}
