using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinance.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ChangeThePropertyPasswordInAuthEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserAuthentication_au_password_has",
                table: "AccountUsers",
                newName: "UserAuthentication_au_password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserAuthentication_au_password",
                table: "AccountUsers",
                newName: "UserAuthentication_au_password_has");
        }
    }
}
