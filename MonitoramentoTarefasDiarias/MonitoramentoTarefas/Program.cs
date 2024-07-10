using Microsoft.EntityFrameworkCore;
using MonitoramentoTarefas.AutoMapper;
using ProjetoTarefaRepositories.Infra;
using ProjetoTarefaRepositories.Repository;
using ProjetoTarefasDomain.Interfaces.Repository;
using ProjetoTarefasDomain.Interfaces.Services;
using ProjetoTarefasDomain.Interfaces.Services.Interfaces;
using ProjetoTarefasDomain.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>((s,o) => o.UseSqlServer(@"Server=localhost;Database=Monitoramento;Trusted_Connection=True;MultipleActiveResultSets=true")) ;
builder.Services.AddScoped<TarefaValidator, TarefaValidator>();
builder.Services.AddScoped<ProjetoValidator, ProjetoValidator>();
builder.Services.AddAutoMapper(typeof(ConfigurationMapping));

builder.Services.AddTransient<IProjetoService, ProjetoService>();
builder.Services.AddTransient<ITarefaService, TarefaService>();
builder.Services. AddTransient<IProjetoRepository, ProjetoRepository>();
builder.Services.AddTransient<ITarefaRepository, TarefaRepository>();



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
