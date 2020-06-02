using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiEnviame.Migrations
{
    public partial class SeagregatabladedetallesdeenvioRequeridocampoforáneo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ENV_DETALLE_ENVIOS_ENV_ENVIOS_EnvioId",
                table: "ENV_DETALLE_ENVIOS");

            migrationBuilder.AlterColumn<long>(
                name: "EnvioId",
                table: "ENV_DETALLE_ENVIOS",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ENV_DETALLE_ENVIOS_ENV_ENVIOS_EnvioId",
                table: "ENV_DETALLE_ENVIOS",
                column: "EnvioId",
                principalTable: "ENV_ENVIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ENV_DETALLE_ENVIOS_ENV_ENVIOS_EnvioId",
                table: "ENV_DETALLE_ENVIOS");

            migrationBuilder.AlterColumn<long>(
                name: "EnvioId",
                table: "ENV_DETALLE_ENVIOS",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_ENV_DETALLE_ENVIOS_ENV_ENVIOS_EnvioId",
                table: "ENV_DETALLE_ENVIOS",
                column: "EnvioId",
                principalTable: "ENV_ENVIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
