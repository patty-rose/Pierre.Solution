using Microsoft.EntityFrameworkCore.Migrations;

namespace Pierre.Migrations
{
    public partial class AddPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "FlavorTreat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf7441ce-98a5-4128-bd17-cb980d1cd2c5",
                column: "ConcurrencyStamp",
                value: "ddf787e8-617c-40b0-b039-8943b192c183");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca56c49-d3c8-4216-8d39-8f03c9db9acf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1847227-2dda-4158-bf70-98b7762980e3", "AQAAAAEAACcQAAAAEFrqxMRQN79Q2aUq7oGkZaYTBaatSm3EDY9w1Azna+scUbq6oV/Vcjz2zmZ13l7c8A==", "ca5f1c07-4330-43a0-8965-df808fa6b940" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "FlavorTreat");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf7441ce-98a5-4128-bd17-cb980d1cd2c5",
                column: "ConcurrencyStamp",
                value: "30d0b2ad-3557-40a7-8dfc-bb17f85b740b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca56c49-d3c8-4216-8d39-8f03c9db9acf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9235144-f760-4649-96a7-40cc0a7c386a", "AQAAAAEAACcQAAAAEEYWckdtiUIhGhKROkR9NoOxG/32vYDvy9FfwCc/KjyicXz8ZAiMC2o5MBkgS0zyGA==", "c8042504-abd7-4a3f-b08c-a4d17bbb6617" });
        }
    }
}
