using Microsoft.EntityFrameworkCore.Migrations;

namespace PRIS.WEB.Data.Migrations
{
    public partial class CandidateModuleOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNr",
                table: "CandidateModule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2301D884-221A-4E7D-B509-0113DCC043E1", "0b0a2a32-0e79-4852-a3a6-0fa7f7ced1d3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "B22698B8-42A2-4115-9631-1C2D1E2AC5F7", 0, "5897d0ac-446a-46fd-a25e-9c61a4139f62", "Admin1@Admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN1@ADMIN.COM", "AQAAAAEAACcQAAAAEErCPX1USpyUB/WWOAeJ8eu3VL7kcs44pvPHPYZyIZ2eR9jgwHHA/Kt7jyu8SkVNTg==", "XXXXXXXXXXXXX", false, "00000000-0000-0000-0000-000000000000", false, "Admin1@Admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "B22698B8-42A2-4115-9631-1C2D1E2AC5F7", "2301D884-221A-4E7D-B509-0113DCC043E1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "B22698B8-42A2-4115-9631-1C2D1E2AC5F7", "2301D884-221A-4E7D-B509-0113DCC043E1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7");

            migrationBuilder.DropColumn(
                name: "OrderNr",
                table: "CandidateModule");
        }
    }
}
