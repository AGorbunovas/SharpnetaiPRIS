using Microsoft.EntityFrameworkCore.Migrations;

namespace PRIS.WEB.Migrations
{
    public partial class ChangesInTestTaskAndResultLimitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_City_CityId1",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_TestTasks_ResultLimits_AddResultMaxLimitViewModelResultLimitsId",
                table: "TestTasks");

            migrationBuilder.DropIndex(
                name: "IX_TestTasks_AddResultMaxLimitViewModelResultLimitsId",
                table: "TestTasks");

            migrationBuilder.DropIndex(
                name: "IX_City_CityId1",
                table: "City");

            migrationBuilder.DropColumn(
                name: "AddResultMaxLimitViewModelResultLimitsId",
                table: "TestTasks");

            migrationBuilder.DropColumn(
                name: "MaxResultValue",
                table: "TestTasks");

            migrationBuilder.DropColumn(
                name: "TestResultAvg",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "ResultSumMax",
                table: "ResultLimits");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "City");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaskResult",
                table: "TestTasks",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxResultLimit",
                table: "TestTasks",
                type: "decimal(18,1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultLimitsId",
                table: "TestTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "ResultLimits",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_TestTasks_ResultLimitsId",
                table: "TestTasks",
                column: "ResultLimitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestTasks_ResultLimits_ResultLimitsId",
                table: "TestTasks",
                column: "ResultLimitsId",
                principalTable: "ResultLimits",
                principalColumn: "ResultLimitsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestTasks_ResultLimits_ResultLimitsId",
                table: "TestTasks");

            migrationBuilder.DropIndex(
                name: "IX_TestTasks_ResultLimitsId",
                table: "TestTasks");

            migrationBuilder.DropColumn(
                name: "MaxResultLimit",
                table: "TestTasks");

            migrationBuilder.DropColumn(
                name: "ResultLimitsId",
                table: "TestTasks");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "ResultLimits");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaskResult",
                table: "TestTasks",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddResultMaxLimitViewModelResultLimitsId",
                table: "TestTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxResultValue",
                table: "TestTasks",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TestResultAvg",
                table: "TestResults",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ResultSumMax",
                table: "ResultLimits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "City",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "2cd87d57-30f7-43ba-b87e-c33a83fd598b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7c4f45a-d356-43f9-af54-fb4ace7715b3", "AQAAAAEAACcQAAAAEGqgL+GsLOqF9SM1BS9OXdrbH0BPZlH8nimchpp9609avETnxEEmTPeaxqsEiALvZA==" });

            migrationBuilder.CreateIndex(
                name: "IX_TestTasks_AddResultMaxLimitViewModelResultLimitsId",
                table: "TestTasks",
                column: "AddResultMaxLimitViewModelResultLimitsId");

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
                name: "FK_TestTasks_ResultLimits_AddResultMaxLimitViewModelResultLimitsId",
                table: "TestTasks",
                column: "AddResultMaxLimitViewModelResultLimitsId",
                principalTable: "ResultLimits",
                principalColumn: "ResultLimitsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
