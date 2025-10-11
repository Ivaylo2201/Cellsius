using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class LaptopConfiguration : IEntityTypeConfiguration<Laptop>
{
    public void Configure(EntityTypeBuilder<Laptop> builder)
    {
        builder
            .HasBaseType<ProductBase>();
            
        builder
            .HasOne(x => x.Cpu)
            .WithMany()
            .HasForeignKey(x => x.CpuId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}