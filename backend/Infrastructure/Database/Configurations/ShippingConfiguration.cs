using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
{
    public void Configure(EntityTypeBuilder<Shipping> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ShippingType).HasConversion<string>();
    }
}