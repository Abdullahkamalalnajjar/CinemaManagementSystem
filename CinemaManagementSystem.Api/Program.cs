using CinemaManagementSystem.Core;
using CinemaManagementSystem.Core.Middleware;
using CinemaManagementSystem.Data.Entities.Identity;
using CinemaManagementSystem.infrustructure;
using CinemaManagementSystem.infrustructure.Seeder;
using CinemaManagementSystem.Infrustructure;
using CinemaManagementSystem.Infrustructure.DbContext;
using CinemaManagementSystem.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependencies
builder.Services.AddServiceDependencies()
    .AddCoreDependencies()
   .AddServiceRegisteration(builder.Configuration)
    .AddInfrustructureDependencies();
//builder.Services.AddSwagger();
#endregion

#region Connection
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"),
        new CultureInfo("de-DE"),
        new CultureInfo("fr-FR"),
        new CultureInfo("ar-EG")
    };

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

#endregion

#region AllowCORS
const string cors = "_cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors,
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      });
});

#endregion


builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddTransient<IUrlHelper>(x =>
{
    var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
    var factory = x.GetRequiredService<IUrlHelperFactory>();
    return factory.GetUrlHelper(actionContext);
});

var app = builder.Build();

#region Seeder
using (var createscope = app.Services.CreateScope())
{
    var userManger = createscope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManger = createscope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await RolesSeeder.SeedAsync(roleManger);
    await UserSeeder.SeedAsync(userManger);
}

;


#endregion




#region Update
//update database
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();//catch
try
{
    var DbContext = services.GetRequiredService<ApplicationDbContext>();
    await DbContext.Database.MigrateAsync();

}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "an error during Apply migration");

}
#endregion


// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


#region Localization Middleware
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseCors(cors);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
