using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class SmartphoneConfiguration : IEntityTypeConfiguration<Smartphone>
{
    public void Configure(EntityTypeBuilder<Smartphone> builder)
    {
        builder
            .HasBaseType<ProductBase>();
        
        builder
            .HasOne(x => x.Display)
            .WithMany()
            .HasForeignKey(x => x.DisplayId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(x => x.CommunicationTechnology)
            .WithMany()
            .HasForeignKey(x => x.CommunicationTechnologyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}