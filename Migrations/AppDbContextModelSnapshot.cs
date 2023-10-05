﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBackendApp.Data;

#nullable disable

namespace MyBackendApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyBackendApp.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RestaurantTypeID")
                        .HasColumnType("int");

                    b.HasKey("RestaurantID");

                    b.HasIndex("RestaurantTypeID");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("MyBackendApp.Models.RestaurantMenu", b =>
                {
                    b.Property<int>("RestaurantMenuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MenuName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("RestaurantMenuID");

                    b.HasIndex("RestaurantID");

                    b.ToTable("RestaurantMenus");
                });

            modelBuilder.Entity("MyBackendApp.Models.RestaurantType", b =>
                {
                    b.Property<int>("RestaurantTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RestaurantTypeName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("RestaurantTypeID");

                    b.ToTable("RestaurantTypes");
                });

            modelBuilder.Entity("MyBackendApp.Models.Restaurant", b =>
                {
                    b.HasOne("MyBackendApp.Models.RestaurantType", "RestaurantType")
                        .WithMany("Restaurants")
                        .HasForeignKey("RestaurantTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RestaurantType");
                });

            modelBuilder.Entity("MyBackendApp.Models.RestaurantMenu", b =>
                {
                    b.HasOne("MyBackendApp.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantMenus")
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("MyBackendApp.Models.Restaurant", b =>
                {
                    b.Navigation("RestaurantMenus");
                });

            modelBuilder.Entity("MyBackendApp.Models.RestaurantType", b =>
                {
                    b.Navigation("Restaurants");
                });
#pragma warning restore 612, 618
        }
    }
}
