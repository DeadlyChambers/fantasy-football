using Microsoft.EntityFrameworkCore.Migrations;

namespace SCC.FantasyFootball.Migrations
{
    public partial class AddingRolesStatic1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "_identityrole",
                keyColumn: "id",
                keyValue: "0",
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "c459ca9a-5cbc-45d6-b47f-752dac2d3cc8", "ANOYNOMOUS" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "_identityrole",
                keyColumn: "id",
                keyValue: "1",
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "b2f168da-a7eb-4c80-9824-a8712baf4dcf", "ADMIN" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "_identityrole",
                keyColumn: "id",
                keyValue: "2",
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "c7d6393a-0da2-4c09-960a-00339fe28ef4", "CONTRIBUTOR" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "_identityrole",
                keyColumn: "id",
                keyValue: "3",
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "6b126f12-9e0c-45d8-a5db-94f1d7b1d4dd", "READER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "_identityrole",
                keyColumn: "id",
                keyValue: "0",
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "6d9d38f5-6d4c-4919-b637-ededd3c90409", null });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "_identityrole",
                keyColumn: "id",
                keyValue: "1",
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "6a85564a-147b-4336-8d73-274b9a5c155d", null });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "_identityrole",
                keyColumn: "id",
                keyValue: "2",
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "ddff504d-827a-4374-87cb-9e44cf8c0d9d", null });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "_identityrole",
                keyColumn: "id",
                keyValue: "3",
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "0aa7be65-17d4-4ce2-9f05-27cf88c3b70c", null });
        }
    }
}
