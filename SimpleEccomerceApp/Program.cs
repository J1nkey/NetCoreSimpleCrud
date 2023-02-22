using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SimpleEcommerceApp.Data;
using SimpleEcommerceApp.Models.Commons;
using SimpleEcommerceApp.Options;
using SimpleEcommerceApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureOptions<DatabaseOptionsSetup>();

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>((servicesProvider, dbContextOptionsBuilder) =>
{
    var databaseOptions = servicesProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

    dbContextOptionsBuilder.UseSqlServer(databaseOptions.ConnectionString, sqlServerOptions =>
    {
        sqlServerOptions.EnableRetryOnFailure(databaseOptions.MaxRetryCount);   // Retry 3 times
        sqlServerOptions.CommandTimeout(databaseOptions.CommandTimeout);        // wait 30 seconds for executing a query
    });

    dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
    dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddSingleton(typeof(ApplicationDapperContext));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
