using Microsoft.EntityFrameworkCore;
using netmvc.Data;  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ContactFormDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));  // Using SQL Server connection string

// Add MVC services (Controllers with Views).
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // In development mode, show detailed error pages.
    app.UseDeveloperExceptionPage();
}
else
{
    // In production, use a generic error page and enable HSTS.
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Force HTTPS in all environments.
app.UseHttpsRedirection();

// Serve static files (e.g., CSS, JS, images).
app.UseStaticFiles();

// Set up routing for controllers.
app.UseRouting();

// Enable authorization (if you are using authentication/authorization features).
app.UseAuthorization();

// Map controller routes (the default route is {controller=Home}/{action=Index}/{id?}).
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
