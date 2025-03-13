using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalFinance.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: ""),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: ""),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    budgetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    goalText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    goalReachInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amountGoal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialGoals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountUserBudgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUserId = table.Column<int>(type: "int", nullable: true),
                    BudgetId = table.Column<int>(type: "int", nullable: true),
                    Categoryid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUserBudgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountUserBudgets_AccountUsers_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "AccountUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountUserBudgets_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountUserBudgets_Categories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountUserFinancialGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUserId = table.Column<int>(type: "int", nullable: false),
                    FinancialGoalsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUserFinancialGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountUserFinancialGoals_AccountUsers_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "AccountUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountUserFinancialGoals_FinancialGoals_FinancialGoalsId",
                        column: x => x.FinancialGoalsId,
                        principalTable: "FinancialGoals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountUserRoles_AccountUsers_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "AccountUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    NoteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionNotes_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionNotes_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "Id", "BudgetMonth", "budgetAmount" },
                values: new object[] { 1, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "categoryName" },
                values: new object[,]
                {
                    { 1, "Намирници-Храна" },
                    { 2, "Плата" }
                });

            migrationBuilder.InsertData(
                table: "FinancialGoals",
                columns: new[] { "Id", "amountGoal", "goalReachInTime", "goalText" },
                values: new object[] { 1, 21000m, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Потребни ми се 21.000$ за целосно опремување на стан" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "Купено Леб,Сирење,Чајна" },
                    { 2, "Плата од фирма Апдомен чувај за стан!!!!" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "CategoryId", "TransactionType", "amount", "dateTime" },
                values: new object[,]
                {
                    { 1, 1, 2, 200m, new DateTime(2024, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 1, 500m, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TransactionNotes",
                columns: new[] { "Id", "NoteId", "TransactionId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountUserBudgets_AccountUserId",
                table: "AccountUserBudgets",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUserBudgets_BudgetId",
                table: "AccountUserBudgets",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUserBudgets_Categoryid",
                table: "AccountUserBudgets",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUserFinancialGoals_AccountUserId",
                table: "AccountUserFinancialGoals",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUserFinancialGoals_FinancialGoalsId",
                table: "AccountUserFinancialGoals",
                column: "FinancialGoalsId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUserRoles_AccountUserId",
                table: "AccountUserRoles",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUserRoles_RoleId",
                table: "AccountUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionNotes_NoteId",
                table: "TransactionNotes",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionNotes_TransactionId",
                table: "TransactionNotes",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountUserBudgets");

            migrationBuilder.DropTable(
                name: "AccountUserFinancialGoals");

            migrationBuilder.DropTable(
                name: "AccountUserRoles");

            migrationBuilder.DropTable(
                name: "TransactionNotes");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "FinancialGoals");

            migrationBuilder.DropTable(
                name: "AccountUsers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
