using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRIS.WEB.Migrations
{
    public partial class resultLimitTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ClassYearEnd",
                table: "Test",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ClassYearStart",
                table: "Test",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TestTaskTaskId",
                table: "ResultLimits",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InterviewTask",
                columns: table => new
                {
                    InterviewTaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewTaskName = table.Column<string>(nullable: false),
                    TaskGroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewTask", x => x.InterviewTaskID);
                    table.ForeignKey(
                        name: "FK_InterviewTask_TaskGroups_TaskGroupID",
                        column: x => x.TaskGroupID,
                        principalTable: "TaskGroups",
                        principalColumn: "TaskGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "560f1d08-6c0c-4988-8dae-aa2a5dbd8849");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "02ecce06-b671-4b9a-bdf8-47b8597215bf", "AQAAAAEAACcQAAAAEMiTbaZr3c6OOuNRmNaMXxM+2MMran5G7RmjyVIfedKtuspK3Ut9IgRXtdt5noiVZQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_ResultLimits_TestTaskTaskId",
                table: "ResultLimits",
                column: "TestTaskTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewTask_TaskGroupID",
                table: "InterviewTask",
                column: "TaskGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultLimits_TestTasks_TestTaskTaskId",
                table: "ResultLimits",
                column: "TestTaskTaskId",
                principalTable: "TestTasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultLimits_TestTasks_TestTaskTaskId",
                table: "ResultLimits");

            migrationBuilder.DropTable(
                name: "InterviewTask");

            migrationBuilder.DropIndex(
                name: "IX_ResultLimits_TestTaskTaskId",
                table: "ResultLimits");

            migrationBuilder.DropColumn(
                name: "ClassYearEnd",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "ClassYearStart",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "TestTaskTaskId",
                table: "ResultLimits");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "de1cf573-8f74-4506-a607-d6d90ee59817");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "900bc4bf-c539-4004-9ed3-fba07b69a544", "AQAAAAEAACcQAAAAEBkUqjksGg5FYCDd6I9AsS1FoFfbgmYn/GKz+o50H+OuNXHHQ4Tn8hv6TSDJX+swLQ==" });
        }
    }
}
