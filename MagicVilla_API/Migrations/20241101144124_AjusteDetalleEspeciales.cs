using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDetalleEspeciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetalleEspeciales",
                table: "NumeroVillas",
                newName: "DetalleEspecial");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 11, 1, 11, 41, 23, 905, DateTimeKind.Local).AddTicks(7849), new DateTime(2024, 11, 1, 11, 41, 23, 905, DateTimeKind.Local).AddTicks(7828) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 11, 1, 11, 41, 23, 905, DateTimeKind.Local).AddTicks(7855), new DateTime(2024, 11, 1, 11, 41, 23, 905, DateTimeKind.Local).AddTicks(7854) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetalleEspecial",
                table: "NumeroVillas",
                newName: "DetalleEspeciales");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 11, 1, 10, 54, 9, 748, DateTimeKind.Local).AddTicks(7075), new DateTime(2024, 11, 1, 10, 54, 9, 748, DateTimeKind.Local).AddTicks(7055) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 11, 1, 10, 54, 9, 748, DateTimeKind.Local).AddTicks(7080), new DateTime(2024, 11, 1, 10, 54, 9, 748, DateTimeKind.Local).AddTicks(7079) });
        }
    }
}
