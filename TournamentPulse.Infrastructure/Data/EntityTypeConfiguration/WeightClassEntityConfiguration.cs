using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Infrastructure.Data.EntityTypeConfiguration
{
    internal class WeightClassEntityConfiguration : IEntityTypeConfiguration<WeightClass>
    {
        public void Configure(EntityTypeBuilder<WeightClass> builder)
        {
            // PK
            builder.HasKey(wc => wc.Id);

            // Name is required
            builder.Property(wc => wc.Name).IsRequired();

            // Define the relationship with Fighter (ONE WeightClass has MANY Fighters)
            builder
                .HasMany(wc => wc.Fighters)
                .WithOne(f => f.WeightClass)
                .HasForeignKey(f => f.WeightClassId);

        }
    }
}
