using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class MatrixConfiguration : IEntityTypeConfiguration<Matrix>
{
    public void Configure(EntityTypeBuilder<Matrix> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.MatrixType).HasConversion<string>();
    }
}