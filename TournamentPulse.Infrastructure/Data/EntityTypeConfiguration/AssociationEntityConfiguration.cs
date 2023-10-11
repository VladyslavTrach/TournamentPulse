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
    internal class AssociationEntityConfiguration : IEntityTypeConfiguration<Association>
    {
        public void Configure(EntityTypeBuilder<Association> builder)
        {
            // PK
            builder.HasKey(a => a.Id);

            // Name is required
            builder.Property(a => a.Name).IsRequired();

            // ONE Association has MANY Academies,
            // but ONE Academy belongs to ONE Association
            builder.HasMany(a => a.Academies)
                .WithOne(ac => ac.Association)
                .HasForeignKey(ac => ac.AssociationId);
        }
    }
}
