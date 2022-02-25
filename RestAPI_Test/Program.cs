using RestAPI_Test.Services.Interfaces;
using RestAPI_Test.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.

builder.Services.AddControllers();

services.AddScoped<IUsersService, UsersService>();
services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
