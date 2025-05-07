using Microsoft.EntityFrameworkCore;
using Visitas.Aplicacion.Comandos;
using Visitas.Aplicacion.Consultas;
using Visitas.Dominio.Puertos.Repositorios;
using Visitas.Dominio.Servicios;
using Visitas.Infraestructura.Repositorios;
using Visitas.Infraestructura.RepositoriosGenericos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<VisitasDBContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddTransient<IVisitaRepositorio, VisitaRepositorio>();
builder.Services.AddScoped<IComandosVisitas, ComandosVisitas>();
builder.Services.AddScoped<IConsultasVisitas, ConsultasVisitas>();
builder.Services.AddScoped<CrearVisita>();
builder.Services.AddScoped<ActualizarVisita>();
builder.Services.AddScoped<ObtenerVisitaPorId>();
builder.Services.AddScoped<ObtenerVisitasPorFecha>();
builder.Services.AddScoped<ObtenerVisitasPorVendedorId>();

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
