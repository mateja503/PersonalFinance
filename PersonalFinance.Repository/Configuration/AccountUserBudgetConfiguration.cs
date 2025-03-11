using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using PersonalFinance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Configuration
{
    public class AccountUserBudgetConfiguration : IEntityTypeConfiguration<AccountUserBudget>
    {
        public void Configure(EntityTypeBuilder<AccountUserBudget> builder)
        {

            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.AccountUser)
                .WithMany(u => u.AccountUserBudgetList)
                .HasForeignKey(u => u.AccountUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.Budget)
                .WithMany(u => u.AccountUserBudgetList)
                .HasForeignKey(u => u.BudgetId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(u => u.Category)
              .WithMany(u => u.AccountUserBudgetList)
              .HasForeignKey(u => u.Categoryid)
              .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
