//using AsistenteMedicoAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar el contexto de la base de datos con Entity Framework Core
//builder.Services.AddDbContext<AsistenteMedicoContext>(options =>
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
//);

// Añadir el HttpClient para consumir la API
builder.Services.AddHttpClient("ApiCitasMedicas", client =>
{
    client.BaseAddress = new Uri("https://localhost:7119/"); // Reemplaza esto con la URL de tu API
});

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

app.Run();
