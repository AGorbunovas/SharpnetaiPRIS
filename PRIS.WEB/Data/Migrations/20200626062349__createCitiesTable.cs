using Microsoft.EntityFrameworkCore.Migrations;

namespace PRIS.WEB.Data.Migrations
{
    public partial class _createCitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Cities_CityId",
                table: "Test");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Modules",
                newName: "Module");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "City",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "City",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Module",
                table: "Module",
                column: "ModuleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityId");

            migrationBuilder.CreateTable(
                name: "TestResultLimits",
                columns: table => new
                {
                    ResultSettingsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task1 = table.Column<int>(nullable: false),
                    Task2 = table.Column<int>(nullable: false),
                    Task3 = table.Column<int>(nullable: false),
                    Task4 = table.Column<int>(nullable: false),
                    Task5 = table.Column<int>(nullable: false),
                    Task6 = table.Column<int>(nullable: false),
                    Task7 = table.Column<int>(nullable: false),
                    Task8 = table.Column<int>(nullable: false),
                    Task9 = table.Column<int>(nullable: false),
                    Task10 = table.Column<int>(nullable: false),
                    Task11 = table.Column<int>(nullable: false),
                    Task12 = table.Column<int>(nullable: false),
                    Task13 = table.Column<int>(nullable: false),
                    Task14 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResultLimits", x => x.ResultSettingsId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CityId1",
                table: "City",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_City_City_CityId1",
                table: "City",
                column: "CityId1",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_City_CityId",
                table: "Test",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_City_CityId1",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_City_CityId",
                table: "Test");

            migrationBuilder.DropTable(
                name: "TestResultLimits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Module",
                table: "Module");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_CityId1",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "City");

            migrationBuilder.RenameTable(
                name: "Module",
                newName: "Modules");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                table: "Modules",
                column: "ModuleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Cities_CityId",
                table: "Test",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
