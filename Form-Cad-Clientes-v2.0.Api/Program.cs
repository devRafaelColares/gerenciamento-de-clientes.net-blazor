using System.Reflection;
using Formulario.Api;
using Formulario.Api.Common.Api;
using Formulario.Api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddSecurity();
builder.AddDataContexts();
builder.AddCrossOrigin(); // Configuração do CORS
builder.AddDocumentaition();
builder.AddScopeds();

var app = builder.Build();

// Aplicar a política de CORS
app.UseCors(ApiConfiguration.CorsPolicyName);

if (app.Environment.IsDevelopment())
{
    app.ConfigureDevEnvironment();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication(); // Adicionar autenticação se necessário
app.UseAuthorization(); // Adicionar autorização se necessário


foreach (var endpoint in Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
    .Select(Activator.CreateInstance)
    .Cast<IEndpoint>())
{
    endpoint.Map(app);
}

app.Run();
