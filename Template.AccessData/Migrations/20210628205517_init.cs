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
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Estrellas",
                columns: table => new
                {
                    EstrellasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadEstrellas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estrellas", x => x.EstrellasId);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.ServicioId);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstrellasId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Ciudad = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Direccion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    DireccionNum = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DireccionObservaciones = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(10,7)", precision: 10, scale: 7, nullable: false, defaultValue: 0m),
                    Latitud = table.Column<decimal>(type: "decimal(10,7)", precision: 10, scale: 7, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_Hotel_Estrellas_EstrellasId",
                        column: x => x.EstrellasId,
                        principalTable: "Estrellas",
                        principalColumn: "EstrellasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicioEstrellas",
                columns: table => new
                {
                    ServicioEstrellaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    EstrellasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioEstrellas", x => x.ServicioEstrellaId);
                    table.ForeignKey(
                        name: "FK_ServicioEstrellas_Estrellas_EstrellasId",
                        column: x => x.EstrellasId,
                        principalTable: "Estrellas",
                        principalColumn: "EstrellasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioEstrellas_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
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
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
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
                values: new object[,]
                {
                    { 1, "Habitación para una persona", "Individual" },
                    { 2, "Habitación para dos personas", "Matrimonial" },
                    { 3, "Habitación para cuatro personas", "Suite" }
                });

            migrationBuilder.InsertData(
                table: "Estrellas",
                columns: new[] { "EstrellasId", "CantidadEstrellas" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Servicio",
                columns: new[] { "ServicioId", "Descripcion" },
                values: new object[,]
                {
                    { 14, "Casino" },
                    { 15, "Servicio de masajes" },
                    { 16, "Baño/tina de hidromasaje" },
                    { 17, "Spa" },
                    { 21, "TV en zonas comunes" },
                    { 19, "Gimnasio" },
                    { 20, "Sauna" },
                    { 13, "Servicio de despertador" },
                    { 18, "Salón de juegos" },
                    { 12, "Servicio de tintorería (con costo adicional)" },
                    { 8, "Servicio a la habitación" },
                    { 10, "Servicio de planchado" },
                    { 9, "Servicio de traslado en los alrededores (con costo adicional)" },
                    { 22, "Aire acondicionado en zonas comunes" },
                    { 7, "Recepción de paquetes gratis" },
                    { 6, "Recepción 24 hs" },
                    { 5, "Ascensor" },
                    { 4, "Desayuno" },
                    { 3, "Servicio de guarda-equipaje" },
                    { 2, "Piscina" },
                    { 1, "Wi-Fi" },
                    { 11, "Servicio de lavandería (con costo adicional)" },
                    { 23, "Calefacción en zonas comunes" }
                });

            migrationBuilder.InsertData(
                table: "ServicioEstrellas",
                columns: new[] { "ServicioEstrellaId", "EstrellasId", "ServicioId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 9, 5, 9 },
                    { 10, 5, 10 },
                    { 31, 4, 10 },
                    { 11, 5, 11 },
                    { 12, 5, 12 },
                    { 13, 5, 13 },
                    { 32, 4, 13 },
                    { 14, 5, 14 },
                    { 15, 5, 15 },
                    { 16, 5, 16 },
                    { 17, 5, 17 },
                    { 18, 5, 18 },
                    { 33, 4, 18 },
                    { 40, 3, 18 },
                    { 19, 5, 19 },
                    { 34, 4, 19 },
                    { 20, 5, 20 },
                    { 21, 5, 21 },
                    { 35, 4, 21 },
                    { 41, 3, 21 },
                    { 46, 2, 21 },
                    { 45, 2, 8 },
                    { 22, 5, 22 },
                    { 39, 3, 8 },
                    { 8, 5, 8 },
                    { 24, 4, 1 },
                    { 36, 3, 1 },
                    { 42, 2, 1 },
                    { 47, 1, 1 },
                    { 2, 5, 2 },
                    { 25, 4, 2 },
                    { 3, 5, 3 },
                    { 26, 4, 3 },
                    { 4, 5, 4 },
                    { 27, 4, 4 },
                    { 37, 3, 4 },
                    { 44, 2, 4 },
                    { 48, 1, 4 },
                    { 5, 5, 5 },
                    { 28, 4, 5 },
                    { 6, 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "ServicioEstrellas",
                columns: new[] { "ServicioEstrellaId", "EstrellasId", "ServicioId" },
                values: new object[,]
                {
                    { 29, 4, 6 },
                    { 38, 3, 6 },
                    { 43, 3, 6 },
                    { 49, 1, 6 },
                    { 7, 5, 7 },
                    { 30, 4, 8 },
                    { 23, 5, 23 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_EstrellasId",
                table: "Hotel",
                column: "EstrellasId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioEstrellas_EstrellasId",
                table: "ServicioEstrellas",
                column: "EstrellasId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioEstrellas_ServicioId",
                table: "ServicioEstrellas",
                column: "ServicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FotoHotel");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "ServicioEstrellas");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Estrellas");
        }
    }
}
