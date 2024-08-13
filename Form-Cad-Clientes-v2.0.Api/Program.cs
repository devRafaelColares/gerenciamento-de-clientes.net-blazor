using Microsoft.EntityFrameworkCore;
using Formulario.Api.Data;
using Formulario.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration
    .GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(ConnectionString));

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
    var response = new Response
    {
        Codigo = cliente.Codigo, // O ID gerado pelo banco de dados
        Nome = cliente.Nome,
        Telefone = cliente.Telefone,
        Foto = cliente.Foto,
        Sexo = cliente.Sexo,
        Cidade = new CidadeResponse
        {
            Id = cliente.Cidade.Id,
            Nome = cliente.Cidade.Nome,
            Estado = cliente.Cidade.Estado
        },
        CreatedAt = DateTime.UtcNow
    };

    return Results.Created($"/Clientes/{response.Codigo}", response);
})
.WithName("Cadastro de clientes")
.WithSummary("Esta rota servirá para cadastrar novos clientes")
.Produces<Response>(StatusCodes.Status201Created);

// Endpoint GET /Clientes
app.MapGet("/Clientes", async (AppDbContext context) =>
{
    var clientes = await context.Clientes
        .Include(c => c.Cidade)
        .ToListAsync();

    var response = clientes.Select(c => new Response
    {
        Codigo = c.Codigo,
        Nome = c.Nome,
        Telefone = c.Telefone,
        Foto = c.Foto,
        Sexo = c.Sexo,
        Cidade = new CidadeResponse
        {
            Id = c.Cidade.Id,
            Nome = c.Cidade.Nome,
            Estado = c.Cidade.Estado
        },
        CreatedAt = c.CreatedAt
    }).ToList();

    return Results.Ok(response);
})
.WithName("Listagem de clientes")
.WithSummary("Esta rota retornará a lista de clientes")
.Produces<List<Response>>();

// Endpoint GET /Cidades
app.MapGet("/Cidades", async (AppDbContext context) =>
{
    var cidades = await context.Cidades
        .Include(c => c.Clientes)
        .ToListAsync();

    var response = cidades.Select(c => new CidadeDetalhesResponse
    {
        Id = c.Id,
        Nome = c.Nome,
        Estado = c.Estado,
        Clientes = c.Clientes.Select(cliente => new Response
        {
            Codigo = cliente.Codigo,
            Nome = cliente.Nome,
            Telefone = cliente.Telefone,
            Foto = cliente.Foto,
            Sexo = cliente.Sexo,
            Cidade = new CidadeResponse
            {
                Id = cliente.Cidade.Id,
                Nome = cliente.Cidade.Nome,
                Estado = cliente.Cidade.Estado
            },
            CreatedAt = cliente.CreatedAt
        }).ToList()
    }).ToList();

    return Results.Ok(response);
})
.WithName("Listagem de cidades com clientes")
.WithSummary("Esta rota retornará a lista de cidades com seus clientes")
.Produces<List<CidadeDetalhesResponse>>();

app.Run();

public class Request
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Foto { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;
    public CidadeRequest Cidade { get; set; } = null!;
}

public class Response
{
    public long Codigo { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Foto { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;
    public CidadeResponse Cidade { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class CidadeRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}

public class CidadeResponse
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}

public class CidadeDetalhesResponse
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public List<Response> Clientes { get; set; } = new List<Response>();
}
