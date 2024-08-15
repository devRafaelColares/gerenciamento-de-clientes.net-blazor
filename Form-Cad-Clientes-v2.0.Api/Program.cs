using Formulario.Api.Data;
using Formulario.Api.Interfaces;
using Formulario.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adicione a configuração da conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Adicione outros serviços e configurações
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICidadeService, CidadeService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddCors();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();

// Mapear endpoints
foreach (var endpoint in Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
    .Select(Activator.CreateInstance)
    .Cast<IEndpoint>())
{
    endpoint.Map(app);
}

app.Run();
