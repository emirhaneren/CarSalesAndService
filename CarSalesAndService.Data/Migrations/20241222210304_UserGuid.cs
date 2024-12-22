using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSalesAndService.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "Kullanicilar",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklenmeTarihi", "UserGuid" },
                values: new object[] { new DateTime(2024, 12, 23, 0, 3, 3, 82, DateTimeKind.Local).AddTicks(4117), new Guid("ec6a30b4-c0e8-461d-b6cd-3978f1a438f8") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Kullanicilar");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 12, 22, 16, 59, 58, 93, DateTimeKind.Local).AddTicks(187));
        }
    }
}
