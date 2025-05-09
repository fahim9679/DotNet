using ConcertBooking.Repositories;
using ConcertBooking.Repositories.Implementations;
using ConcertBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ConcertBooking.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ConcertBooking.WebHost")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDbInitial, DbInitial>();
builder.Services.AddScoped<IVenueRepo, VenueRepo>();
builder.Services.AddScoped<IArtistRepo, ArtistRepo>();
builder.Services.AddScoped<IConcertRepo, ConcertRepo>();
builder.Services.AddScoped<IUtilityRepo, UtilityRepo>();
builder.Services.AddScoped<ITicketRepo, TicketRepo>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IBookingRepo, BookingRepo>();
builder.Services.AddScoped<ITicketRepo, TicketRepo>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddRazorPages();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
DataSeeding();

void DataSeeding()
{
    using (var scop = app.Services.CreateScope())
    {
        var _dbRepo = scop.ServiceProvider.GetRequiredService<IDbInitial>();
        _dbRepo.Seed();
    }
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();
app.Run();
