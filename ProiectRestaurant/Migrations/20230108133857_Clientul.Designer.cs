﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectRestaurant.Data;

#nullable disable

namespace ProiectRestaurant.Migrations
{
    [DbContext(typeof(ProiectRestaurantContext))]
    [Migration("20230108133857_Clientul")]
    partial class Clientul
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProiectRestaurant.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FoodCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.Chef", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Chef");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.FoodCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("RestaurantID");

                    b.ToTable("FoodCategory");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.FoodType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FoodTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("FoodType");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("RestaurantID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.Restaurant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ChefsID")
                        .HasColumnType("int");

                    b.Property<string>("Dish_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FoodTypeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("MenuDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.HasIndex("ChefsID");

                    b.HasIndex("FoodTypeID");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.FoodCategory", b =>
                {
                    b.HasOne("ProiectRestaurant.Models.Category", "Category")
                        .WithMany("FoodCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProiectRestaurant.Models.Restaurant", "Restaurant")
                        .WithMany("FoodCategories")
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.Order", b =>
                {
                    b.HasOne("ProiectRestaurant.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientID");

                    b.HasOne("ProiectRestaurant.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantID");

                    b.Navigation("Client");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.Restaurant", b =>
                {
                    b.HasOne("ProiectRestaurant.Models.Chef", "Chefs")
                        .WithMany()
                        .HasForeignKey("ChefsID");

                    b.HasOne("ProiectRestaurant.Models.FoodType", "FoodType")
                        .WithMany("Restaurants")
                        .HasForeignKey("FoodTypeID");

                    b.Navigation("Chefs");

                    b.Navigation("FoodType");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.Category", b =>
                {
                    b.Navigation("FoodCategories");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.FoodType", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("ProiectRestaurant.Models.Restaurant", b =>
                {
                    b.Navigation("FoodCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
