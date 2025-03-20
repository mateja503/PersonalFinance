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
    public class AccountUserRoleConfiguration : IEntityTypeConfiguration<AccountUserRole>
    {
        public void Configure(EntityTypeBuilder<AccountUserRole> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.AccountUser)
                .WithMany(u => u.Roles)
                .HasForeignKey(u => u.AccountUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Role)
                .WithMany(u => u.AccountUsers)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);


                
        }
    }
}
