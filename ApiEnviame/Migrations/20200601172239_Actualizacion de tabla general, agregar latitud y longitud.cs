using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiEnviame.Migrations
{
    public partial class Actualizaciondetablageneralagregarlatitudylongitud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CiudadDestino",
                table: "ENV_ENVIOS");

            migrationBuilder.DropColumn(
                name: "CiudadEnvio",
                table: "ENV_ENVIOS");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitud",
                table: "ENV_ENVIOS",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitud",
                table: "ENV_ENVIOS",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "LugarEnvío",
                table: "ENV_ENVIOS",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "ENV_ENVIOS");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "ENV_ENVIOS");

            migrationBuilder.DropColumn(
                name: "LugarEnvío",
                table: "ENV_ENVIOS");

            migrationBuilder.AddColumn<string>(
                name: "CiudadDestino",
                table: "ENV_ENVIOS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CiudadEnvio",
                table: "ENV_ENVIOS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
