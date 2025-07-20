using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using fotbalTeam.Application;
using fotbalTeam.Application.Abstraction;
using fotbalTeam.Application.Implementation;
using fotbalTeam.Infrastructure.Database;
using fotbalTeam.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

var cultInfo = new CultureInfo("cs-cz");
CultureInfo.DefaultThreadCurrentCulture = cultInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultInfo;

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.38");
builder.Services.AddDbContext<FotbalTeamDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));


builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<FotbalTeamDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Security/Account/Login";
    options.LogoutPath = "/Security/Account/Logout";
    options.SlidingExpiration = true;
});

//configuration of session
builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
builder.Services.AddSession(options =>
{
    // Set a short timeout for easy testing.
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    // Make the session cookie essential
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IPlayerAppService, PlayerAppService>();
builder.Services.AddScoped<IAccountService, AccountIdentityService>();
builder.Services.AddScoped<ICarouselAppService, CarouselAppService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IMatchAppService, MatchAppService>();
builder.Services.AddScoped<IPerformanceAppService, PerformanceAppService>();
builder.Services.AddScoped<ITrainingAppService, TrainingAppService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();

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

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
