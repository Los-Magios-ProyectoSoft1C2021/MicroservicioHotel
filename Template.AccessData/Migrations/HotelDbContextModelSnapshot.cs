﻿// <auto-generated />
using MicroservicioHotel.AccessData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MicroservicioHotel.AccessData.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    partial class HotelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.Estrellas", b =>
                {
                    b.Property<int>("EstrellasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadEstrellas")
                        .HasColumnType("int");

                    b.HasKey("EstrellasId");

                    b.ToTable("Estrellas");

                    b.HasData(
                        new
                        {
                            EstrellasId = 1,
                            CantidadEstrellas = 1
                        },
                        new
                        {
                            EstrellasId = 2,
                            CantidadEstrellas = 2
                        },
                        new
                        {
                            EstrellasId = 3,
                            CantidadEstrellas = 3
                        },
                        new
                        {
                            EstrellasId = 4,
                            CantidadEstrellas = 4
                        },
                        new
                        {
                            EstrellasId = 5,
                            CantidadEstrellas = 5
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

                    b.Property<int>("EstrellasId")
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

                    b.HasIndex("EstrellasId");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.Servicio", b =>
                {
                    b.Property<int>("ServicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("ServicioId");

                    b.ToTable("Servicio");

                    b.HasData(
                        new
                        {
                            ServicioId = 1,
                            Descripcion = "Wi-Fi"
                        },
                        new
                        {
                            ServicioId = 2,
                            Descripcion = "Piscina"
                        },
                        new
                        {
                            ServicioId = 3,
                            Descripcion = "Servicio de guarda-equipaje"
                        },
                        new
                        {
                            ServicioId = 4,
                            Descripcion = "Desayuno"
                        },
                        new
                        {
                            ServicioId = 5,
                            Descripcion = "Ascensor"
                        },
                        new
                        {
                            ServicioId = 6,
                            Descripcion = "Recepción 24 hs"
                        },
                        new
                        {
                            ServicioId = 7,
                            Descripcion = "Recepción de paquetes gratis"
                        },
                        new
                        {
                            ServicioId = 8,
                            Descripcion = "Servicio a la habitación"
                        },
                        new
                        {
                            ServicioId = 9,
                            Descripcion = "Servicio de traslado en los alrededores (con costo adicional)"
                        },
                        new
                        {
                            ServicioId = 10,
                            Descripcion = "Servicio de planchado"
                        },
                        new
                        {
                            ServicioId = 11,
                            Descripcion = "Servicio de lavandería (con costo adicional)"
                        },
                        new
                        {
                            ServicioId = 12,
                            Descripcion = "Servicio de tintorería (con costo adicional)"
                        },
                        new
                        {
                            ServicioId = 13,
                            Descripcion = "Servicio de despertador"
                        },
                        new
                        {
                            ServicioId = 14,
                            Descripcion = "Casino"
                        },
                        new
                        {
                            ServicioId = 15,
                            Descripcion = "Servicio de masajes"
                        },
                        new
                        {
                            ServicioId = 16,
                            Descripcion = "Baño/tina de hidromasaje"
                        },
                        new
                        {
                            ServicioId = 17,
                            Descripcion = "Spa"
                        },
                        new
                        {
                            ServicioId = 18,
                            Descripcion = "Salón de juegos"
                        },
                        new
                        {
                            ServicioId = 19,
                            Descripcion = "Gimnasio"
                        },
                        new
                        {
                            ServicioId = 20,
                            Descripcion = "Sauna"
                        },
                        new
                        {
                            ServicioId = 21,
                            Descripcion = "TV en zonas comunes"
                        },
                        new
                        {
                            ServicioId = 22,
                            Descripcion = "Aire acondicionado en zonas comunes"
                        },
                        new
                        {
                            ServicioId = 23,
                            Descripcion = "Calefacción en zonas comunes"
                        });
                });

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.ServicioEstrellas", b =>
                {
                    b.Property<int>("ServicioEstrellaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstrellasId")
                        .HasColumnType("int");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("ServicioEstrellaId");

                    b.HasIndex("EstrellasId");

                    b.HasIndex("ServicioId");

                    b.ToTable("ServicioEstrellas");

                    b.HasData(
                        new
                        {
                            ServicioEstrellaId = 1,
                            EstrellasId = 5,
                            ServicioId = 1
                        },
                        new
                        {
                            ServicioEstrellaId = 2,
                            EstrellasId = 5,
                            ServicioId = 2
                        },
                        new
                        {
                            ServicioEstrellaId = 3,
                            EstrellasId = 5,
                            ServicioId = 3
                        },
                        new
                        {
                            ServicioEstrellaId = 4,
                            EstrellasId = 5,
                            ServicioId = 4
                        },
                        new
                        {
                            ServicioEstrellaId = 5,
                            EstrellasId = 5,
                            ServicioId = 5
                        },
                        new
                        {
                            ServicioEstrellaId = 6,
                            EstrellasId = 5,
                            ServicioId = 6
                        },
                        new
                        {
                            ServicioEstrellaId = 7,
                            EstrellasId = 5,
                            ServicioId = 7
                        },
                        new
                        {
                            ServicioEstrellaId = 8,
                            EstrellasId = 5,
                            ServicioId = 8
                        },
                        new
                        {
                            ServicioEstrellaId = 9,
                            EstrellasId = 5,
                            ServicioId = 9
                        },
                        new
                        {
                            ServicioEstrellaId = 10,
                            EstrellasId = 5,
                            ServicioId = 10
                        },
                        new
                        {
                            ServicioEstrellaId = 11,
                            EstrellasId = 5,
                            ServicioId = 11
                        },
                        new
                        {
                            ServicioEstrellaId = 12,
                            EstrellasId = 5,
                            ServicioId = 12
                        },
                        new
                        {
                            ServicioEstrellaId = 13,
                            EstrellasId = 5,
                            ServicioId = 13
                        },
                        new
                        {
                            ServicioEstrellaId = 14,
                            EstrellasId = 5,
                            ServicioId = 14
                        },
                        new
                        {
                            ServicioEstrellaId = 15,
                            EstrellasId = 5,
                            ServicioId = 15
                        },
                        new
                        {
                            ServicioEstrellaId = 16,
                            EstrellasId = 5,
                            ServicioId = 16
                        },
                        new
                        {
                            ServicioEstrellaId = 17,
                            EstrellasId = 5,
                            ServicioId = 17
                        },
                        new
                        {
                            ServicioEstrellaId = 18,
                            EstrellasId = 5,
                            ServicioId = 18
                        },
                        new
                        {
                            ServicioEstrellaId = 19,
                            EstrellasId = 5,
                            ServicioId = 19
                        },
                        new
                        {
                            ServicioEstrellaId = 20,
                            EstrellasId = 5,
                            ServicioId = 20
                        },
                        new
                        {
                            ServicioEstrellaId = 21,
                            EstrellasId = 5,
                            ServicioId = 21
                        },
                        new
                        {
                            ServicioEstrellaId = 22,
                            EstrellasId = 5,
                            ServicioId = 22
                        },
                        new
                        {
                            ServicioEstrellaId = 23,
                            EstrellasId = 5,
                            ServicioId = 23
                        },
                        new
                        {
                            ServicioEstrellaId = 24,
                            EstrellasId = 4,
                            ServicioId = 1
                        },
                        new
                        {
                            ServicioEstrellaId = 25,
                            EstrellasId = 4,
                            ServicioId = 2
                        },
                        new
                        {
                            ServicioEstrellaId = 26,
                            EstrellasId = 4,
                            ServicioId = 3
                        },
                        new
                        {
                            ServicioEstrellaId = 27,
                            EstrellasId = 4,
                            ServicioId = 4
                        },
                        new
                        {
                            ServicioEstrellaId = 28,
                            EstrellasId = 4,
                            ServicioId = 5
                        },
                        new
                        {
                            ServicioEstrellaId = 29,
                            EstrellasId = 4,
                            ServicioId = 6
                        },
                        new
                        {
                            ServicioEstrellaId = 30,
                            EstrellasId = 4,
                            ServicioId = 8
                        },
                        new
                        {
                            ServicioEstrellaId = 31,
                            EstrellasId = 4,
                            ServicioId = 10
                        },
                        new
                        {
                            ServicioEstrellaId = 32,
                            EstrellasId = 4,
                            ServicioId = 13
                        },
                        new
                        {
                            ServicioEstrellaId = 33,
                            EstrellasId = 4,
                            ServicioId = 18
                        },
                        new
                        {
                            ServicioEstrellaId = 34,
                            EstrellasId = 4,
                            ServicioId = 19
                        },
                        new
                        {
                            ServicioEstrellaId = 35,
                            EstrellasId = 4,
                            ServicioId = 21
                        },
                        new
                        {
                            ServicioEstrellaId = 36,
                            EstrellasId = 3,
                            ServicioId = 1
                        },
                        new
                        {
                            ServicioEstrellaId = 37,
                            EstrellasId = 3,
                            ServicioId = 4
                        },
                        new
                        {
                            ServicioEstrellaId = 38,
                            EstrellasId = 3,
                            ServicioId = 6
                        },
                        new
                        {
                            ServicioEstrellaId = 39,
                            EstrellasId = 3,
                            ServicioId = 8
                        },
                        new
                        {
                            ServicioEstrellaId = 40,
                            EstrellasId = 3,
                            ServicioId = 18
                        },
                        new
                        {
                            ServicioEstrellaId = 41,
                            EstrellasId = 3,
                            ServicioId = 21
                        },
                        new
                        {
                            ServicioEstrellaId = 42,
                            EstrellasId = 2,
                            ServicioId = 1
                        },
                        new
                        {
                            ServicioEstrellaId = 43,
                            EstrellasId = 3,
                            ServicioId = 6
                        },
                        new
                        {
                            ServicioEstrellaId = 44,
                            EstrellasId = 2,
                            ServicioId = 4
                        },
                        new
                        {
                            ServicioEstrellaId = 45,
                            EstrellasId = 2,
                            ServicioId = 8
                        },
                        new
                        {
                            ServicioEstrellaId = 46,
                            EstrellasId = 2,
                            ServicioId = 21
                        },
                        new
                        {
                            ServicioEstrellaId = 47,
                            EstrellasId = 1,
                            ServicioId = 1
                        },
                        new
                        {
                            ServicioEstrellaId = 48,
                            EstrellasId = 1,
                            ServicioId = 4
                        },
                        new
                        {
                            ServicioEstrellaId = 49,
                            EstrellasId = 1,
                            ServicioId = 6
                        });
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

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.Hotel", b =>
                {
                    b.HasOne("MicroservicioHotel.Domain.Entities.Estrellas", "Estrellas")
                        .WithMany()
                        .HasForeignKey("EstrellasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estrellas");
                });

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.ServicioEstrellas", b =>
                {
                    b.HasOne("MicroservicioHotel.Domain.Entities.Estrellas", "Estrellas")
                        .WithMany("Servicios")
                        .HasForeignKey("EstrellasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicroservicioHotel.Domain.Entities.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estrellas");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Habitaciones");
                });

            modelBuilder.Entity("MicroservicioHotel.Domain.Entities.Estrellas", b =>
                {
                    b.Navigation("Servicios");
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
