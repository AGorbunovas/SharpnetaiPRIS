using Microsoft.EntityFrameworkCore.Migrations;

namespace PRIS.WEB.Data.Migrations
{
    public partial class CandidateTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Task9",
                table: "ResultLimits",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Task8",
                table: "ResultLimits",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Task7",
                table: "ResultLimits",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Task6",
                table: "ResultLimits",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Task5",
                table: "ResultLimits",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Task4",
                table: "ResultLimits",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Task3",
                table: "ResultLimits",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Task2",
                table: "ResultLimits",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Task10",
                table: "ResultLimits",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Task1",
                table: "ResultLimits",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ResultSumMax",
                table: "ResultLimits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Candidate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_TestId",
                table: "Candidate",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Test_TestId",
                table: "Candidate",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Test_TestId",
                table: "Candidate");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_TestId",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "ResultSumMax",
                table: "ResultLimits");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Candidate");

            migrationBuilder.AlterColumn<float>(
                name: "Task9",
                table: "ResultLimits",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Task8",
                table: "ResultLimits",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Task7",
                table: "ResultLimits",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Task6",
                table: "ResultLimits",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Task5",
                table: "ResultLimits",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Task4",
                table: "ResultLimits",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Task3",
                table: "ResultLimits",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Task2",
                table: "ResultLimits",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Task10",
                table: "ResultLimits",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Task1",
                table: "ResultLimits",
                type: "real",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
