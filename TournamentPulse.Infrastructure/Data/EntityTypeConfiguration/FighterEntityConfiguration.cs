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
    internal class FighterEntityConfiguration : IEntityTypeConfiguration<Fighter>
    {
        public void Configure(EntityTypeBuilder<Fighter> builder)
        {
            //PK
            builder.HasKey(f => f.Id);

            //FullName is required
            builder.Property(f => f.FullName).IsRequired();

            builder
                .HasOne(f => f.WeightClass)
                .WithMany(w => w.Fighters)
                .HasForeignKey(f => f.WeightClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.AgeClass)
                .WithMany(w => w.Fighters)
                .HasForeignKey(f => f.AgeClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.RankClass)
                .WithMany(w => w.Fighters)
                .HasForeignKey(f => f.RankClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.Academy)
                .WithMany(w => w.Fighters)
                .HasForeignKey(f => f.AcademyId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
