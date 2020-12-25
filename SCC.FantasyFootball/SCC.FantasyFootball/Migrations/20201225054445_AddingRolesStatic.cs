using Microsoft.EntityFrameworkCore.Migrations;

namespace SCC.FantasyFootball.Migrations
{
    public partial class AddingRolesStatic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "_identityrole",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "0", "6d9d38f5-6d4c-4919-b637-ededd3c90409", "Anoynomous", null },
                    { "1", "6a85564a-147b-4336-8d73-274b9a5c155d", "Admin", null },
                    { "2", "ddff504d-827a-4374-87cb-9e44cf8c0d9d", "Contributor", null },
                    { "3", "0aa7be65-17d4-4ce2-9f05-27cf88c3b70c", "Reader", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "_identityrole",
                keyColumn: "id",
                keyValue: "0");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "_identityrole",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "_identityrole",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "_identityrole",
                keyColumn: "id",
                keyValue: "3");
        }
    }
}
