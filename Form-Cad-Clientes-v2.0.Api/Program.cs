using Formulario.Api.Common.Api;
using Formulario.Api.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();

builder.AddSecurity();

builder.AddDataContexts();

builder.AddCrossOrigin();

builder.AddDocumentaition();

builder.AddScopeds();

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

foreach (var endpoint in Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
    .Select(Activator.CreateInstance)
    .Cast<IEndpoint>())
{
    endpoint.Map(app);
}

app.Run();
