using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class DisplayConfiguration : IEntityTypeConfiguration<Display>
{
    public void Configure(EntityTypeBuilder<Display> builder)
    {
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.DisplayType)
            .HasConversion<string>();
    }
}