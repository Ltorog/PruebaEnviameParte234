using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiEnviame.Migrations
{
    public partial class Seagregatabladedetallesdeenvio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENV_DETALLE_ENVIOS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePersonaEnvio = table.Column<string>(nullable: false),
                    NombrePersonaRecibe = table.Column<string>(nullable: false),
                    EntidadEnvio = table.Column<string>(nullable: false),
                    EnvioId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENV_DETALLE_ENVIOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ENV_DETALLE_ENVIOS_ENV_ENVIOS_EnvioId",
                        column: x => x.EnvioId,
                        principalTable: "ENV_ENVIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENV_DETALLE_ENVIOS_EnvioId",
                table: "ENV_DETALLE_ENVIOS",
                column: "EnvioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENV_DETALLE_ENVIOS");
        }
    }
}
