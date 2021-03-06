// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wypozyczalnia_gier.Models;

namespace wypozyczalnia_gier.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220117153102_WypozyczalniaGier")]
    partial class WypozyczalniaGier
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

                    b.Property<string>("KategoriaGry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PEGI")
                        .HasColumnType("int");

                    b.Property<string>("TytulGry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gry");
                });
#pragma warning restore 612, 618
        }
    }
}
