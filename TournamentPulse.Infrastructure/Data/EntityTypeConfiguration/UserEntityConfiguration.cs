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
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(user => user.Id);

            // Configuration for FirstName property
            builder.Property(user => user.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            // Configuration for LastName property
            builder.Property(user => user.LastName)
                .HasMaxLength(50)
                .IsRequired();

            // Configuration for Email property
            builder.Property(user => user.Email)
                .HasMaxLength(100)
                .IsRequired();

            // Configuration for PhoneNumber property
            builder.Property(user => user.PhoneNumber)
                .HasMaxLength(15);

            // You can add more configurations for other properties as needed
        }
    }
}
