﻿// <auto-generated />
using System;
using Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("Api.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Xiaomi"
                        });
                });

            modelBuilder.Entity("Api.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Api.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Black"
                        },
                        new
                        {
                            Id = 2,
                            Name = "White"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Blue"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Gray"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Gold"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Pink"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Mint"
                        });
                });

            modelBuilder.Entity("Api.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CartId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PhoneId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PhoneId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Api.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Name = "Galaxy S24 Ultra"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            Name = "Galaxy S25"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            Name = "Galaxy A16"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 1,
                            Name = "Galaxy Z Flip 6"
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 2,
                            Name = "iPhone 16 Pro Max"
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 2,
                            Name = "iPhone 15"
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 2,
                            Name = "iPhone 14"
                        },
                        new
                        {
                            Id = 8,
                            BrandId = 3,
                            Name = "14T Pro"
                        },
                        new
                        {
                            Id = 9,
                            BrandId = 3,
                            Name = "Redmi Note 12 Pro"
                        },
                        new
                        {
                            Id = 10,
                            BrandId = 3,
                            Name = "13"
                        });
                });

            modelBuilder.Entity("Api.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("ShippingId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ShippingId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Api.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiscountPercentage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("InitialPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("Memory")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModelId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TEXT")
                        .HasComputedColumnSql("[InitialPrice] * (1 - [DiscountPercentage] / 100.0)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ColorId");

                    b.HasIndex("ModelId");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            ColorId = 5,
                            DiscountPercentage = 15,
                            ImagePath = "/uploads/samsung-galaxy-s24ultra.jpg",
                            InitialPrice = 1300m,
                            Memory = 512,
                            ModelId = 1,
                            Price = 0m
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            ColorId = 7,
                            DiscountPercentage = 0,
                            ImagePath = "/uploads/samsung-galaxy-s25.jpg",
                            InitialPrice = 450m,
                            Memory = 64,
                            ModelId = 2,
                            Price = 0m
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            ColorId = 1,
                            DiscountPercentage = 25,
                            ImagePath = "/uploads/samsung-galaxy-a16.jpg",
                            InitialPrice = 500m,
                            Memory = 128,
                            ModelId = 3,
                            Price = 0m
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 1,
                            ColorId = 3,
                            DiscountPercentage = 0,
                            ImagePath = "/uploads/samsung-galaxy-zflip6.jpg",
                            InitialPrice = 1200m,
                            Memory = 512,
                            ModelId = 4,
                            Price = 0m
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 2,
                            ColorId = 2,
                            DiscountPercentage = 40,
                            ImagePath = "/uploads/apple-iphone-16promax.jpg",
                            InitialPrice = 2000m,
                            Memory = 512,
                            ModelId = 5,
                            Price = 0m
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 2,
                            ColorId = 1,
                            DiscountPercentage = 0,
                            ImagePath = "/uploads/apple-iphone-15.jpg",
                            InitialPrice = 1750m,
                            Memory = 256,
                            ModelId = 6,
                            Price = 0m
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 3,
                            ColorId = 1,
                            DiscountPercentage = 10,
                            ImagePath = "/uploads/xiaomi-14t-pro.jpg",
                            InitialPrice = 300m,
                            Memory = 128,
                            ModelId = 8,
                            Price = 0m
                        },
                        new
                        {
                            Id = 9,
                            BrandId = 3,
                            ColorId = 6,
                            DiscountPercentage = 0,
                            ImagePath = "/uploads/xiaomi-redmi-13.jpg",
                            InitialPrice = 700m,
                            Memory = 256,
                            ModelId = 10,
                            Price = 0m
                        });
                });

            modelBuilder.Entity("Api.Models.Shipping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Days")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Shippings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 0,
                            Days = 7,
                            Type = "Standard"
                        },
                        new
                        {
                            Id = 2,
                            Cost = 15,
                            Days = 3,
                            Type = "Express"
                        },
                        new
                        {
                            Id = 3,
                            Cost = 25,
                            Days = 1,
                            Type = "Next-Day"
                        },
                        new
                        {
                            Id = 4,
                            Cost = 40,
                            Days = 0,
                            Type = "Same-Day"
                        });
                });

            modelBuilder.Entity("Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Api.Models.Cart", b =>
                {
                    b.HasOne("Api.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("Api.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Models.Item", b =>
                {
                    b.HasOne("Api.Models.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId");

                    b.HasOne("Api.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("Api.Models.Phone", "Phone")
                        .WithMany("Items")
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Order");

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("Api.Models.Model", b =>
                {
                    b.HasOne("Api.Models.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Api.Models.Order", b =>
                {
                    b.HasOne("Api.Models.Shipping", "Shipping")
                        .WithMany("Orders")
                        .HasForeignKey("ShippingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipping");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Models.Phone", b =>
                {
                    b.HasOne("Api.Models.Brand", "Brand")
                        .WithMany("Phones")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Color", "Color")
                        .WithMany("Phones")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Model", "Model")
                        .WithMany("Phones")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Color");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Api.Models.Brand", b =>
                {
                    b.Navigation("Models");

                    b.Navigation("Phones");
                });

            modelBuilder.Entity("Api.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Api.Models.Color", b =>
                {
                    b.Navigation("Phones");
                });

            modelBuilder.Entity("Api.Models.Model", b =>
                {
                    b.Navigation("Phones");
                });

            modelBuilder.Entity("Api.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Api.Models.Phone", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Api.Models.Shipping", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Api.Models.User", b =>
                {
                    b.Navigation("Cart");
                });
#pragma warning restore 612, 618
        }
    }
}
