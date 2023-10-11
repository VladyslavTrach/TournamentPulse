using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Infrastructure.Data.EntityTypeConfiguration
{
    internal class RankClassEntityConfiguration : IEntityTypeConfiguration<RankClass>
    {
        public void Configure(EntityTypeBuilder<RankClass> builder)
        {
            // PK
            builder.HasKey(rc => rc.Id);

            // Name is required
            builder.Property(rc => rc.Name).IsRequired();

            // Define the relationship with Fighter (ONE RankClass has MANY Fighters)
            builder
                .HasMany(rc => rc.Fighters)
                .WithOne(f => f.RankClass)
                .HasForeignKey(f => f.RankClassId);
        }
    }
}
