using System.Security.Claims;
using BMarketo.Migrations.Products;
using BMarketo.Models.Contexts;
using BMarketo.Models.Contexts.Identity;

using BMarketo.Models.Entities.Products;
using BMarketo.Services;
using BMarketo.Services.Authorization;
using BMarketo.Services.Repositories;
using BMarketo.ViewModels.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("BMarketo")));
builder.Services.AddDbContext<ProductsContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("products")));
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<ProductsRepository>();
builder.Services.AddScoped<NewsletterSubscriptionRepository>();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});





builder.Services.Configure<FormOptions>(x => x.MultipartBodyLengthLimit = 8000000000);

builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<IdentityContext>()
.AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";

});


builder.Services.AddScoped<BreadCrumbService>();
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<HeaderService>();
builder.Services.AddScoped<ProductDetailService>();
builder.Services.AddScoped<ProductDetailInfoService>();
builder.Services.AddScoped<ContactFormService>();
builder.Services.AddScoped<SignUpFormService>();
builder.Services.AddScoped<GoogleMapsService>();
builder.Services.AddScoped<AddProductFormService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<ProductsContext>();
        await BMarketo.Services.SeedCategoryData.Seed(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the categories.");
    }
}
 builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}",
        defaults: new { controller = "Home", action = "Index" },
        constraints: null,
        dataTokens: new { LoggerFactory = app.Services.GetRequiredService<ILoggerFactory>() });
});



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
