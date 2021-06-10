﻿// <auto-generated />
using MicroservicioHotel.AccessData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MicroservicioHotel.AccessData.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20210609183618_collate")]
    partial class collate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            Descripcion = "Habitación para una persona",
                            Nombre = "Individual"
                        },
                        new
                        {
                            CategoriaId = 2,
                            Descripcion = "Habitación para dos personas",
                            Nombre = "Matrimonial"
                        },
                        new
                        {
                            CategoriaId = 3,
                            Descripcion = "Habitación para cuatro personas",
                            Nombre = "Suite"
                        });
                });

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.FotoHotel", b =>
                {
                    b.Property<int>("FotoHotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("FotoHotelId");

                    b.HasIndex("HotelId");

                    b.ToTable("FotoHotel");
                });

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.Habitacion", b =>
                {
                    b.Property<int>("HabitacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("HabitacionId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("HotelId");

                    b.ToTable("Habitacion");
                });

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<string>("DireccionNum")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("DireccionObservaciones")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Estrellas")
                        .HasColumnType("int");

                    b.Property<decimal>("Latitud")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(10, 7)
                        .HasColumnType("decimal(10,7)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Longitud")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(10, 7)
                        .HasColumnType("decimal(10,7)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("HotelId");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.FotoHotel", b =>
                {
                    b.HasOne("MicroservicioHotel.Domain.Entities.Hotel", "Hotel")
                        .WithMany("FotosHotel")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.Habitacion", b =>
                {
                    b.HasOne("MicroservicioHotel.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Habitaciones")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicroservicioHotel.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Habitaciones")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Habitaciones");
                });

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("FotosHotel");

                    b.Navigation("Habitaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
