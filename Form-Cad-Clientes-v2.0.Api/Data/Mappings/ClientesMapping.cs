using Formulario.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formulario.Api.Data.Mappings;

public class ClientesMapping : IEntityTypeConfiguration<Clientes>
{
    public void Configure(EntityTypeBuilder<Clientes> builder)
    {
        builder.ToTable("Clientes");

        builder.HasKey(c => c.Codigo);

        builder.Property(c => c.Codigo)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Nome)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Telefone)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(c => c.Foto)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(500);

        builder.Property(c => c.Sexo)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20)
            .IsRequired();

        builder.HasOne(c => c.Cidade)
            .WithMany(c => c.Clientes)
            .HasForeignKey(c => c.CidadeId);
    }
}
