using Gestion_Empleados.Data;
using Gestion_Empleados.Interfaces;
using GestionDeEmpleados.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Redirecciona llamadas a la interfaz hacia el repositorio
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        // Update-Database automáticamente al arrancar
        context.Database.Migrate();
        Console.WriteLine("--> Base de datos migrada con éxito.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"--> Error al migrar la base de datos: {ex.Message}");
    }
}

app.Run();
