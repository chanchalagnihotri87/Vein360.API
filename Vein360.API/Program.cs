using Microsoft.EntityFrameworkCore;
using Vein360.Persistence;
using Vein360.Application;
using Mapster;
using System.Reflection;
using Vein360.Shipment;
using Vein360.API;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigurePersistence(builder.Configuration);

builder.Services.ConfigureApplication();

builder.Services.ConfigureShipment(builder.Configuration);

builder.Services.ConfigureStorage();

builder.Services.RegisterMapsterConfiguration();

TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

builder.Services.AddCors();

//builder.Services.AddAuthentication().AddJwtBearer();
//builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.MapEndpoints();

app.UseCors(cfg => cfg
    .AllowAnyOrigin()
    .AllowAnyHeader().
    AllowAnyMethod()
    );

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
