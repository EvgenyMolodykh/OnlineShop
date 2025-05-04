using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Repository;
using Serilog;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShopWebApp.Db;
using OnlineShopWebApp.Db.Interface;

var builder = WebApplication.CreateBuilder(args);



string connection = builder.Configuration.GetConnectionString("online_shop");
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(connection));


builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(hostingContext.Configuration)
        .Enrich.FromLogContext() 
        .Enrich.WithProperty("ApplicationName", "OnlineShop");
});

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IOrdersRepository,InMemoryOrdersRepository>();
builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>(); 
builder.Services.AddSingleton<ICartsRepository, InMemoryCartsRepository>();
builder.Services.AddSingleton<IRolsRepository, InMemoryRolesReposutory>();
builder.Services.AddSingleton<IUsersManager, InMemoryUsersManager>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
 
    app.UseHsts();

}
app.UseSerilogRequestLogging(); 
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
