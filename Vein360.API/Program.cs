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
using Vein360.Authentication;
using Vein360.Persistence;
using Vein360.Shipment;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

var corsOrigins = builder.Configuration.GetRequiredSection("CorsOrigin").Value!.Split(",");
var jwtSecret = builder.Configuration.GetRequiredSection("JWTSecret").Value!;
var jwtIssuer = builder.Configuration.GetRequiredSection("JWTIssuer").Value!;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = false,
               ValidateIssuerSigningKey = false,
               ValidIssuer = jwtIssuer,
               ValidAudience = string.Join(",", corsOrigins),
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
           };
       });

builder.Services.AddAuthorization();

builder.Services.AddCors();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.ConfigurePersistence(builder.Configuration);

builder.Services.ConfigureApplication();

builder.Services.ConfigureShipment(builder.Configuration);

builder.Services.ConfigureStorage(builder.Environment.IsDevelopment());

builder.Services.ConfigureAuthentication();

builder.Services.RegisterMapsterConfiguration();

TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapEndpoints();

app.UseCors(config =>
{
    config.
    WithOrigins(corsOrigins).
    AllowAnyHeader().
    AllowAnyMethod();
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
