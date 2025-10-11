using System.Reflection;
using Backend.Domain.Entities;
using Backend.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<Brand> Brands => Set<Brand>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Battery>(x => x.Property(battery => battery.Type).HasConversion<string>());
        modelBuilder.Entity<Memory>(x => x.Property(memory => memory.Type).HasConversion<string>());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}