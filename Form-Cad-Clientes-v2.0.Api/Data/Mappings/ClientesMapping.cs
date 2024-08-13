using Formulario.Core.Models;

namespace Formulario.Api.Data.Mappings;

public class ClientesMapping : IEntityTypeConfiguration<Clientes>
{
    public void Configure(EntityTypeBuilder<Clientes> builder)
    {
        builder.ToTable("Clientes");
        
        builder.HasKey(x => x.Codigo).IsRequired().ValueGeneratedOnAdd();

        builder.Property(x => x.Nome).IsRequired().HasMaxLength(256);

        builder.Property(x => x.Telefone).IsRequired().HasMaxLength(20);

        builder.Property(x => x.Foto).IsRequired().HasMaxLength(256);

        builder.Property(x => x.Sexo).IsRequired().HasMaxLength(10);

        builder.Property(x => x.Cidade).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Estado).IsRequired();HasMaxLength(50);

        builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Cidade)
            .WithMany(c => c.Clientes)
            .HasForeignKey(x => x.CidadeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
