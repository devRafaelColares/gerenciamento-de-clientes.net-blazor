using Formulario.Api.Interfaces;
using Formulario.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICidadeService, CidadeService>(); // Certifique-se de registrar seus serviços

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map endpoints
foreach (var endpoint in Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
    .Select(Activator.CreateInstance)
    .Cast<IEndpoint>())
{
    endpoint.Map(app);
}

app.Run();
