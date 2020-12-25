using Microsoft.EntityFrameworkCore.Migrations;

namespace SCC.FantasyFootball.Migrations
{
    public partial class ChangeIdTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "IdUserTokens",
                schema: "public",
                newName: "identityusertoken<string>",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "IdUserRoles",
                schema: "public",
                newName: "identityuserrole<string>",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "IdUserLogins",
                schema: "public",
                newName: "identityuserlogin<string>",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "IdUserClaims",
                schema: "public",
                newName: "identityuserclaim<string>",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "IdUser",
                schema: "public",
                newName: "sccuser",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "IdRoleClaims",
                schema: "public",
                newName: "identityroleclaim<string>",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "IdRole",
                schema: "public",
                newName: "identityrole",
                newSchema: "public");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "sccuser",
                schema: "public",
                newName: "IdUser",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "identityusertoken<string>",
                schema: "public",
                newName: "IdUserTokens",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "identityuserrole<string>",
                schema: "public",
                newName: "IdUserRoles",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "identityuserlogin<string>",
                schema: "public",
                newName: "IdUserLogins",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "identityuserclaim<string>",
                schema: "public",
                newName: "IdUserClaims",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "identityroleclaim<string>",
                schema: "public",
                newName: "IdRoleClaims",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "identityrole",
                schema: "public",
                newName: "IdRole",
                newSchema: "public");
        }
    }
}
