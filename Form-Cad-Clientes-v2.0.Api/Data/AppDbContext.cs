using System.Reflection;

using Formulario.Core.Models;
using Formulario.Api.Models;
using Formulario.Api.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Formulario.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : IdentityDbContext<
        Usuario,
        IdentityRole<long>, long,
        IdentityUserClaim<long>,
        IdentityUserRole<long>,
        IdentityUserLogin<long>,
        IdentityRoleClaim<long>,
        IdentityUserToken<long>
        >(options)
{

    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Cidades> Cidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new CidadesMapping());
        // modelBuilder.ApplyConfiguration(new ClientesMapping());

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        modelBuilder.Entity<Cidades>().HasData(
            new Cidades { Id = 1, Nome = "São Paulo", Estado = "SP" },
            new Cidades { Id = 2, Nome = "Rio de Janeiro", Estado = "RJ" },
            new Cidades { Id = 3, Nome = "Belo Horizonte", Estado = "MG" },
            new Cidades { Id = 4, Nome = "Curitiba", Estado = "PR" },
            new Cidades { Id = 5, Nome = "Porto Alegre", Estado = "RS" },
            new Cidades { Id = 6, Nome = "Salvador", Estado = "BA" },
            new Cidades { Id = 7, Nome = "Recife", Estado = "PE" },
            new Cidades { Id = 8, Nome = "Fortaleza", Estado = "CE" },
            new Cidades { Id = 9, Nome = "Brasília", Estado = "DF" },
            new Cidades { Id = 10, Nome = "Goiânia", Estado = "GO" },
            new Cidades { Id = 11, Nome = "Manaus", Estado = "AM" },
            new Cidades { Id = 12, Nome = "Belém", Estado = "PA" },
            new Cidades { Id = 13, Nome = "Vitória", Estado = "ES" },
            new Cidades { Id = 14, Nome = "Florianópolis", Estado = "SC" },
            new Cidades { Id = 15, Nome = "Natal", Estado = "RN" },
            new Cidades { Id = 16, Nome = "João Pessoa", Estado = "PB" },
            new Cidades { Id = 17, Nome = "Teresina", Estado = "PI" },
            new Cidades { Id = 18, Nome = "Campo Grande", Estado = "MS" },
            new Cidades { Id = 19, Nome = "Cuiabá", Estado = "MT" },
            new Cidades { Id = 20, Nome = "São Luís", Estado = "MA" },
            new Cidades { Id = 21, Nome = "Palmas", Estado = "TO" },
            new Cidades { Id = 22, Nome = "Boa Vista", Estado = "RR" },
            new Cidades { Id = 23, Nome = "Macapá", Estado = "AP" },
            new Cidades { Id = 24, Nome = "Porto Velho", Estado = "RO" },
            new Cidades { Id = 25, Nome = "Rio Branco", Estado = "AC" },
            new Cidades { Id = 26, Nome = "Araguaína", Estado = "TO" },
            new Cidades { Id = 27, Nome = "Arapiraca", Estado = "AL" }
        );

    }
}
