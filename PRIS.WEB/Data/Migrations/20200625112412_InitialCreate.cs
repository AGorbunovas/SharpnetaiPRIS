using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRIS.WEB.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Test");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfTest",
                table: "Test",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Test",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Test_CityId",
                table: "Test",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Cities_CityId",
                table: "Test",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Cities_CityId",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_CityId",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Test");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfTest",
                table: "Test",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Test",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
