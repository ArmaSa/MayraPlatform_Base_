using MayraPlatform.Domain.Entities;
using MayraPlatform.Persistence;
using MayraPlatform.Persistence.Context;
using MayraPlatform.WebAPI.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MayraPlatform.Application;
using MayraPlatform.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile("appsettings.json")
     .Build();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();

builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

//var serviceScope = app.Services.CreateScope();
//var dataContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
//await dataContext?.Database.MigrateAsync();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.DefaultModelsExpandDepth(-1); 
});
//app.UseErrorHandler();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseCors();
app.MapControllers();
app.Run();