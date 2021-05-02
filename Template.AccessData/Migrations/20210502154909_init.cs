using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroservicioHotel.AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DireccionNum = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DireccionObservaciones = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Estrellas = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(10,7)", precision: 10, scale: 7, nullable: false, defaultValue: 0m),
                    Latitud = table.Column<decimal>(type: "decimal(10,7)", precision: 10, scale: 7, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "FotoHotel",
                columns: table => new
                {
                    FotoHotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoHotel", x => x.FotoHotelId);
                    table.ForeignKey(
                        name: "FK_FotoHotel_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    HabitacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.HabitacionId);
                    table.ForeignKey(
                        name: "FK_Habitacion_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Habitacion_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre" },
                values: new object[] { new Guid("f6f54ec9-4f23-4a2a-9621-fca2f8a96096"), "Habitación para una persona", "Individual" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre" },
                values: new object[] { new Guid("5b9ad150-e421-4c25-acfb-ef415c344ad5"), "Habitación para dos personas", "Matrimonial" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre" },
                values: new object[] { new Guid("1f7f359e-a69a-4897-8bbe-9b45f05e79fd"), "Habitación para cuatro personas", "Suite" });

            migrationBuilder.CreateIndex(
                name: "IX_FotoHotel_HotelId",
                table: "FotoHotel",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_CategoriaId",
                table: "Habitacion",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_HotelId",
                table: "Habitacion",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FotoHotel");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
