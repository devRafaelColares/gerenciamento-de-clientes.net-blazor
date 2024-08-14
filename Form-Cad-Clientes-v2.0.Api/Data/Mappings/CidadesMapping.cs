using Formulario.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formulario.Api.Data.Mappings;

public class CidadesMapping : IEntityTypeConfiguration<Cidades>
{
    public void Configure(EntityTypeBuilder<Cidades> builder)
    {
        builder.ToTable("Cidades");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Nome)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Estado)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(25)
            .IsRequired();

        builder.HasMany(c => c.Clientes)
            .WithOne(c => c.Cidade)
            .HasForeignKey(c => c.CidadeId);
    }
}
