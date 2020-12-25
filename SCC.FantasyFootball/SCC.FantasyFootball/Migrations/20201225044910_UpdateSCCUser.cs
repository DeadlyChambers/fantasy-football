using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCC.FantasyFootball.Migrations
{
    public partial class UpdateSCCUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_claims_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_user_logins_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserLogins");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_user_tokens_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "public");

            migrationBuilder.DropPrimaryKey(
                name: "pk_identity_user",
                schema: "public",
                table: "IdUser");

            migrationBuilder.AlterColumn<string>(
                name: "user_name",
                schema: "public",
                table: "IdUser",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "normalized_user_name",
                schema: "public",
                table: "IdUser",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "normalized_email",
                schema: "public",
                table: "IdUser",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "public",
                table: "IdUser",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                schema: "public",
                table: "IdUser",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "public",
                table: "IdUser",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "public",
                table: "IdUser",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_user_claims_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserClaims",
                column: "user_id",
                principalSchema: "public",
                principalTable: "IdUser",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_logins_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserLogins",
                column: "user_id",
                principalSchema: "public",
                principalTable: "IdUser",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_roles_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserRoles",
                column: "user_id",
                principalSchema: "public",
                principalTable: "IdUser",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_tokens_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserTokens",
                column: "user_id",
                principalSchema: "public",
                principalTable: "IdUser",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_claims_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_user_logins_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserLogins");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_user_tokens_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                schema: "public",
                table: "IdUser");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                schema: "public",
                table: "IdUser");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "public",
                table: "IdUser");

            migrationBuilder.AlterColumn<string>(
                name: "user_name",
                schema: "public",
                table: "IdUser",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "normalized_user_name",
                schema: "public",
                table: "IdUser",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "normalized_email",
                schema: "public",
                table: "IdUser",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "public",
                table: "IdUser",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_identity_user",
                schema: "public",
                table: "IdUser",
                column: "id");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "public",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "public",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_user_claims_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserClaims",
                column: "user_id",
                principalSchema: "public",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_logins_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserLogins",
                column: "user_id",
                principalSchema: "public",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_roles_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserRoles",
                column: "user_id",
                principalSchema: "public",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_tokens_asp_net_users_scc_user_id",
                schema: "public",
                table: "IdUserTokens",
                column: "user_id",
                principalSchema: "public",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
