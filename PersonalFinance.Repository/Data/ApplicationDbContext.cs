using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersonalFinance.Domain.Identity;
using PersonalFinance.Domain.Identity.RoleManager;
using PersonalFinance.Domain.Identity.RoleManager.Enumiration;
using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) 
    {
        

        public DbSet<AccountUser> AccountUsers { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<AccountUserRole> AccountUserRoles { get; set; }
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
           // This is not required unless you're extending an existing configuration.
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
           

            new BudgetConfiguration().Configure(modelbuilder.Entity<Budget>());
            new CategoryConfiguration().Configure(modelbuilder.Entity<Category>());
            new FinancialGoalsConfiguration().Configure(modelbuilder.Entity<FinancialGoals>());
            new NoteConfiguration().Configure(modelbuilder.Entity<Note>());
            new TransactionConfiguration().Configure(modelbuilder.Entity<Transaction>());
            new AccountUserBudgetConfiguration().Configure(modelbuilder.Entity<AccountUserBudget>());
            new AccountUserFinancialGoalsConfiguration().Configure(modelbuilder.Entity<AccountUserFinancialGoals>());
            new TransactionNotesConfiguration().Configure(modelbuilder.Entity<TransactionNotes>());
            
            new AccountUserConfiguration().Configure(modelbuilder.Entity<AccountUser>());
            new RoleConfiguration().Configure(modelbuilder.Entity<Role>());
            new AccountUserRoleConfiguration().Configure(modelbuilder.Entity<AccountUserRole>());

            modelbuilder.Entity<Budget>().HasData(
                    new Budget
                    {
                        Id = 1,
                        budgetAmount = 100.00,
                        BudgetMonth = new DateTime(2024, 4, 1)//year month day

                    }

                );

            modelbuilder.Entity<Category>().HasData(
                 new Category
                 {
                     Id = 1,
                     categoryName = "Намирници-Храна",
                 },
                   new Category
                   {
                       Id = 2,
                       categoryName = "Плата",
                   }

             );

            modelbuilder.Entity<FinancialGoals>().HasData(
               new FinancialGoals
               {
                   Id = 1,
                   goalText = "Потребни ми се 21.000$ за целосно опремување на стан",
                   goalReachInTime = new DateTime(2024, 8, 1),
                   amountGoal = 21000.00

               }

           );

            modelbuilder.Entity<Note>().HasData(
               new Note
               {
                   Id = 1,
                   Text = "Купено Леб,Сирење,Чајна",

               },
               new Note
               {
                   Id = 2,
                   Text = "Плата од фирма Апдомен чувај за стан!!!!",

               }


           );

            modelbuilder.Entity<Transaction>().HasData(
             new Transaction
             {
                 Id = 1,
                 dateTime = new DateTime(2024, 4, 17),
                 TransactionType = Domain.Enum.TransactionType.Expense,
                 amount = 200.00,
                 CategoryId = 1,

             },
                new Transaction
                {
                    Id = 2,
                    dateTime = new DateTime(2024, 4, 16),
                    TransactionType = Domain.Enum.TransactionType.Income,
                    amount = 500.00,
                    CategoryId = 2,

                }

         );


            modelbuilder.Entity<TransactionNotes>().HasData(
        new TransactionNotes
        {
            Id = 1,
            TransactionId = 1,
            NoteId = 1

        },
           new TransactionNotes
           {
               Id = 2,
               TransactionId = 2,
               NoteId = 2

           }

    );





            base.OnModelCreating(modelbuilder);
        }

    }
}
