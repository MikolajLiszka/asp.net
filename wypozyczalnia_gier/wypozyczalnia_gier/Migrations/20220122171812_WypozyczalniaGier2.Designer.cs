﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wypozyczalnia_gier.Models;

namespace wypozyczalnia_gier.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220122171812_WypozyczalniaGier2")]
    partial class WypozyczalniaGier2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("wypozyczalnia_gier.Models.Gra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CenaWypozyczeniaGry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeweloperGry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KategoriaGryId")
                        .HasColumnType("int");

                    b.Property<int>("PEGI")
                        .HasColumnType("int");

                    b.Property<string>("TytulGry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KategoriaGryId");

                    b.ToTable("Gry");
                });

            modelBuilder.Entity("wypozyczalnia_gier.Models.Kategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Kategorie");
                });

            modelBuilder.Entity("wypozyczalnia_gier.Models.Gra", b =>
                {
                    b.HasOne("wypozyczalnia_gier.Models.Kategoria", "KategoriaGry")
                        .WithMany()
                        .HasForeignKey("KategoriaGryId");

                    b.Navigation("KategoriaGry");
                });
#pragma warning restore 612, 618
        }
    }
}
