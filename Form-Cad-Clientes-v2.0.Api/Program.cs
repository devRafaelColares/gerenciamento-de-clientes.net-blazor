using Microsoft.EntityFrameworkCore;
using Formulario.Api.Data;
using Formulario.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formulario.Api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
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

// Endpoint PUT /Clientes
app.MapPut("/Clientes", async (Request request, AppDbContext context) =>
{
    // Verificar se a cidade existe no banco de dados
    var cidade = await context.Cidades
        .FirstOrDefaultAsync(c => c.Nome == request.Cidade.Nome && c.Estado == request.Cidade.Estado);
    
    // Se a cidade não existe, criar e adicionar
    if (cidade == null)
    {
        cidade = new Cidades
        {
            Nome = request.Cidade.Nome,
            Estado = request.Cidade.Estado
        };

        context.Cidades.Add(cidade);
        await context.SaveChangesAsync();
    }

    // Criar o cliente com a cidade
    var cliente = new Clientes
    {
        Nome = request.Nome,
        Telefone = request.Telefone,
        Foto = request.Foto,
        Sexo = request.Sexo,
        Cidade = cidade
    };

    context.Clientes.Add(cliente);
    await context.SaveChangesAsync();

    // Preparar a resposta
    var response = new ClienteResponse
    {
        Codigo = cliente.Codigo, // O ID gerado pelo banco de dados
        Nome = cliente.Nome,
        Telefone = cliente.Telefone,
        Foto = cliente.Foto,
        Sexo = cliente.Sexo,
        CreatedAt = DateTime.UtcNow
    };

    return Results.Created($"/Clientes/{response.Codigo}", response);
})
.WithName("Cadastro de clientes")
.WithSummary("Esta rota servirá para cadastrar novos clientes")
.Produces<ClienteResponse>(StatusCodes.Status201Created);

// Endpoint GET /Clientes
app.MapGet("/Clientes", async (AppDbContext context) =>
{
    var clientes = await context.Clientes
        .Include(c => c.Cidade)
        .ToListAsync();

    var response = clientes.Select(c => new ClienteResponse
    {
        Codigo = c.Codigo,
        Nome = c.Nome,
        Telefone = c.Telefone,
        Foto = c.Foto,
        Sexo = c.Sexo,
        CreatedAt = c.CreatedAt
    }).ToList();

    return Results.Ok(response);
})
.WithName("Listagem de clientes")
.WithSummary("Esta rota retornará a lista de clientes")
.Produces<List<ClienteResponse>>();

// Endpoint GET /Cidades
// Endpoint GET /Cidades
app.MapGet("/Cidades", async (AppDbContext context) =>
{
    // Buscar todas as cidades incluindo clientes
    var cidades = await context.Cidades
        .Include(c => c.Clientes)
        .ToListAsync();

    // Preparar a resposta
    var response = cidades.Select(c => new CidadeDetalhesResponse
    {
        Id = c.Id,
        Nome = c.Nome,
        Estado = c.Estado,
        Clientes = c.Clientes.Select(cliente => new ClienteResponse
        {
            Codigo = cliente.Codigo,
            Nome = cliente.Nome,
            Telefone = cliente.Telefone,
            Foto = cliente.Foto,
            Sexo = cliente.Sexo,
            CreatedAt = cliente.CreatedAt
        }).Cast<IClienteResponse>().ToList()
    }).ToList();

    return Results.Ok(response);
})
.WithName("Listagem de cidades com clientes")
.WithSummary("Esta rota retornará a lista de cidades com seus clientes")
.Produces<List<CidadeDetalhesResponse>>();


// Endpoint GET /Cidades/{id}
app.MapGet("/Cidades/{id}", async (long id, AppDbContext context) =>
{
    var cidade = await context.Cidades
        .Include(c => c.Clientes)
        .FirstOrDefaultAsync(c => c.Id == id);

    if (cidade == null)
    {
        return Results.NotFound();
    }

    var response = new CidadeDetalhesResponse
    {
        Id = cidade.Id,
        Nome = cidade.Nome,
        Estado = cidade.Estado,
        Clientes = cidade.Clientes.Select(cliente => new ClienteResponse
        {
            Codigo = cliente.Codigo,
            Nome = cliente.Nome,
            Telefone = cliente.Telefone,
            Foto = cliente.Foto,
            Sexo = cliente.Sexo,
            CreatedAt = cliente.CreatedAt
        }).Cast<IClienteResponse>().ToList()
    };

    return Results.Ok(response);
})
.WithName("Detalhes da cidade")
.WithSummary("Esta rota retornará os detalhes de uma cidade específica com seus clientes")
.Produces<CidadeDetalhesResponse>();

app.Run();

public class Request
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Foto { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;
    public CidadeRequest Cidade { get; set; } = null!;
}

public class CidadeRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}
