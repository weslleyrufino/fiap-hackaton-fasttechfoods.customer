﻿// <auto-generated />
using System;
using FastTechFoods.Customer.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FastTechFoods.Customer.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250719233211_InitialCustomerCreate")]
    partial class InitialCustomerCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FastTechFoods.Customer.Domain.Entities.CustomerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("FastTechFoods.Customer.Domain.Entities.MenuItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("BIT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(10,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.ToTable("MenuItems", (string)null);
                });

            modelBuilder.Entity("FastTechFoods.Customer.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("CancellationReason")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("DeliveryMethod")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("FastTechFoods.Customer.Domain.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid>("MenuItemId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INT");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("DECIMAL(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems", (string)null);
                });

            modelBuilder.Entity("FastTechFoods.Customer.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("FastTechFoods.Customer.Domain.Entities.MenuItem", null)
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FastTechFoods.Customer.Domain.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FastTechFoods.Customer.Domain.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
