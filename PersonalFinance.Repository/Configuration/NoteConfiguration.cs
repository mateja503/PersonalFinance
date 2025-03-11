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
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Text)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasMany(n => n.NoteTransactionList)
                .WithMany(t => t.TransactionNoteList)
                .UsingEntity<TransactionNotes>(
                    //to do
                );
                
        }
    }
}
