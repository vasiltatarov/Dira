namespace Dira.Data;

public class DiraDbContext : IdentityDbContext<IdentityUser>
{
    public DiraDbContext(DbContextOptions<DiraDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }
}
