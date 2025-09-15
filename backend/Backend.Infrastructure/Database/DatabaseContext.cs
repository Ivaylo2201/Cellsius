using Backend.Domain.Entities;
using Backend.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<Color> Colors => Set<Color>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Model> Models => Set<Model>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Phone> Phones => Set<Phone>();
    public DbSet<Shipping> Shippings => Set<Shipping>();
    public DbSet<User> Users => Set<User>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BrandConfiguration());
        modelBuilder.ApplyConfiguration(new CartConfiguration());
        modelBuilder.ApplyConfiguration(new ColorConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new ModelConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new PhoneConfiguration());
        modelBuilder.ApplyConfiguration(new ShippingConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}