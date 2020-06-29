using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRIS.WEB.Data.Migrations
{
    public partial class _createResultLimitsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestResultLimits");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfTest",
                table: "Test",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ResultLimits",
                columns: table => new
                {
                    ResultLimitsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateLimitSet = table.Column<string>(nullable: true),
                    Task1 = table.Column<int>(nullable: false),
                    Task2 = table.Column<int>(nullable: false),
                    Task3 = table.Column<int>(nullable: false),
                    Task4 = table.Column<int>(nullable: false),
                    Task5 = table.Column<int>(nullable: false),
                    Task6 = table.Column<int>(nullable: false),
                    Task7 = table.Column<int>(nullable: false),
                    Task8 = table.Column<int>(nullable: false),
                    Task9 = table.Column<int>(nullable: false),
                    Task10 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultLimits", x => x.ResultLimitsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultLimits");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfTest",
                table: "Test",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "TestResultLimits",
                columns: table => new
                {
                    ResultSettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task1 = table.Column<int>(type: "int", nullable: false),
                    Task10 = table.Column<int>(type: "int", nullable: false),
                    Task11 = table.Column<int>(type: "int", nullable: false),
                    Task12 = table.Column<int>(type: "int", nullable: false),
                    Task13 = table.Column<int>(type: "int", nullable: false),
                    Task14 = table.Column<int>(type: "int", nullable: false),
                    Task2 = table.Column<int>(type: "int", nullable: false),
                    Task3 = table.Column<int>(type: "int", nullable: false),
                    Task4 = table.Column<int>(type: "int", nullable: false),
                    Task5 = table.Column<int>(type: "int", nullable: false),
                    Task6 = table.Column<int>(type: "int", nullable: false),
                    Task7 = table.Column<int>(type: "int", nullable: false),
                    Task8 = table.Column<int>(type: "int", nullable: false),
                    Task9 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResultLimits", x => x.ResultSettingsId);
                });
        }
    }
}
