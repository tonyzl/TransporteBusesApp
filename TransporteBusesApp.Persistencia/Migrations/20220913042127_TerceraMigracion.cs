using Microsoft.EntityFrameworkCore.Migrations;

namespace TransporteBusesApp.Persistencia.Migrations
{
    public partial class TerceraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelo = table.Column<int>(type: "int", nullable: false),
                    kilometraje = table.Column<int>(type: "int", nullable: false),
                    nro_asientos = table.Column<int>(type: "int", nullable: false),
                    placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Estaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coord_x = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coord_y = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estaciones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origenid = table.Column<int>(type: "int", nullable: true),
                    Destinoid = table.Column<int>(type: "int", nullable: true),
                    tiempo_estimado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rutas_Estaciones_Destinoid",
                        column: x => x.Destinoid,
                        principalTable: "Estaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rutas_Estaciones_Origenid",
                        column: x => x.Origenid,
                        principalTable: "Estaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_Destinoid",
                table: "Rutas",
                column: "Destinoid");

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_Origenid",
                table: "Rutas",
                column: "Origenid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Rutas");

            migrationBuilder.DropTable(
                name: "Estaciones");
        }
    }
}
