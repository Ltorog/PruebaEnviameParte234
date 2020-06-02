using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiEnviame.Migrations
{
    public partial class Actualizaciondetablageneralydetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntidadEnvio",
                table: "ENV_DETALLE_ENVIOS");

            migrationBuilder.DropColumn(
                name: "NombrePersonaEnvio",
                table: "ENV_DETALLE_ENVIOS");

            migrationBuilder.DropColumn(
                name: "NombrePersonaRecibe",
                table: "ENV_DETALLE_ENVIOS");

            migrationBuilder.AddColumn<string>(
                name: "EntidadEnvio",
                table: "ENV_ENVIOS",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombrePersonaEnvio",
                table: "ENV_ENVIOS",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombrePersonaRecibe",
                table: "ENV_ENVIOS",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EstadoEnvio",
                table: "ENV_DETALLE_ENVIOS",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "ENV_DETALLE_ENVIOS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ObservacionDetalle",
                table: "ENV_DETALLE_ENVIOS",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntidadEnvio",
                table: "ENV_ENVIOS");

            migrationBuilder.DropColumn(
                name: "NombrePersonaEnvio",
                table: "ENV_ENVIOS");

            migrationBuilder.DropColumn(
                name: "NombrePersonaRecibe",
                table: "ENV_ENVIOS");

            migrationBuilder.DropColumn(
                name: "EstadoEnvio",
                table: "ENV_DETALLE_ENVIOS");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "ENV_DETALLE_ENVIOS");

            migrationBuilder.DropColumn(
                name: "ObservacionDetalle",
                table: "ENV_DETALLE_ENVIOS");

            migrationBuilder.AddColumn<string>(
                name: "EntidadEnvio",
                table: "ENV_DETALLE_ENVIOS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombrePersonaEnvio",
                table: "ENV_DETALLE_ENVIOS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombrePersonaRecibe",
                table: "ENV_DETALLE_ENVIOS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
