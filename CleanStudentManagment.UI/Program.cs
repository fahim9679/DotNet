using CleanStudentManagment.BLL.Services;
using CleanStudentManagment.Data;
using CleanStudentManagment.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSession(options=>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set the session timeout to 30 minutes
    options.Cookie.HttpOnly = true; // Make the session cookie HTTP-only
    options.Cookie.IsEssential = true; // Make the session cookie essential for the application
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
