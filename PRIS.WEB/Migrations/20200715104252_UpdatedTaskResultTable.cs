using Microsoft.EntityFrameworkCore.Migrations;

namespace PRIS.WEB.Migrations
{
    public partial class UpdatedTaskResultTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "TaskResultLimits");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxValue",
                table: "TaskResultLimits",
                type: "decimal(18,1)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "TaskResult",
                columns: table => new
                {
                    TaskResultId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskResult", x => x.TaskResultId);
                    table.ForeignKey(
                        name: "FK_TaskResult_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "80d21bfe-4a2a-4ad5-b1de-7bd24bd5aff4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b8ec438-15e5-4f4e-8908-dedcfd2e35d6", "AQAAAAEAACcQAAAAEJkU+Wij8IftId7UCwXkIBBAUloVX6pg2PDx3bEsn0E30av3aZXBLNF0LP0A+xadTA==" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskResult_CandidateId",
                table: "TaskResult",
                column: "CandidateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskResult");

            migrationBuilder.DropColumn(
                name: "MaxValue",
                table: "TaskResultLimits");

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "TaskResultLimits",
                type: "decimal(18,1)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "086f1a39-7e16-44e0-b4d5-cf52e81b7291");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "51a872eb-9de5-4ea0-9992-62d8d8152c36", "AQAAAAEAACcQAAAAEGfmHhztknOU0IqL3gd3p9n9G3Kgw3nvfsr4FESeVDT/ZXHZEbScQdblnQUeOvNhCg==" });
        }
    }
}
