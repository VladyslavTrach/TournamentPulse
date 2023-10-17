using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Infrastructure.Data.EntityTypeConfiguration
{
    public class TournamentCategoryFighterEntityConfiguration : IEntityTypeConfiguration<TournamentCategoryFighter>
    {
        public void Configure(EntityTypeBuilder<TournamentCategoryFighter> builder)
        {
            builder.HasKey(tcf => new { tcf.TournamentId, tcf.CategoryId, tcf.FighterId });

            builder.HasOne(tcf => tcf.Tournament)
                .WithMany()
                .HasForeignKey(tcf => tcf.TournamentId);

            builder.HasOne(tcf => tcf.Category)
                .WithMany()
                .HasForeignKey(tcf => tcf.CategoryId);

            builder.HasOne(tcf => tcf.Fighter)
                .WithMany()
                .HasForeignKey(tcf => tcf.FighterId);
        }
    }
}
