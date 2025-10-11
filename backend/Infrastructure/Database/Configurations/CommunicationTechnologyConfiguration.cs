using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class CommunicationTechnologyConfiguration : IEntityTypeConfiguration<CommunicationTechnology>
{
    public void Configure(EntityTypeBuilder<CommunicationTechnology> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.CommunicationTechnologyType)
            .HasConversion<string>();
    }
}