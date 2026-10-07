using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.Data;
using SistemaFarmacia.Services.Abstractions;
using SistemaFarmacia.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MyConnection"));
});

builder.Services.AddScoped<IProductosService, ProductosService>();
builder.Services.AddScoped<ISucursalesService, SucursalesService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

builder.Services.AddSession();

var app = builder.Build();

app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
