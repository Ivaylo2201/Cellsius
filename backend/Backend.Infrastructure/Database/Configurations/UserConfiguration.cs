using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.Cart)
            .WithOne(x => x.User)
            .HasForeignKey<Cart>(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}