using Microsoft.EntityFrameworkCore.Migrations;

namespace Pierre.Migrations
{
    public partial class CartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf7441ce-98a5-4128-bd17-cb980d1cd2c5",
                column: "ConcurrencyStamp",
                value: "65ca7217-9171-4378-a39d-97ebbf2348ea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca56c49-d3c8-4216-8d39-8f03c9db9acf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaaf6653-fe39-4202-8569-8d6cb155e982", "AQAAAAEAACcQAAAAEDkVIReuEwRmFEfPW3wUsJndO0BvqSdZ8J4qIGjqsiCvuRFNWH5XOip8N3eZ6sltOg==", "c542a75f-9801-4329-9a40-5e61e58a873e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf7441ce-98a5-4128-bd17-cb980d1cd2c5",
                column: "ConcurrencyStamp",
                value: "a7d7b192-de62-4b44-88e6-4035234d779a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca56c49-d3c8-4216-8d39-8f03c9db9acf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ff00011-b7d5-4eb9-9771-2889ada0f56b", "AQAAAAEAACcQAAAAEEshVXvH3M4E7iuWe3ff69CSZkCrwCfsJhRkXEJkLaOZmlMwNEvTS1wx/caf2d289g==", "904723a1-97ed-4350-be2c-8daffb09043d" });
        }
    }
}
