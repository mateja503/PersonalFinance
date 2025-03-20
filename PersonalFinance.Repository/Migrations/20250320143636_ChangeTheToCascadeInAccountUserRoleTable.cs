using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinance.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTheToCascadeInAccountUserRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountUserRoles_AccountUsers_AccountUserId",
                table: "AccountUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountUserRoles_Roles_RoleId",
                table: "AccountUserRoles");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUserRoles_AccountUsers_AccountUserId",
                table: "AccountUserRoles",
                column: "AccountUserId",
                principalTable: "AccountUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUserRoles_Roles_RoleId",
                table: "AccountUserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountUserRoles_AccountUsers_AccountUserId",
                table: "AccountUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountUserRoles_Roles_RoleId",
                table: "AccountUserRoles");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUserRoles_AccountUsers_AccountUserId",
                table: "AccountUserRoles",
                column: "AccountUserId",
                principalTable: "AccountUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUserRoles_Roles_RoleId",
                table: "AccountUserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
