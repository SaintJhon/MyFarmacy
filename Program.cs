using SistemaFarmacia.Services.Abstractions;
using SistemaFarmacia.Services.Implementations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISupplierService, SupplierService>();

builder.Services.AddControllersWithViews();

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
