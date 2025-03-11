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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.dateTime)
                .IsRequired();

            builder.Property(u => u.amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
               
            // todo
        }
    }
}
