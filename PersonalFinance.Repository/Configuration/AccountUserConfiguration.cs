using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Configuration
{
    public class AccountUserConfiguration : IEntityTypeConfiguration<AccountUser>
    {
        public void Configure(EntityTypeBuilder<AccountUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasDefaultValue("")
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(u => u.Surname)
                .HasDefaultValue("")
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(u => u.email)
               .IsRequired()
               .HasMaxLength(30);

            builder.Property(u => u.amount)
                .HasColumnType("decimal(18,2)");

            builder.OwnsOne(u => u.UserAuthentication, a => 
            {
                //a.ToTable("Authentication");//i want to be in the same table as the AccountUser
                a.WithOwner().HasForeignKey(p => p.AccountUserId);
                a.Property(p => p.au_username).HasMaxLength(128);
                a.Property(p => p.au_password).HasMaxLength(500);
                a.Property(p => p.Token).HasMaxLength(500);
                
            });



        }
    }
}
