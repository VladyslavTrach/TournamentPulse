using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Infrastructure.Data.EntityTypeConfiguration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.MinAge).IsRequired();
            builder.Property(c => c.MaxAge).IsRequired();
            builder.Property(c => c.MinWeight).IsRequired();
            builder.Property(c => c.MaxWeight).IsRequired();
            builder.Property(c => c.Rank).IsRequired();

            builder.HasMany(c => c.Matches)
            .WithOne(m => m.Category)
            .HasForeignKey(m => m.CategoryId);
        }
    }
}
