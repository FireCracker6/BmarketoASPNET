using BMarketo_API.Helpers.Contexts;
using BMarketo_API.Helpers.Services;
using BMarketo_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("identity")));


builder.Services.AddDefaultIdentity<IdentityUserEntity>().AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddScoped<UserService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
