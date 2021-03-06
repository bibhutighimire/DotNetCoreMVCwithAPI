﻿// <auto-generated />
using System;
using MVCwithAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCwithAPI.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20200924220132_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MVCwithAPI.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int(10)");

                    b.Property<bool?>("IsDiscontinued")
                        .IsRequired()
                        .HasColumnName("isDiscontinued")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnName("quantity")
                        .HasColumnType("int(10)");

                    b.HasKey("ID");

                    b.ToTable("product");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            IsDiscontinued = false,
                            Name = "Tomato",
                            Quantity = 49
                        },
                        new
                        {
                            ID = -2,
                            IsDiscontinued = false,
                            Name = "Metal",
                            Quantity = 75
                        },
                        new
                        {
                            ID = -3,
                            IsDiscontinued = false,
                            Name = "Jacket",
                            Quantity = 33
                        },
                        new
                        {
                            ID = -4,
                            IsDiscontinued = true,
                            Name = "Chair",
                            Quantity = 45
                        },
                        new
                        {
                            ID = -5,
                            IsDiscontinued = false,
                            Name = "Pet Food",
                            Quantity = 100
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
