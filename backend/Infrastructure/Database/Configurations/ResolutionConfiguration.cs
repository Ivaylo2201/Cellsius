using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class ResolutionConfiguration : IEntityTypeConfiguration<Resolution>
{
    public void Configure(EntityTypeBuilder<Resolution> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ResolutionType).HasConversion<string>();
    }
}