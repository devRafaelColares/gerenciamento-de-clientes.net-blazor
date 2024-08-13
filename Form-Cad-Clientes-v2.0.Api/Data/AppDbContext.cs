using Formulario.Core.Models;
using Formulario.Api.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Formulario.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Cidades> Cidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Cidades>().HasData(
            new Cidades { Nome = "São Paulo", Estado = "SP" },
            new Cidades { Nome = "Rio de Janeiro", Estado = "RJ" },
            new Cidades { Nome = "Belo Horizonte", Estado = "MG" }
            new Cidades { Nome = "Curitiba", Estado = "PR" }
            new Cidades { Nome = "Porto Alegre", Estado = "RS" }
            new Cidades { Nome = "Salvador", Estado = "BA" }
            new Cidades { Nome = "Recife", Estado = "PE" }
            new Cidades { Nome = "Fortaleza", Estado = "CE" }
            new Cidades { Nome = "Brasília", Estado = "DF" }
            new Cidades { Nome = "Goiânia", Estado = "GO" }
            new Cidades { Nome = "Manaus", Estado = "AM" }
            new Cidades { Nome = "Belém", Estado = "PA" }
            new Cidades { Nome = "Vitória", Estado = "ES" }
            new Cidades { Nome = "Florianópolis", Estado = "SC" }
            new Cidades { Nome = "Natal", Estado = "RN" }
            new Cidades { Nome = "João Pessoa", Estado = "PB" }
            new Cidades { Nome = "Teresina", Estado = "PI" }
            new Cidades { Nome = "Campo Grande", Estado = "MS" }
            new Cidades { Nome = "Cuiabá", Estado = "MT" }
            new Cidades { Nome = "São Luís", Estado = "MA" }
            new Cidades { Nome = "Palmas", Estado = "TO" }
            new Cidades { Nome = "Boa Vista", Estado = "RR" }
            new Cidades { Nome = "Macapá", Estado = "AP" }
            new Cidades { Nome = "Porto Velho", Estado = "RO" }
            new Cidades { Nome = "Rio Branco", Estado = "AC" }
            new Cidades { Nome = "Araguaína", Estado = "TO" }
            new Cidades { Nome = "Arapiraca", Estado = "AL" }
        );

        modelBuilder.ApplyConfiguration(new ClientesMapping());
        modelBuilder.ApplyConfiguration(new CidadesMapping());
    }
}
