using Microsoft.EntityFrameworkCore;
using Project_Passion_BrenoSouza.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the DbContext using MySQL
var connectionString = builder.Configuration.GetConnectionString("MvcConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add IHttpClientFactory
builder.Services.AddHttpClient();

// Specify the URL and port for the application to listen on
builder.WebHost.UseUrls("http://localhost:5070");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
