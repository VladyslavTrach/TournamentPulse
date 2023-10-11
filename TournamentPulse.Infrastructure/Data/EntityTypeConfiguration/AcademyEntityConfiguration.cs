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
    internal class AcademyEntityConfiguration : IEntityTypeConfiguration<Academy>
    {
        public void Configure(EntityTypeBuilder<Academy> builder)
        {
            //PK
            builder.HasKey(a => a.Id);

            //Name is required
            builder.Property(a => a.Name).IsRequired();

            //ONE Academy has ONE Association,
            //but ONE Association has MANY Academies
            builder.HasOne(a => a.Association)
                .WithMany()
                .HasForeignKey(a => a.AssociationId);

            //ONE Academy has ONE Country,
            //but ONE Country has MANY Academies
            builder.HasOne(a => a.Country)
                .WithMany()
                .HasForeignKey(a => a.CountryId);

            //ONE Academy has MANY Fighters,
            //but ONE Fighter has One Academy
            builder.HasMany(a => a.Fighters)
                .WithOne(f => f.Academy)
                .HasForeignKey(f => f.AcademyId);
        }
    }
}
