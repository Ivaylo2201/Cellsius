using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasMany(x => x.Phones)
            .WithOne(x => x.Color)
            .HasForeignKey(x => x.ColorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}