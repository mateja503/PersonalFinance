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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.categoryName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.TransactionList)
                .WithOne(t => t.CategoryTransaction)
                .HasForeignKey(t => t.CategoryTransactionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
