using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class ControlarNullables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 11, 27, 16, 27, 44, 657, DateTimeKind.Local).AddTicks(4283), new DateTime(2024, 11, 27, 16, 27, 44, 657, DateTimeKind.Local).AddTicks(4268) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 11, 27, 16, 27, 44, 657, DateTimeKind.Local).AddTicks(4286), new DateTime(2024, 11, 27, 16, 27, 44, 657, DateTimeKind.Local).AddTicks(4285) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 11, 27, 16, 18, 50, 699, DateTimeKind.Local).AddTicks(3579), new DateTime(2024, 11, 27, 16, 18, 50, 699, DateTimeKind.Local).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 11, 27, 16, 18, 50, 699, DateTimeKind.Local).AddTicks(3583), new DateTime(2024, 11, 27, 16, 18, 50, 699, DateTimeKind.Local).AddTicks(3582) });
        }
    }
}
