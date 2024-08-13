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
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(c => c.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Telefone)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(c => c.Foto)
            .HasMaxLength(500);

        builder.Property(c => c.Sexo)
            .HasMaxLength(1)
            .IsRequired();

        builder.HasOne(c => c.Cidade)
            .WithMany()
            .HasForeignKey(c => c.CidadeId);
    }
}
