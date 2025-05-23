using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Farmacia.web.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FarmaciawebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FarmaciawebContext") ?? throw new InvalidOperationException("Connection string 'FarmaciawebContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
