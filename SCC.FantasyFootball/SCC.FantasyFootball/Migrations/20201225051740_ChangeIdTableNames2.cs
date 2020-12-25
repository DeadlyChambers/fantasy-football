using Microsoft.EntityFrameworkCore.Migrations;

namespace SCC.FantasyFootball.Migrations
{
    public partial class ChangeIdTableNames2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "sccuser",
                schema: "public",
                newName: "_sccuser",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "identityusertoken<string>",
                schema: "public",
                newName: "_identityusertoken",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "identityuserrole<string>",
                schema: "public",
                newName: "_identityuserrole",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "identityuserlogin<string>",
                schema: "public",
                newName: "_identityuserlogin",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "identityuserclaim<string>",
                schema: "public",
                newName: "_identityuserclaim",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "identityroleclaim<string>",
                schema: "public",
                newName: "_identityroleclaim",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "identityrole",
                schema: "public",
                newName: "_identityrole",
                newSchema: "public");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "_sccuser",
                schema: "public",
                newName: "sccuser",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "_identityusertoken",
                schema: "public",
                newName: "identityusertoken<string>",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "_identityuserrole",
                schema: "public",
                newName: "identityuserrole<string>",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "_identityuserlogin",
                schema: "public",
                newName: "identityuserlogin<string>",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "_identityuserclaim",
                schema: "public",
                newName: "identityuserclaim<string>",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "_identityroleclaim",
                schema: "public",
                newName: "identityroleclaim<string>",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "_identityrole",
                schema: "public",
                newName: "identityrole",
                newSchema: "public");
        }
    }
}
