﻿// <auto-generated />
using System;
using Empresa_Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Empresa_Productos.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230705004455_prueba")]
    partial class prueba
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Empresa_Productos.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SupplierId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f7d31d43-485b-4499-9502-97c3cf0c8100"),
                            CreationDate = new DateTime(2023, 7, 4, 19, 44, 55, 55, DateTimeKind.Local).AddTicks(8730),
                            Name = "Televisor",
                            Price = 1200000,
                            SupplierId = "9027"
                        },
                        new
                        {
                            Id = new Guid("f7d31d43-485b-4499-9502-97c3cf0c8101"),
                            CreationDate = new DateTime(2023, 7, 4, 19, 44, 55, 55, DateTimeKind.Local).AddTicks(8760),
                            Name = "Computador",
                            Price = 1800000,
                            SupplierId = "9027"
                        },
                        new
                        {
                            Id = new Guid("f7d31d43-485b-4499-9502-97c3cf0c8102"),
                            CreationDate = new DateTime(2023, 7, 4, 19, 44, 55, 55, DateTimeKind.Local).AddTicks(8760),
                            Name = "Equipo de sonido",
                            Price = 900000,
                            SupplierId = "9027"
                        },
                        new
                        {
                            Id = new Guid("f7d31d43-485b-4499-9502-97c3cf0c8103"),
                            CreationDate = new DateTime(2023, 7, 4, 19, 44, 55, 55, DateTimeKind.Local).AddTicks(8770),
                            Name = "Cortinas",
                            Price = 250000,
                            SupplierId = "2271"
                        },
                        new
                        {
                            Id = new Guid("f7d31d43-485b-4499-9502-97c3cf0c8104"),
                            CreationDate = new DateTime(2023, 7, 4, 19, 44, 55, 55, DateTimeKind.Local).AddTicks(8770),
                            Name = "Armario",
                            Price = 900000,
                            SupplierId = "2271"
                        });
                });

            modelBuilder.Entity("Empresa_Productos.Models.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<double?>("FinalPrice")
                        .HasColumnType("float");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Tax")
                        .HasColumnType("int");

                    b.Property<string>("UserNit")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserNit");

                    b.ToTable("Sale", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f7d31d43-485b-4499-9502-97c3cf0e8100"),
                            Amount = 2,
                            FinalPrice = 2400000.0,
                            ProductId = new Guid("f7d31d43-485b-4499-9502-97c3cf0c8100"),
                            SaleDate = new DateTime(2023, 7, 4, 19, 44, 55, 56, DateTimeKind.Local).AddTicks(1510),
                            Tax = 19,
                            UserNit = "8080"
                        },
                        new
                        {
                            Id = new Guid("f7d31d43-485b-4499-9502-97c3cf0e8101"),
                            Amount = 1,
                            FinalPrice = 1800000.0,
                            ProductId = new Guid("f7d31d43-485b-4499-9502-97c3cf0c8101"),
                            SaleDate = new DateTime(2023, 7, 4, 19, 44, 55, 56, DateTimeKind.Local).AddTicks(1530),
                            Tax = 19,
                            UserNit = "1398"
                        });
                });

            modelBuilder.Entity("Empresa_Productos.Models.Supplier", b =>
                {
                    b.Property<string>("Nit")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Nit");

                    b.ToTable("Supplier", (string)null);

                    b.HasData(
                        new
                        {
                            Nit = "9027",
                            Cel = "3101285739",
                            Email = "ana@correo.com",
                            Name = "Ana"
                        },
                        new
                        {
                            Nit = "2271",
                            Cel = "3158429046",
                            Email = "manuel@correo.com",
                            Name = "Manuel",
                            Tel = "6017922798"
                        });
                });

            modelBuilder.Entity("Empresa_Productos.Models.User", b =>
                {
                    b.Property<string>("Nit")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Nit");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Nit = "1013",
                            Name = "Edgar",
                            Password = "850518",
                            Role = 0,
                            UserName = "E1230"
                        },
                        new
                        {
                            Nit = "8080",
                            Name = "Jose",
                            Password = "12xx",
                            Role = 1,
                            UserName = "J87"
                        },
                        new
                        {
                            Nit = "1398",
                            Name = "Diana",
                            Password = "asd85",
                            Role = 1,
                            UserName = "DIANA"
                        });
                });

            modelBuilder.Entity("Empresa_Productos.Models.Product", b =>
                {
                    b.HasOne("Empresa_Productos.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Empresa_Productos.Models.Sale", b =>
                {
                    b.HasOne("Empresa_Productos.Models.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("ProductId");

                    b.HasOne("Empresa_Productos.Models.User", "User")
                        .WithMany("Sales")
                        .HasForeignKey("UserNit");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Empresa_Productos.Models.Product", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Empresa_Productos.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Empresa_Productos.Models.User", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
