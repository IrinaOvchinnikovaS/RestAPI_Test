using RestAPI_Test.Services.Interfaces;
using RestAPI_Test.Services;
using RestAPI_Test.Repositories;
using RestAPI_Test.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.

builder.Services.AddControllers();

services.AddScoped<IReportService, ReportService>();
services.AddScoped<IPostRepository, PostRepository>();
services.AddScoped<ITodoRepository, TodoRepository>();
services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
