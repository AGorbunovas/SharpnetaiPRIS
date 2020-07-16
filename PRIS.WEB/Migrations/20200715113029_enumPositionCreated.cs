using Microsoft.EntityFrameworkCore.Migrations;

namespace PRIS.WEB.Migrations
{
    public partial class enumPositionCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
