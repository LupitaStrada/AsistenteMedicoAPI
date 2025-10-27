using AsistenteMedicoAPI.Auth;
using AsistenteMedicoAPI.EndPoints;
using AsistenteMedicoAPI.Models.DAL;
using AsistenteMedicoAPI.Models.EN;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
      
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar el contexto de la base de datos con Entity Framework Core

builder.Services.AddDbContext
    <AsistenteMedicoContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddScoped<PacienteDAL>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("LoggedInPolicity", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});
var key = "Key.JWTAPIMinimal2023.API";

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    //configurar la autenticacion JWT utilizando el esquema JwtBearer
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
        };
    });
builder.Services.AddSingleton<IJwAuthenticationService>(new JwtAuthenticationService(key));
var app = builder.Build();
app.AddPacienteEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
