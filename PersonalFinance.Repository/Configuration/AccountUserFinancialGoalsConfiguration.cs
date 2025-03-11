using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Configuration
{
    public class AccountUserFinancialGoalsConfiguration : IEntityTypeConfiguration<AccountUserFinancialGoals>
    {
        public void Configure(EntityTypeBuilder<AccountUserFinancialGoals> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.AccountUser)
                .WithMany(u => u.AccontUserFinancialGoalList)
                .HasForeignKey(u => u.AccountUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.FinancialGoals)
               .WithMany(u => u.AccountUserFinancialGoalList)
               .HasForeignKey(u => u.FinancialGoalsId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
