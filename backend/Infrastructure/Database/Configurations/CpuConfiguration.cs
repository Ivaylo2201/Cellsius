using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class CpuConfiguration : IEntityTypeConfiguration<Cpu>
{
    public void Configure(EntityTypeBuilder<Cpu> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Brand)
            .WithMany()
            .HasForeignKey(x => x.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Model)
            .WithMany()
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}