using Microsoft.EntityFrameworkCore.Migrations;

namespace PRIS.WEB.Migrations
{
    public partial class _createTestResultLimitsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestResultLimits");
        }
    }
}
