using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinance.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnToAccountUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentication");

            migrationBuilder.AddColumn<string>(
                name: "UserAuthentication_Token",
                table: "AccountUsers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserAuthentication_au_password_has",
                table: "AccountUsers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserAuthentication_au_password_salt",
                table: "AccountUsers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserAuthentication_au_username",
                table: "AccountUsers",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAuthentication_Token",
                table: "AccountUsers");

            migrationBuilder.DropColumn(
                name: "UserAuthentication_au_password_has",
                table: "AccountUsers");

            migrationBuilder.DropColumn(
                name: "UserAuthentication_au_password_salt",
                table: "AccountUsers");

            migrationBuilder.DropColumn(
                name: "UserAuthentication_au_username",
                table: "AccountUsers");

            migrationBuilder.CreateTable(
                name: "Authentication",
                columns: table => new
                {
                    AccounUserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    au_password_has = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    au_password_salt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    au_username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication", x => x.AccounUserId);
                    table.ForeignKey(
                        name: "FK_Authentication_AccountUsers_AccounUserId",
                        column: x => x.AccounUserId,
                        principalTable: "AccountUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
