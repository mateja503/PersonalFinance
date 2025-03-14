using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinance.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveThePropertyPasswordSaltFromAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAuthentication_au_password_salt",
                table: "AccountUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAuthentication_au_password_salt",
                table: "AccountUsers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
