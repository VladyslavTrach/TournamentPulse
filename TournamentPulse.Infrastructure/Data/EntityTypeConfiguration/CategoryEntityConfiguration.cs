using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Infrastructure.Data.EntityTypeConfiguration
{
    internal class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // PK
            builder.HasKey(c => c.Id);

            // Name is required
            builder.Property(c => c.Name).IsRequired();

            builder
                .HasOne(c => c.WeightClass)
                .WithMany()
                .HasForeignKey(c => c.WeightClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.RankClass)
                .WithMany()
                .HasForeignKey(c => c.RankClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.AgeClass)
                .WithMany()
                .HasForeignKey(c => c.AgeClassId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
