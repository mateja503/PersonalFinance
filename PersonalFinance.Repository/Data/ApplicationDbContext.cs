using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Identity;
using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext<AccountUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<AccountUserBudget> AccountUserBudgets { get; set; }
        public DbSet<AccountUserFinancialGoals> AccountUserFinancialGoals { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FinancialGoals> FinancialGoals { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<TransactionNotes> TransactionNotes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            new BudgetConfiguration().Configure(modelbuilder.Entity<Budget>());
            new CategoryConfiguration().Configure(modelbuilder.Entity<Category>());
            new FinancialGoalsConfiguration().Configure(modelbuilder.Entity<FinancialGoals>());
            new NoteConfiguration().Configure(modelbuilder.Entity<Note>());
            new TransactionConfiguration().Configure(modelbuilder.Entity<Transaction>());


        }
    }
}
