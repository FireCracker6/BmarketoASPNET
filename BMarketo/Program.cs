using BMarketo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<BreadCrumbService>();
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<HeaderService>();
builder.Services.AddScoped<ProductDetailService>();
builder.Services.AddScoped<ProductDetailInfoService>();

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
