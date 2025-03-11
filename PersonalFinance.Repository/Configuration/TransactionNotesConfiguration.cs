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
    public class TransactionNotesConfiguration : IEntityTypeConfiguration<TransactionNotes>
    {
        public void Configure(EntityTypeBuilder<TransactionNotes> builder)
        {
            builder.HasKey(u => u.Id);

           builder.HasOne(u => u.Transaction)
                .WithMany(u => u.TransactionNoteList)
                .HasForeignKey(u => u.TransactionId)
                .OnDelete(DeleteBehavior.NoAction);


              builder.HasOne(u => u.Note)
                .WithMany(u => u.TransactionNoteList)
                .HasForeignKey(u => u.NoteId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
