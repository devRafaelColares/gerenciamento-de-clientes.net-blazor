using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formulario.Api.Data.Mappings.Identity;

public class IdentityUsuarioClaimMapping : IEntityTypeConfiguration<IdentityUserClaim<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<long>> builder)
    {
        builder.ToTable("IdentityUsuarioClaim");
        builder.HasKey(uc => uc.Id);
        builder.Property(uc => uc.ClaimType).HasMaxLength(255);
        builder.Property(uc => uc.ClaimValue).HasMaxLength(255);
    }
}