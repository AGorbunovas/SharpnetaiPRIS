using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRIS.WEB.Migrations
{
    public partial class CandidateOrderNr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewTask_TaskGroups_TaskGroupID",
                table: "InterviewTask");

            migrationBuilder.DropIndex(
                name: "IX_InterviewTask_TaskGroupID",
                table: "InterviewTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskGroups",
                table: "TaskGroups");

            migrationBuilder.DropColumn(
                name: "ClassYearEnd",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "ClassYearStart",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "InterviewTaskName",
                table: "InterviewTask");

            migrationBuilder.DropColumn(
                name: "TaskGroupID",
                table: "InterviewTask");

            migrationBuilder.RenameTable(
                name: "TaskGroups",
                newName: "TaskGroup");

            migrationBuilder.AddColumn<int>(
                name: "AcademicYearID",
                table: "Test",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "MaxValue",
                table: "TaskResultLimits",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TaskResultLimits",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskGroupID",
                table: "TaskResultLimits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskResultLimitId",
                table: "TaskResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "InterviewTask",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InterviewTaskDescription",
                table: "InterviewTask",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "InterviewTask",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderNr",
                table: "CandidateModule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InvitedToInterview",
                table: "Candidate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InvitedToStudy",
                table: "Candidate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskGroup",
                table: "TaskGroup",
                column: "TaskGroupID");

            migrationBuilder.CreateTable(
                name: "AcademicYear",
                columns: table => new
                {
                    AcademicYearID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYearStart = table.Column<DateTime>(nullable: false),
                    AcademicYearEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYear", x => x.AcademicYearID);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractDate = table.Column<DateTime>(nullable: false),
                    ContractType = table.Column<int>(nullable: false),
                    SignedByFirstName = table.Column<string>(nullable: true),
                    SignedByLastName = table.Column<string>(nullable: true),
                    IsContractSigned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "InterviewQuestionsAnswers",
                columns: table => new
                {
                    InterviewQuestionsAnswersID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(nullable: true),
                    InterviewTaskID = table.Column<int>(nullable: false),
                    CandidateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewQuestionsAnswers", x => x.InterviewQuestionsAnswersID);
                    table.ForeignKey(
                        name: "FK_InterviewQuestionsAnswers_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewQuestionsAnswers_InterviewTask_InterviewTaskID",
                        column: x => x.InterviewTaskID,
                        principalTable: "InterviewTask",
                        principalColumn: "InterviewTaskID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterviewResult",
                columns: table => new
                {
                    InterviewResultID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralComment = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewResult", x => x.InterviewResultID);
                    table.ForeignKey(
                        name: "FK_InterviewResult_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterviewTemplate",
                columns: table => new
                {
                    InterviewTemplateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYearID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewTemplate", x => x.InterviewTemplateID);
                    table.ForeignKey(
                        name: "FK_InterviewTemplate_AcademicYear_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterviewTemplateTask",
                columns: table => new
                {
                    InterviewTemplateID = table.Column<int>(nullable: false),
                    InterviewTaskID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewTemplateTask", x => new { x.InterviewTaskID, x.InterviewTemplateID });
                    table.ForeignKey(
                        name: "FK_InterviewTemplateTask_InterviewTask_InterviewTaskID",
                        column: x => x.InterviewTaskID,
                        principalTable: "InterviewTask",
                        principalColumn: "InterviewTaskID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewTemplateTask_InterviewTemplate_InterviewTemplateID",
                        column: x => x.InterviewTemplateID,
                        principalTable: "InterviewTemplate",
                        principalColumn: "InterviewTemplateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "a3f94748-6570-43cf-b19d-0ee6ed5b6eeb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2a6f863-1265-44b7-805c-88fba182b55f", "2df69c73-20ac-42dc-881a-25df8ab9bb43", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5fc61b9a-442a-4aa1-83f5-2ecd52cb993a", "AQAAAAEAACcQAAAAEGGZzAxCe13t34HYgcsHRZ1XQoAk7l0Jm3ZFuqGGEMpG3HP8zCqgTUTl9shktLN6Ew==" });

            migrationBuilder.CreateIndex(
                name: "IX_Test_AcademicYearID",
                table: "Test",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskResultLimits_TaskGroupID",
                table: "TaskResultLimits",
                column: "TaskGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskResult_TaskResultLimitId",
                table: "TaskResult",
                column: "TaskResultLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewQuestionsAnswers_CandidateID",
                table: "InterviewQuestionsAnswers",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewQuestionsAnswers_InterviewTaskID",
                table: "InterviewQuestionsAnswers",
                column: "InterviewTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewResult_CandidateId",
                table: "InterviewResult",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewTemplate_AcademicYearID",
                table: "InterviewTemplate",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewTemplateTask_InterviewTemplateID",
                table: "InterviewTemplateTask",
                column: "InterviewTemplateID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskResult_TaskResultLimits_TaskResultLimitId",
                table: "TaskResult",
                column: "TaskResultLimitId",
                principalTable: "TaskResultLimits",
                principalColumn: "TaskResultLimitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskResultLimits_TaskGroup_TaskGroupID",
                table: "TaskResultLimits",
                column: "TaskGroupID",
                principalTable: "TaskGroup",
                principalColumn: "TaskGroupID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_AcademicYear_AcademicYearID",
                table: "Test",
                column: "AcademicYearID",
                principalTable: "AcademicYear",
                principalColumn: "AcademicYearID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskResult_TaskResultLimits_TaskResultLimitId",
                table: "TaskResult");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskResultLimits_TaskGroup_TaskGroupID",
                table: "TaskResultLimits");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_AcademicYear_AcademicYearID",
                table: "Test");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "InterviewQuestionsAnswers");

            migrationBuilder.DropTable(
                name: "InterviewResult");

            migrationBuilder.DropTable(
                name: "InterviewTemplateTask");

            migrationBuilder.DropTable(
                name: "InterviewTemplate");

            migrationBuilder.DropTable(
                name: "AcademicYear");

            migrationBuilder.DropIndex(
                name: "IX_Test_AcademicYearID",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_TaskResultLimits_TaskGroupID",
                table: "TaskResultLimits");

            migrationBuilder.DropIndex(
                name: "IX_TaskResult_TaskResultLimitId",
                table: "TaskResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskGroup",
                table: "TaskGroup");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2a6f863-1265-44b7-805c-88fba182b55f");

            migrationBuilder.DropColumn(
                name: "AcademicYearID",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "TaskGroupID",
                table: "TaskResultLimits");

            migrationBuilder.DropColumn(
                name: "TaskResultLimitId",
                table: "TaskResult");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "InterviewTask");

            migrationBuilder.DropColumn(
                name: "InterviewTaskDescription",
                table: "InterviewTask");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "InterviewTask");

            migrationBuilder.DropColumn(
                name: "OrderNr",
                table: "CandidateModule");

            migrationBuilder.DropColumn(
                name: "InvitedToInterview",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "InvitedToStudy",
                table: "Candidate");

            migrationBuilder.RenameTable(
                name: "TaskGroup",
                newName: "TaskGroups");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClassYearEnd",
                table: "Test",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ClassYearStart",
                table: "Test",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxValue",
                table: "TaskResultLimits",
                type: "decimal(18,1)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "TaskResultLimits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "InterviewTaskName",
                table: "InterviewTask",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TaskGroupID",
                table: "InterviewTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskGroups",
                table: "TaskGroups",
                column: "TaskGroupID");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "ab9d509a-ec92-4dee-bf50-9ad46eaa0f32");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4df54ffd-b3cd-4d00-9387-1e458d5c4717", "AQAAAAEAACcQAAAAEDn0B3ZGunzGu2IOVxLtDFQRRmQ4FXfVAp57n/D+aSTTQ5PTpojsx357eQeLl5SbWA==" });

            migrationBuilder.CreateIndex(
                name: "IX_InterviewTask_TaskGroupID",
                table: "InterviewTask",
                column: "TaskGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewTask_TaskGroups_TaskGroupID",
                table: "InterviewTask",
                column: "TaskGroupID",
                principalTable: "TaskGroups",
                principalColumn: "TaskGroupID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
