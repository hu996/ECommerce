﻿// <auto-generated />
using System;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerce.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    partial class ECommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "Arabic_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ECommerce.Models.BigImage", b =>
                {
                    b.Property<int>("BidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BigImage1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("BigImage");

                    b.HasKey("BidId");

                    b.ToTable("BigImage");
                });

            modelBuilder.Entity("ECommerce.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ECommerce.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Customerphone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ECommerce.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("categoryId");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PurchasPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float")
                        .HasColumnName("quantity");

                    b.Property<decimal>("SalesPrice")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ECommerce.Models.ItemImage", b =>
                {
                    b.Property<int>("ItemImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("ItemImageId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemImage");
                });

            modelBuilder.Entity("ECommerce.Models.SalesBridg", b =>
                {
                    b.Property<int>("SalesBridgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<decimal>("SalesPrice")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("SalesBridgId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ItemId");

                    b.ToTable("SalesBridg");
                });

            modelBuilder.Entity("ECommerce.Models.SalesInvoice", b =>
                {
                    b.Property<int>("InvoicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Deliverydate")
                        .HasColumnType("datetime");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OredrDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("InvoicId");

                    b.HasIndex("CustomerId");

                    b.ToTable("SalesInvoice");
                });

            modelBuilder.Entity("ECommerce.Models.Slider", b =>
                {
                    b.Property<int>("SliderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("SliderImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SliderId");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("ECommerce.Models.Item", b =>
                {
                    b.HasOne("ECommerce.Models.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Items_Category")
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ECommerce.Models.ItemImage", b =>
                {
                    b.HasOne("ECommerce.Models.Item", "Item")
                        .WithMany("ItemImages")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_ItemImage_Items")
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ECommerce.Models.SalesBridg", b =>
                {
                    b.HasOne("ECommerce.Models.SalesInvoice", "Invoice")
                        .WithMany("SalesBridgs")
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("FK_SalesBridg_SalesInvoice")
                        .IsRequired();

                    b.HasOne("ECommerce.Models.Item", "Item")
                        .WithMany("SalesBridgs")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_SalesBridg_Items")
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ECommerce.Models.SalesInvoice", b =>
                {
                    b.HasOne("ECommerce.Models.Customer", "Customer")
                        .WithMany("SalesInvoices")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_SalesInvoice_Customers")
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ECommerce.Models.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ECommerce.Models.Customer", b =>
                {
                    b.Navigation("SalesInvoices");
                });

            modelBuilder.Entity("ECommerce.Models.Item", b =>
                {
                    b.Navigation("ItemImages");

                    b.Navigation("SalesBridgs");
                });

            modelBuilder.Entity("ECommerce.Models.SalesInvoice", b =>
                {
                    b.Navigation("SalesBridgs");
                });
#pragma warning restore 612, 618
        }
    }
}
