using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.ModelName)
            .IsRequired();
        
        builder
            .HasOne(x => x.Brand)
            .WithMany(x => x.Models)
            .HasForeignKey(x => x.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(x => x.Phones)
            .WithOne(x => x.Model)
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}