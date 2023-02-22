﻿// <auto-generated />
using System;
using EShoppingAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EShoppingAPI.Persistence.Migrations
{
    [DbContext(typeof(EShoppingAPIDbContext))]
    [Migration("20230208135834_mg_3")]
    partial class mg3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EShoppingAPI.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("EShoppingAPI.Domain.Entities.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("files");

                    b.HasDiscriminator<string>("Discriminator").HasValue("File");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EShoppingAPI.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("customerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("customerId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("EShoppingAPI.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<Guid>("ordersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("productsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ordersId", "productsId");

                    b.HasIndex("productsId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("EShoppingAPI.Domain.Entities.InvoiceFile", b =>
                {
                    b.HasBaseType("EShoppingAPI.Domain.Entities.File");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("InvoiceFile");
                });

            modelBuilder.Entity("EShoppingAPI.Domain.Entities.ProductImageFile", b =>
                {
                    b.HasBaseType("EShoppingAPI.Domain.Entities.File");

                    b.Property<Guid>("productId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("productId");

                    b.HasDiscriminator().HasValue("ProductImageFile");
                });

            modelBuilder.Entity("EShoppingAPI.Domain.Entities.Order", b =>
                {
                    b.HasOne("EShoppingAPI.Domain.Entities.Customer", "customer")
                        .WithMany("orders")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("EShoppingAPI.Domain.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("ordersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShoppingAPI.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("productsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EShoppingAPI.Domain.Entities.ProductImageFile", b =>
                {
                    b.HasOne("EShoppingAPI.Domain.Entities.Product", "product")
                        .WithMany("productImageFiles")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("EShoppingAPI.Domain.Entities.Customer", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("EShoppingAPI.Domain.Entities.Product", b =>
                {
                    b.Navigation("productImageFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
