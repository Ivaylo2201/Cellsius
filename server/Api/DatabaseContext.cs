using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Color> Colors => Set<Color>();
        public DbSet<Model> Models => Set<Model>();
        public DbSet<Phone> Phones => Set<Phone>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Shipping> Shippings => Set<Shipping>();

        protected void Seed(ModelBuilder modelBuilder)
        {
            var user = new User
            {
                Id = 1,
                Username = "Ivaylo",
                Email = "ivailo_g03@abv.bg",
                Password = BCrypt.Net.BCrypt.HashPassword("12345"),
            };

            var cart = new Cart
            {
                Id = 1,
                UserId = user.Id
            };

            modelBuilder.Entity<Cart>().HasData(cart);
            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<Shipping>().HasData(
                new Shipping { Id = 1, Type = "Standard", Cost = 0, Days = 7 },
                new Shipping { Id = 2, Type = "Express", Cost = 15, Days = 3 },
                new Shipping { Id = 3, Type = "Next-Day", Cost = 25, Days = 1 },
                new Shipping { Id = 4, Type = "Same-Day", Cost = 40, Days = 0 }
            );

            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Samsung" },
                new Brand { Id = 2, Name = "Apple" },
                new Brand { Id = 3, Name = "Xiaomi" }
            );

            modelBuilder.Entity<Model>().HasData(
                new Model { Id = 1, Name = "Galaxy S24 Ultra", BrandId = 1 },
                new Model { Id = 2, Name = "Galaxy S25", BrandId = 1 },
                new Model { Id = 3, Name = "Galaxy A16", BrandId = 1 },
                new Model { Id = 4, Name = "Galaxy Z Flip 6", BrandId = 1 },
                new Model { Id = 5, Name = "iPhone 16 Pro Max", BrandId = 2 },
                new Model { Id = 6, Name = "iPhone 15", BrandId = 2 },
                new Model { Id = 7, Name = "iPhone 14", BrandId = 2 },
                new Model { Id = 8, Name = "14T Pro", BrandId = 3 },
                new Model { Id = 9, Name = "Redmi Note 12 Pro", BrandId = 3 },
                new Model { Id = 10, Name = "13", BrandId = 3 }
            );

            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Black" },
                new Color { Id = 2, Name = "White" },
                new Color { Id = 3, Name = "Blue" },
                new Color { Id = 4, Name = "Gray" },
                new Color { Id = 5, Name = "Gold" },
                new Color { Id = 6, Name = "Pink" },
                new Color { Id = 7, Name = "Mint" }
            );

            modelBuilder.Entity<Phone>().HasData(
                new Phone { Id = 1, BrandId = 1, ModelId = 1, ColorId = 5, DiscountPercentage = 15, InitialPrice = 1300, Memory = 512, ImagePath = "/uploads/samsung-galaxy-s24ultra.jpg" },
                new Phone { Id = 2, BrandId = 1, ModelId = 2, ColorId = 7, InitialPrice = 450, Memory = 64, ImagePath = "/uploads/samsung-galaxy-s25.jpg" },
                new Phone { Id = 3, BrandId = 1, ModelId = 3, ColorId = 1, DiscountPercentage = 25, InitialPrice = 500, Memory = 128, ImagePath = "/uploads/samsung-galaxy-a16.jpg" },
                new Phone { Id = 4, BrandId = 1, ModelId = 4, ColorId = 3, InitialPrice = 1200, Memory = 512, ImagePath = "/uploads/samsung-galaxy-zflip6.jpg" },
                new Phone { Id = 5, BrandId = 2, ModelId = 5, ColorId = 2, DiscountPercentage = 40, InitialPrice = 2000, Memory = 512, ImagePath = "/uploads/apple-iphone-16promax.jpg" },
                new Phone { Id = 6, BrandId = 2, ModelId = 6, ColorId = 1, InitialPrice = 1750, Memory = 256, ImagePath = "/uploads/apple-iphone-15.jpg" },
                new Phone { Id = 7, BrandId = 3, ModelId = 8, ColorId = 1, DiscountPercentage = 10, InitialPrice = 300, Memory = 128, ImagePath = "/uploads/xiaomi-14t-pro.jpg" },
                new Phone { Id = 9, BrandId = 3, ModelId = 10, ColorId = 6, InitialPrice = 700, Memory = 256, ImagePath = "/uploads/xiaomi-redmi-13.jpg" }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);

            modelBuilder.Entity<Phone>()
                .Property(p => p.Price)
                .HasComputedColumnSql("[InitialPrice] * (1 - [DiscountPercentage] / 100.0)");

            this.Seed(modelBuilder);
        }
    }
}
