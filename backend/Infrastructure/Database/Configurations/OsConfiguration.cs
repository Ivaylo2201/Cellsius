using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class OsConfiguration : IEntityTypeConfiguration<Os>
{
    public void Configure(EntityTypeBuilder<Os> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.OsName).HasConversion<string>();
    }
}