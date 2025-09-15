using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.Brand)
            .WithMany(x => x.Phones)
            .HasForeignKey(x => x.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(x => x.Model)
            .WithMany(x => x.Phones)
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Color)
            .WithMany(x => x.Phones)
            .HasForeignKey(x => x.ColorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(x => x.Items)
            .WithOne(x => x.Phone)
            .HasForeignKey(x => x.PhoneId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}