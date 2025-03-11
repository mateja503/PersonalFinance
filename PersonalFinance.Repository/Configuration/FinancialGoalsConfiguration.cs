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
    public class FinancialGoalsConfiguration : IEntityTypeConfiguration<FinancialGoals>
    {
        public void Configure(EntityTypeBuilder<FinancialGoals> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.goalText)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(u => u.goalReachInTime)
                .IsRequired();

            builder.Property(u => u.amountGoal)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

                
        }
    }
}
