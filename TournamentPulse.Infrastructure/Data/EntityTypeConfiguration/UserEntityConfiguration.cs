using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Infrastructure.Data.EntityTypeConfiguration
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id); // Define the primary key

            builder.Property(u => u.FullName)
                .IsRequired(); // FullName is required

            builder.Property(u => u.Login)
                .IsRequired(false); // Login is optional (nullable)

            builder.Property(u => u.Password)
                .IsRequired(false); // Password is optional (nullable)

            builder.Property(u => u.Role)
                .IsRequired(false); // Role is optional (nullable)

            builder.HasMany(u => u.Fighters)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
