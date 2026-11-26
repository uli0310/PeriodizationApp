using Microsoft.EntityFrameworkCore;
using PeriodizationApp.Core.Interfaces;
using PeriodizationApp.Infrastructure;
using PeriodizationApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Conexión a PostgreSQL (Infraestructura)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Inyección de Dependencias (El puente entre la API y tus Repositorios)
builder.Services.AddScoped<ISetRecordRepository, SetRecordRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IMesocycleRepository, MesocycleRepository>();
builder.Services.AddScoped<IWorkoutSessionRepository, WorkoutSessionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// 3. Soporte para Controladores 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 4. Configuración CORS (Permite conexión desde PC localhost, celular en red Wi-Fi y túneles externos)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Solo redirigimos a HTTPS en producción para evitar bloqueos de certificado autofirmado al entrar desde el celular por IP local
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowBlazorClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
