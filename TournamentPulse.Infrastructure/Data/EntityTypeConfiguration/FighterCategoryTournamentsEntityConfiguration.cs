using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Infrastructure.Data.EntityTypeConfiguration
{
    internal class FighterCategoryTournamentsEntityConfiguration : IEntityTypeConfiguration<FighterCategoryTournament>
    {
        public void Configure(EntityTypeBuilder<FighterCategoryTournament> builder)
        {
            // Composite primary key configuration
            builder.HasKey(fct => new { fct.FighterId, fct.CategoryId, fct.TournamentId });

            // Define relationships
            builder
                .HasOne(fct => fct.Fighter)
                .WithMany(f => f.FighterCategoryTournaments)
                .HasForeignKey(fct => fct.FighterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fct => fct.Category)
                .WithMany(c => c.FighterCategoryTournaments)
                .HasForeignKey(fct => fct.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fct => fct.Tournament)
                .WithMany(t => t.FighterCategoryTournaments)
                .HasForeignKey(fct => fct.TournamentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
