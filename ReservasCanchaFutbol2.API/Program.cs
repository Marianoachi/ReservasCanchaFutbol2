using Microsoft.EntityFrameworkCore;
using ReservasCanchaFutbol.API.Services;
using ReservasCanchaFutbol2.API.Data;
using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Repositories;
using ReservasCanchaFutbol2.API.Services;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);


// 1. Cadena de conexión y DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ReservasDbContext>(opts =>
    opts.UseSqlite(connectionString));

// 2. Inyección de dependencias (Repositorios y Servicios)
builder.Services.AddScoped<ICanchaRepository, CanchaRepository>();
builder.Services.AddScoped<ICanchaService, CanchaService>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IReservaService, ReservaService>();

// 3. Controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Aplica migraciones y siembra datos al iniciar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ReservasDbContext>();
    db.Database.Migrate();             // crea o actualiza las tablas
    ReservasDbContext.SeedData(db);    // opcional: inserta canchas de ejemplo
}

// 5. Middleware de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 6. Pipeline HTTP
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
