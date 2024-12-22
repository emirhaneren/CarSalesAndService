using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSalesAndService.Data.Migrations
{
    /// <inheritdoc />
    public partial class AracFotoField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto1",
                table: "Araclar",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto2",
                table: "Araclar",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto3",
                table: "Araclar",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 12, 21, 16, 44, 9, 13, DateTimeKind.Local).AddTicks(5998));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto1",
                table: "Araclar");

            migrationBuilder.DropColumn(
                name: "Foto2",
                table: "Araclar");

            migrationBuilder.DropColumn(
                name: "Foto3",
                table: "Araclar");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 12, 18, 23, 39, 49, 624, DateTimeKind.Local).AddTicks(3101));
        }
    }
}
