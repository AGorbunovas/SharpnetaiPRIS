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

            migrationBuilder.AlterColumn<string>(
                name: "ModuleName",
                table: "Module",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    CandidateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.CandidateID);
                });

            migrationBuilder.CreateTable(
                name: "ResultLimits",
                columns: table => new
                {
                    ResultLimitsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateLimitSet = table.Column<string>(nullable: true),
                    Task1 = table.Column<float>(nullable: true),
                    Task2 = table.Column<float>(nullable: false),
                    Task3 = table.Column<float>(nullable: false),
                    Task4 = table.Column<float>(nullable: false),
                    Task5 = table.Column<float>(nullable: false),
                    Task6 = table.Column<float>(nullable: false),
                    Task7 = table.Column<float>(nullable: false),
                    Task8 = table.Column<float>(nullable: false),
                    Task9 = table.Column<float>(nullable: false),
                    Task10 = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultLimits", x => x.ResultLimitsId);
                });

            migrationBuilder.CreateTable(
                name: "TaskGroup",
                columns: table => new
                {
                    TaskGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskGroupName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskGroup", x => x.TaskGroupID);
                });

            migrationBuilder.CreateTable(
                name: "CandidateModule",
                columns: table => new
                {
                    ModuleID = table.Column<int>(nullable: false),
                    CandidateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateModule", x => new { x.CandidateID, x.ModuleID });
                    table.ForeignKey(
                        name: "FK_CandidateModule_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateModule_Module_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Module",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateModule_ModuleID",
                table: "CandidateModule",
                column: "ModuleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateModule");

            migrationBuilder.DropTable(
                name: "ResultLimits");

            migrationBuilder.DropTable(
                name: "TaskGroup");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfTest",
                table: "Test",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ModuleName",
                table: "Module",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

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
