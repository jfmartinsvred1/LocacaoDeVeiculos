using DotNetEnv;
using LocacaoDeVeiculos.Repository;
using LocacaoDeVeiculos.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
Env.Load();

builder.Services.AddDbContext<LocacaoDeVeiculosContext>(opts =>
{

    var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING_DEV");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new Exception("A variável de ambiente 'CONNECTION_STRING_DEV' não foi configurada.");
    }
    opts.UseSqlServer(connectionString);
});
builder.Services.AddScoped<ILocadorRepository, LocadorRepository>();
builder.Services.AddScoped<ILocacaoRepository,LocacaoRepository>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddControllers().AddNewtonsoftJson(opts=>opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
