namespace Dira.Data;

public class DiraDbContext : IdentityDbContext
{
    public DiraDbContext(DbContextOptions<DiraDbContext> options)
        : base(options)
    {
    }

    public DbSet<Test> Tests { get; set; }
}
