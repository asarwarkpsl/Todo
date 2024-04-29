using Core.Model;
using Infrastructure.DBContext;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Task = Core.Model.Task;
using List = Core.Model.List;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlite<TodoContext>(builder.Configuration.GetConnectionString("Database"), b=> b.MigrationsAssembly("API"));
builder.Services.AddScoped(typeof(IGenericRepository<List>), typeof(GenericRepository<List>));
builder.Services.AddScoped(typeof(IGenericRepository<Task>), typeof(GenericRepository<Task>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
var context= services.GetRequiredService<TodoContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migrations");
}

app.Run();
