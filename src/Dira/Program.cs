using static Dira.WebConstants;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services
    .AddDbContext<DiraDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DiraDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddApplicationServices();

var app = builder.Build();

app.PrepareDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization();

app.MapAreaControllerRoute(
    name: "Areas",
    areaName: AreaName,
    pattern: "Administration/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    "Products",                                           // Route name
    "Products/{categoryName}",                            // URL with parameters
    new { controller = "Products", action = "ProductsByCategory" });  // Parameter defaults

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
