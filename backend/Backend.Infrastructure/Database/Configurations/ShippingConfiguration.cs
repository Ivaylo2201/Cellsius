using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
{
    public void Configure(EntityTypeBuilder<Shipping> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasMany(x => x.Orders)
            .WithOne(x => x.Shipping)
            .HasForeignKey(x => x.ShippingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}