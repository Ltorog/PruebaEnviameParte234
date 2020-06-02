using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiEnviame.Migrations
{
    public partial class AgregarMigraciondedatosaDBEnviame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENV_ENVIOS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: false),
                    CiudadEnvio = table.Column<string>(nullable: false),
                    CiudadDestino = table.Column<string>(nullable: false),
                    FechaEnvio = table.Column<DateTime>(nullable: false),
                    FechaEstimadaEntrega = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENV_ENVIOS", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENV_ENVIOS");
        }
    }
}
