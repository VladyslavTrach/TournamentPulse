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
    internal class AgeClassEntityConfiguration : IEntityTypeConfiguration<AgeClass>
    {
        public void Configure(EntityTypeBuilder<AgeClass> builder)
        {
            // PK
            builder.HasKey(ac => ac.Id);

            // Name is required
            builder.Property(ac => ac.Name).IsRequired();

            // ONE AgeClass has MANY Fighters,
            // but ONE Fighter belongs to ONE AgeClass
            builder.HasMany(ac => ac.Fighters)
                .WithOne(f => f.AgeClass)
                .HasForeignKey(f => f.AgeClassId);
        }
    }
}
