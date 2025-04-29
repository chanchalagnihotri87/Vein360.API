using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Vein360.API;
using Vein360.Application;
using Vein360.Persistence;
using Vein360.Shipment;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = false,
               ValidateIssuerSigningKey = false,
               ValidIssuer = "chanchal",
               ValidAudience = "http://localhost:4200",
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chanchalchanchalchanchalchanchalchanchalchanchalchanchalchanchal"))
           };
       });

builder.Services.AddAuthorization();

builder.Services.ConfigurePersistence(builder.Configuration);

builder.Services.ConfigureApplication();

builder.Services.ConfigureShipment(builder.Configuration);

builder.Services.ConfigureStorage();

builder.Services.RegisterMapsterConfiguration();

TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

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



app.MapGet("/authenticate", () =>
{
    var token = new JwtSecurityToken(
        claims: new List<Claim> { new Claim(ClaimTypes.Name, "Chanchal") },
        expires: DateTime.Now.AddDays(1),
        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chanchalchanchalchanchalchanchalchanchalchanchalchanchalchanchal")), SecurityAlgorithms.HmacSha256),
        issuer: "chanchal",
        audience: "http://localhost:4200");

    return new JwtSecurityTokenHandler().WriteToken(token);
});

app.MapGet("/dashboard", [Authorize] () =>
{
    return Results.Ok("success");
});


app.MapEndpoints();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
