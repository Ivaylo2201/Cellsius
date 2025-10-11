using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class TvConfiguration : IEntityTypeConfiguration<Tv>
{
    public void Configure(EntityTypeBuilder<Tv> builder)
    {
        builder
            .HasBaseType<ProductBase>();
        
        builder
            .HasOne(x => x.Matrix)
            .WithMany()
            .HasForeignKey(x => x.MatrixId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}