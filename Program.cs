using Microsoft.EntityFrameworkCore;
using Proyecto_Cine.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// 🔌 Conexión a base de datos MySQL
builder.Services.AddDbContext<SarmiMovieDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// ✅ Servicios Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddControllers(); // Habilita los controladores API

// ✅ Autenticación con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";                    // Redirigir si no ha iniciado sesión
        options.AccessDeniedPath = "/AccesoDenegado";    // Redirigir si no tiene permiso (rol)
        options.ExpireTimeSpan = TimeSpan.FromHours(2);  // Tiempo de sesión
        options.SlidingExpiration = true;                // Renovar si sigue activo
    });

// ✅ Autorización basada en roles o políticas (si las agregas luego)
builder.Services.AddAuthorization();

var app = builder.Build();

// 🌐 Configurar el pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();      // Necesario para cargar CSS, JS, imágenes desde wwwroot
app.UseRouting();

app.UseAuthentication();   // Primero autenticación
app.UseAuthorization();    // Luego autorización (dependiente de la anterior)

// 📄 Activar Razor Pages
app.MapRazorPages();

app.MapControllers(); // Habilita rutas API como /api/funciones/{id}/precios

app.Run();
