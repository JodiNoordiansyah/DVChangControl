using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DariaVarya.Web.App.Data;
using System.Security.Policy;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DariaVaryaWebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DariaVaryaWebAppContext") ?? throw new InvalidOperationException("Connection string 'DariaVaryaWebAppContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true; // Makes the session cookie accessible only through HTTP
    options.Cookie.IsEssential = true; // Required for GDPR compliance
});

builder.Services.AddAuthentication("Auth")
        .AddCookie("Auth", options =>
        {
            options.LoginPath = "/Login/Index"; // Set your login path
        });

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // Ignore circular references
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Ensure this is before UseAuthorization
app.UseAuthorization();

// Enable session middleware
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
