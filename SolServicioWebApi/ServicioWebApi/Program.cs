using Microsoft.EntityFrameworkCore;
using ServicioWebApi.Data;
using ServicioWebApi.Interfaces;
using ServicioWebApi.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string strConexion = builder.Configuration.GetSection("ConnectionStrings:CadenaActual").Value;
// Registro Contexto
builder.Services.AddDbContext<pubsContext>(opcion => opcion.UseSqlServer(strConexion));

builder.Services.AddScoped<IPublisher, RepoPublisherEF>();

builder.Services.AddScoped<RepoArticuloEF>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
