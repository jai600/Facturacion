
using Facturacion;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

//Se le especifica al contexto que cadena de conexion tomara para realizar el modelado de base de datos.
builder.Services.AddDbContext<FacturaContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("BillConnection"))
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var context = scope.ServiceProvider.GetRequiredService<FacturaContext>();
  context.Database.Migrate();
}

 
 if (!app.Environment.IsDevelopment())
 {
     app.UseExceptionHandler("/Home/Error");
 }

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
