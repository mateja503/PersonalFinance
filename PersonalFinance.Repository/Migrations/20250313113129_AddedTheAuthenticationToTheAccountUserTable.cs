using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinance.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedTheAuthenticationToTheAccountUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authentication",
                columns: table => new
                {
                    AccounUserId = table.Column<int>(type: "int", nullable: false),
                    au_username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    au_password_has = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    au_password_salt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentication");
        }
    }
}
