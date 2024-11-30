using Radzen;
using Blazored.Modal;
using Reciplas.Clases;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Reciplas.Repository;

var builder = WebApplication.CreateBuilder(args);

// Configuración del DbContext solo en Desarrollo, no en Producción
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
        options.UseSqlServer("..."));
}
else
{
    // Usar datos hardcodeados en producción (evitar conexión con DB)
    builder.Services.AddScoped<IClienteRepository, ClienteRepositoryHardcoded>(); // Inyectar repositorio con datos hardcodeados
}

System.Net.ServicePointManager.SecurityProtocol = 
    System.Net.SecurityProtocolType.Tls12;

// Servicios comunes
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Radzen y Blazored Modal
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddBlazoredModal();

// Configuración de autenticación y autorización
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddSingleton(new HttpClient{
    BaseAddress = new Uri("https://localhost:44331/")
});

// Otros servicios necesarios
builder.Services.AddControllers();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();
