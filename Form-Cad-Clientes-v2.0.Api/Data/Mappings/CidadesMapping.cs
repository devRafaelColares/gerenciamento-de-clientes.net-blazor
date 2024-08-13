using Formulario.Core.Models;
namespace Formulario.Api.Data.Mappings
{
    public class CidadesMapping : IEntityTypeConfiguration<Cidades>
    {
        public void Configure(EntityTypeBuilder<Cidades> builder)
        {
            builder.ToTable("Cidades");
            
            builder.HasKey(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.Cidade)
                   .WithMany(c => c.Clientes)
                   .HasForeignKey(x => x.CidadeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}