using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinance.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTheDeleteBehaviorForTheTransactionInTransactionNoteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionNotes_Notes_NoteId",
                table: "TransactionNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionNotes_Transactions_TransactionId",
                table: "TransactionNotes");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionNotes_Notes_NoteId",
                table: "TransactionNotes",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionNotes_Transactions_TransactionId",
                table: "TransactionNotes",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionNotes_Notes_NoteId",
                table: "TransactionNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionNotes_Transactions_TransactionId",
                table: "TransactionNotes");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionNotes_Notes_NoteId",
                table: "TransactionNotes",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionNotes_Transactions_TransactionId",
                table: "TransactionNotes",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id");
        }
    }
}
